import {
  type PropsWithChildren,
  useCallback,
  useEffect,
  useMemo,
  useRef,
  useState,
} from 'react'
import { apiUrl, ApiError, readApiResponse } from '../api/http'
import type { RegistrationResult, TokenPair } from '../types/api'
import { AuthContext, type Session } from './context'
import { readIdentity } from './token'

const refreshTokenKey = 'modulog.refresh-token'

export function AuthProvider({ children }: PropsWithChildren) {
  const [session, setSession] = useState<Session | null>(null)
  const [isInitializing, setIsInitializing] = useState(true)
  const refreshInFlight = useRef<Promise<string | null> | null>(null)

  const applyTokens = useCallback((tokens: TokenPair) => {
    const identity = readIdentity(tokens.accessToken)
    sessionStorage.setItem(refreshTokenKey, tokens.refreshToken)
    setSession({ accessToken: tokens.accessToken, ...identity })
    return tokens.accessToken
  }, [])

  const logout = useCallback(() => {
    sessionStorage.removeItem(refreshTokenKey)
    setSession(null)
  }, [])

  const refresh = useCallback(async () => {
    const refreshToken = sessionStorage.getItem(refreshTokenKey)
    if (!refreshToken) {
      logout()
      return null
    }

    // One shared promise prevents several expired API calls from rotating the same
    // single-use refresh token at the same time.
    if (!refreshInFlight.current) {
      refreshInFlight.current = fetch(apiUrl('/api/v1/auth/refresh'), {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ refreshToken }),
      })
        .then((response) => readApiResponse<TokenPair>(response))
        .then(applyTokens)
        .catch(() => {
          logout()
          return null
        })
        .finally(() => {
          refreshInFlight.current = null
        })
    }

    return refreshInFlight.current
  }, [applyTokens, logout])

  useEffect(() => {
    refresh().finally(() => setIsInitializing(false))
  }, [refresh])

  const login = useCallback(
    async (email: string, password: string) => {
      const response = await fetch(apiUrl('/api/v1/auth/login'), {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password }),
      })
      applyTokens(await readApiResponse<TokenPair>(response))
    },
    [applyTokens],
  )

  const register = useCallback(async (email: string, password: string) => {
    const response = await fetch(apiUrl('/api/v1/auth/register'), {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ email, password }),
    })
    return readApiResponse<RegistrationResult>(response)
  }, [])

  const request = useCallback(
    async <T,>(path: string, init: RequestInit = {}) => {
      let accessToken = session?.accessToken
      if (!accessToken) {
        accessToken = (await refresh()) ?? undefined
      }
      if (!accessToken) {
        throw new ApiError('Your session has expired.', 401)
      }

      const send = (token: string) =>
        fetch(apiUrl(path), {
          ...init,
          headers: {
            ...(init.body ? { 'Content-Type': 'application/json' } : {}),
            ...init.headers,
            Authorization: `Bearer ${token}`,
          },
        })

      let response = await send(accessToken)
      if (response.status === 401) {
        const replacement = await refresh()
        if (!replacement) {
          throw new ApiError('Your session has expired.', 401)
        }
        response = await send(replacement)
      }

      return readApiResponse<T>(response)
    },
    [refresh, session?.accessToken],
  )

  const value = useMemo(
    () => ({
      session,
      isInitializing,
      login,
      register,
      logout,
      request,
    }),
    [isInitializing, login, logout, register, request, session],
  )

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>
}
