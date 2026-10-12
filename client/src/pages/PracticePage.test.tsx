import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { render, screen, waitFor } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter } from 'react-router-dom'
import { describe, expect, it, vi } from 'vitest'
import { AuthContext, type AuthContextValue } from '../auth/context'
import { PracticePage } from './PracticePage'

function renderPage(overrides: Partial<AuthContextValue> = {}) {
  const queryClient = new QueryClient({
    defaultOptions: {
      queries: { retry: false },
      mutations: { retry: false },
    },
  })

  const request: AuthContextValue['request'] = async <T,>(path: string) => {
    if (path === '/api/v1/problems') {
      return [
        {
          id: 'problem-1',
          title: 'Two Sum',
          difficulty: 'Easy',
          companies: ['Amazon'],
        },
      ] as T
    }

    if (path === '/api/v1/entries') {
      return {
        id: 'entry-1',
        problemBankId: 'problem-1',
        timeSpentMinutes: 30,
        hintsUsed: 0,
        selfRatedConfidence: null,
        reviewDueAt: null,
      } as T
    }

    throw new Error(`Unexpected request: ${path}`)
  }

  const value: AuthContextValue = {
    session: null,
    isInitializing: false,
    login: vi.fn(),
    register: vi.fn(),
    logout: vi.fn(),
    request,
    ...overrides,
  }

  return {
    ...render(
      <MemoryRouter>
        <AuthContext.Provider value={value}>
          <QueryClientProvider client={queryClient}>
            <PracticePage />
          </QueryClientProvider>
        </AuthContext.Provider>
      </MemoryRouter>,
    ),
    request,
  }
}

describe('PracticePage', () => {
  it('resets the form after a successful save', async () => {
    const user = userEvent.setup()
    renderPage()

    await screen.findByRole('option', { name: /Two Sum/i })

    await user.selectOptions(screen.getByLabelText('Problem'), 'problem-1')
    await user.clear(screen.getByLabelText('Time spent (minutes)'))
    await user.type(screen.getByLabelText('Time spent (minutes)'), '45')
    await user.clear(screen.getByLabelText('Hints used'))
    await user.type(screen.getByLabelText('Hints used'), '2')

    await user.click(screen.getByRole('button', { name: 'Save attempt' }))

    await waitFor(() => {
      expect(screen.getByText(/Attempt saved/i)).toBeInTheDocument()
    })

    expect(screen.getByLabelText('Problem')).toHaveValue('')
    expect(screen.getByLabelText('Time spent (minutes)')).toHaveValue(30)
    expect(screen.getByLabelText('Hints used')).toHaveValue(0)
  })
})
