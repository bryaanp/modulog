import { QueryClient, QueryClientProvider, useQuery } from '@tanstack/react-query'
import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { Link, MemoryRouter } from 'react-router-dom'
import { expect, it, vi } from 'vitest'
import { AuthContext, type AuthContextValue } from '../auth/context'
import { useInterview } from './useInterview'

function ScopedHistory() {
  const { projectId, request, link } = useInterview()
  const query = useQuery({
    queryKey: ['entries', projectId],
    queryFn: () => request<string>('/api/v1/entries?topic=tree'),
  })
  return (
    <>
      <p>{query.data}</p>
      <Link to="/entries?project=second">Switch project</Link>
      <Link to={link('/practice?problem=one')}>Log attempt</Link>
    </>
  )
}

it('keeps requests, navigation, and cached results scoped to the selected project', async () => {
  const request = vi.fn(async (path: string) =>
    path.includes('projectId=first') ? 'First project history' : 'Second project history',
  )
  const auth = {
    request,
    session: null,
    isInitializing: false,
    login: vi.fn(),
    register: vi.fn(),
    logout: vi.fn(),
  } as AuthContextValue
  render(
    <MemoryRouter initialEntries={['/entries?project=first']}>
      <AuthContext.Provider value={auth}>
        <QueryClientProvider client={new QueryClient()}>
          <ScopedHistory />
        </QueryClientProvider>
      </AuthContext.Provider>
    </MemoryRouter>,
  )
  await screen.findByText('First project history')
  expect(request).toHaveBeenCalledWith(
    '/api/v1/entries?topic=tree&projectId=first',
    undefined,
  )
  expect(screen.getByRole('link', { name: 'Log attempt' })).toHaveAttribute(
    'href',
    '/practice?problem=one&project=first',
  )
  await userEvent.click(screen.getByRole('link', { name: 'Switch project' }))
  await screen.findByText('Second project history')
  expect(screen.queryByText('First project history')).not.toBeInTheDocument()
  expect(request).toHaveBeenCalledWith(
    '/api/v1/entries?topic=tree&projectId=second',
    undefined,
  )
})
