import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { render, screen, waitFor } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter, Route, Routes } from 'react-router-dom'
import { describe, expect, it, vi } from 'vitest'
import { AuthContext, type AuthContextValue } from '../auth/context'
import type { Entry, Project, SoftwareInput } from '../types/api'
import { ProjectsPage } from './ProjectsPage'
import { ProjectPage } from './ProjectPage'

describe('Project workflow', () => {
  it('creates a project, completes a milestone, and records a development log', async () => {
    const user = userEvent.setup()
    let project: Project | undefined
    const entries: Entry[] = []
    const writes: SoftwareInput[] = []
    const request: AuthContextValue['request'] = async <T,>(
      path: string,
      init?: RequestInit,
    ) => {
      const input = init?.body ? JSON.parse(init.body as string) : undefined
      if (path === '/api/v1/projects' && init?.method === 'POST') {
        expect(input.modules).toEqual(['software'])
        project = {
          id: 'project-1',
          name: input.name,
          description: input.description,
          isArchived: false,
          isDefaultInterview: false,
          createdAt: new Date().toISOString(),
        }
        return project as T
      }
      if (path === '/api/v1/projects') return [] as T
      if (path === '/api/v1/projects/project-1')
        return {
          project,
          modules: [{ key: 'software', name: 'Software projects', enabled: true }],
        } as T
      if (path === '/api/v1/projects/project-1/software/entries') return [...entries] as T
      if (path.startsWith('/api/v1/projects/project-1/software/entries/')) {
        writes.push(input)
        const entry: Entry = {
          id: init?.method === 'PUT' ? 'entry-1' : `entry-${entries.length + 1}`,
          projectId: 'project-1',
          userId: 'user-1',
          moduleId: 'software',
          entryType: path.endsWith('dev_log') ? 'dev_log' : 'milestone',
          schemaVersion: input.schemaVersion,
          title: input.title,
          status: input.status,
          reviewDueAt: input.dueAt,
          data: JSON.stringify({ notes: input.notes }),
          loggedAt: new Date().toISOString(),
        }
        if (init?.method === 'PUT') entries[0] = entry
        else entries.push(entry)
        return entry as T
      }
      throw new Error(`Unexpected request: ${path}`)
    }
    const auth: AuthContextValue = {
      request,
      session: null,
      isInitializing: false,
      login: vi.fn(),
      register: vi.fn(),
      logout: vi.fn(),
    }
    const queryClient = new QueryClient({
      defaultOptions: { queries: { retry: false }, mutations: { retry: false } },
    })
    render(
      <MemoryRouter initialEntries={['/projects']}>
        <AuthContext.Provider value={auth}>
          <QueryClientProvider client={queryClient}>
            <Routes>
              <Route path="/projects" element={<ProjectsPage />} />
              <Route path="/projects/:projectId" element={<ProjectPage />} />
            </Routes>
          </QueryClientProvider>
        </AuthContext.Provider>
      </MemoryRouter>,
    )
    await user.type(screen.getByLabelText('Project name'), 'Launch a tool')
    await user.click(screen.getByRole('button', { name: 'Create project' }))
    await screen.findByRole('heading', { name: 'Launch a tool' })
    await user.type(screen.getByLabelText('Title'), 'First release')
    await user.type(screen.getByLabelText('Notes'), 'Core workflow')
    await user.click(screen.getByRole('button', { name: 'Add milestone' }))
    await screen.findByText('First release')
    await user.click(screen.getByRole('button', { name: 'Edit milestone' }))
    await user.selectOptions(screen.getByLabelText('Status'), 'done')
    await user.click(screen.getByRole('button', { name: 'Save changes' }))
    await screen.findByText('done')
    await user.selectOptions(screen.getByLabelText('Entry kind'), 'dev_log')
    await user.type(screen.getByLabelText('Title'), 'What I learned')
    await user.type(screen.getByLabelText('Notes'), 'Small steps help')
    await user.click(screen.getByRole('button', { name: 'Add development log' }))
    await screen.findByText('What I learned')
    await waitFor(() => expect(screen.getByLabelText('Title')).toHaveValue(''))
    expect(writes).toEqual([
      {
        title: 'First release',
        notes: 'Core workflow',
        schemaVersion: 1,
        dueAt: null,
        status: 'planned',
      },
      {
        title: 'First release',
        notes: 'Core workflow',
        schemaVersion: 1,
        dueAt: null,
        status: 'done',
      },
      {
        title: 'What I learned',
        notes: 'Small steps help',
        schemaVersion: 1,
        dueAt: null,
        status: null,
      },
    ])
  })
})
