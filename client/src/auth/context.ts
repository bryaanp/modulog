import { createContext } from 'react'
import type { RegistrationResult } from '../types/api'

export interface Session {
  accessToken: string
  email: string
  roles: string[]
}

export interface AuthContextValue {
  session: Session | null
  isInitializing: boolean
  login(email: string, password: string): Promise<void>
  register(email: string, password: string): Promise<RegistrationResult>
  logout(): void
  request<T>(path: string, init?: RequestInit): Promise<T>
}

export const AuthContext = createContext<AuthContextValue | null>(null)
