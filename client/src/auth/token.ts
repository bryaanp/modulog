const roleClaim = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
const emailClaim = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'

interface JwtPayload {
  email?: string
  role?: string | string[]
  [roleClaim]?: string | string[]
  [emailClaim]?: string
}

export interface SessionIdentity {
  email: string
  roles: string[]
}

export function readIdentity(accessToken: string): SessionIdentity {
  const segments = accessToken.split('.')
  if (segments.length !== 3) {
    throw new Error('The API returned an invalid access token.')
  }

  const base64 = segments[1].replace(/-/g, '+').replace(/_/g, '/')
  const payload = JSON.parse(atob(base64)) as JwtPayload
  const rawRoles = payload.role ?? payload[roleClaim] ?? []

  return {
    email: payload.email ?? payload[emailClaim] ?? '',
    roles: Array.isArray(rawRoles) ? rawRoles : [rawRoles],
  }
}
