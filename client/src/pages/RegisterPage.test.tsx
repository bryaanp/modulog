import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter } from 'react-router-dom'
import { describe, expect, it, vi } from 'vitest'
import { AuthContext, type AuthContextValue } from '../auth/context'
import { RegisterPage } from './RegisterPage'

function renderPage(overrides: Partial<AuthContextValue> = {}) {
  const value: AuthContextValue = {
    session: null,
    isInitializing: false,
    login: vi.fn(),
    register: vi.fn(),
    logout: vi.fn(),
    request: vi.fn(),
    ...overrides,
  }

  return {
    ...render(
      <MemoryRouter>
        <AuthContext.Provider value={value}>
          <RegisterPage />
        </AuthContext.Provider>
      </MemoryRouter>,
    ),
    value,
  }
}

describe('RegisterPage', () => {
  it('checks matching passwords before calling the API', async () => {
    const user = userEvent.setup()
    const register = vi.fn()
    renderPage({ register })

    await user.type(screen.getByLabelText('Email'), 'learner@example.test')
    await user.type(screen.getByLabelText(/^Password/), 'Valid!Password123')
    await user.type(screen.getByLabelText('Confirm password'), 'Different!Password123')
    await user.click(screen.getByRole('button', { name: 'Create account' }))

    expect(screen.getByRole('alert')).toHaveTextContent('Passwords must match.')
    expect(register).not.toHaveBeenCalled()
  })
})
