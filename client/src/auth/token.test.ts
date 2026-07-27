import { describe, expect, it } from 'vitest'
import { readIdentity } from './token'

const roleClaim = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'

function tokenFor(payload: object) {
  return `header.${btoa(JSON.stringify(payload))}.signature`
}

describe('readIdentity', () => {
  it('reads the email and a single ASP.NET Identity role', () => {
    const identity = readIdentity(
      tokenFor({
        email: 'admin@example.test',
        [roleClaim]: 'admin',
      }),
    )

    expect(identity).toEqual({
      email: 'admin@example.test',
      roles: ['admin'],
    })
  })

  it('rejects malformed access tokens', () => {
    expect(() => readIdentity('not-a-jwt')).toThrow(
      'The API returned an invalid access token.',
    )
  })
})
