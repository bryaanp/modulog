import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState, type FormEvent } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'
import { ErrorMessage, LoadingState } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { Project } from '../types/api'

export function ProjectsPage() {
  const { request } = useAuth()
  const queryClient = useQueryClient()
  const navigate = useNavigate()
  const [name, setName] = useState('')
  const [description, setDescription] = useState('')
  const [module, setModule] = useState('software')
  const projects = useQuery({
    queryKey: ['projects'],
    queryFn: () => request<Project[]>('/api/v1/projects'),
  })
  const create = useMutation({
    mutationFn: () =>
      request<Project>('/api/v1/projects', {
        method: 'POST',
        body: JSON.stringify({ name, description, modules: [module] }),
      }),
    onSuccess: async (project) => {
      await Promise.all([
        queryClient.invalidateQueries({ queryKey: ['projects'] }),
        queryClient.invalidateQueries({ queryKey: ['overview'] }),
      ])
      navigate(`/projects/${project.id}`)
    },
  })
  function submit(event: FormEvent) {
    event.preventDefault()
    create.mutate()
  }
  return (
    <div className="page">
      <PageHeader
        eyebrow="YOUR WORKSPACE"
        title="Projects"
        description="Give each goal a home, then enable the capabilities it needs."
      />
      <div className="dashboard-grid">
        <section className="card">
          <h2>Your projects</h2>
          {projects.isLoading && <LoadingState />}
          {projects.isError && <ErrorMessage error={projects.error} />}
          {projects.data?.length === 0 && <p>No projects yet. Create your first one.</p>}
          <ul className="activity-list">
            {projects.data?.map((project) => (
              <li key={project.id}>
                <Link to={`/projects/${project.id}`}>{project.name}</Link>
                <span>{project.isArchived ? 'Archived' : 'Active'}</span>
              </li>
            ))}
          </ul>
        </section>
        <form className="card form-card" onSubmit={submit}>
          <h2>Create a project</h2>
          {create.isError && <ErrorMessage error={create.error} />}
          <label>
            Project name
            <input
              required
              maxLength={160}
              value={name}
              onChange={(e) => setName(e.target.value)}
            />
          </label>
          <label>
            Description
            <textarea
              maxLength={4000}
              value={description}
              onChange={(e) => setDescription(e.target.value)}
            />
          </label>
          <label>
            Start with a module
            <select value={module} onChange={(e) => setModule(e.target.value)}>
              <option value="software">Software projects</option>
              <option value="leetcode">Interview preparation</option>
            </select>
          </label>
          <p className="data-note">You can enable both modules from the project page.</p>
          <button className="button button-primary" disabled={create.isPending}>
            {create.isPending ? 'Creating…' : 'Create project'}
          </button>
        </form>
      </div>
    </div>
  )
}
