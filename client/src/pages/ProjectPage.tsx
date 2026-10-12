import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState, type FormEvent } from 'react'
import { Link, useParams } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'
import { EmptyState, ErrorMessage, LoadingState } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { Entry, ProjectDetail, SoftwareInput } from '../types/api'
import { formatDate } from '../utils/format'

export function ProjectPage() {
  const { projectId } = useParams()
  const { request } = useAuth()
  const detail = useQuery({
    queryKey: ['project', projectId],
    queryFn: () => request<ProjectDetail>(`/api/v1/projects/${projectId}`),
  })
  return (
    <div className="page">
      {detail.isLoading && <LoadingState />}
      {detail.isError && <ErrorMessage error={detail.error} />}
      {detail.data && (
        <ProjectWorkspace key={detail.data.project.id} detail={detail.data} />
      )}
    </div>
  )
}

function ProjectWorkspace({ detail }: { detail: ProjectDetail }) {
  const { project, modules } = detail
  const { request } = useAuth()
  const queryClient = useQueryClient()
  const [name, setName] = useState(project.name)
  const [description, setDescription] = useState(project.description ?? '')
  const invalidate = () =>
    Promise.all(
      [
        'project',
        'projects',
        'overview',
        'software-entries',
        'entries',
        'weak-topics',
        'recommendation',
      ].map((key) => queryClient.invalidateQueries({ queryKey: [key] })),
    )
  const update = useMutation({
    mutationFn: (isArchived: boolean) =>
      request(`/api/v1/projects/${project.id}`, {
        method: 'PUT',
        body: JSON.stringify({ name, description, isArchived }),
      }),
    onSuccess: invalidate,
  })
  const enrollment = useMutation({
    mutationFn: ({ key, enabled }: { key: string; enabled: boolean }) =>
      request(`/api/v1/projects/${project.id}/modules/${key}`, {
        method: 'PUT',
        body: JSON.stringify({ enabled }),
      }),
    onSuccess: invalidate,
  })
  return (
    <>
      <PageHeader
        eyebrow={project.isArchived ? 'ARCHIVED PROJECT' : 'PROJECT'}
        title={project.name}
        description={project.description || 'Build momentum with small, recorded steps.'}
        actions={
          <Link className="button button-secondary" to="/projects">
            All projects
          </Link>
        }
      />
      <details className="card project-settings">
        <summary>Project settings & modules</summary>
        <form
          className="form-card"
          onSubmit={(event: FormEvent) => {
            event.preventDefault()
            update.mutate(project.isArchived)
          }}
        >
          {update.isError && <ErrorMessage error={update.error} />}
          {update.isSuccess && <p role="status">Project saved.</p>}
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
          <div className="button-row">
            <button className="button button-primary" disabled={update.isPending}>
              Save project
            </button>
            <button
              type="button"
              className="button button-secondary"
              disabled={update.isPending}
              onClick={() => update.mutate(!project.isArchived)}
            >
              {project.isArchived ? 'Restore project' : 'Archive project'}
            </button>
          </div>
        </form>
        <h3>Enabled modules</h3>
        <p>
          Turning a module off hides its work from the overview. Your saved data stays in
          the project.
        </p>
        {enrollment.isError && <ErrorMessage error={enrollment.error} />}
        <div className="button-row">
          {[
            { key: 'software', label: 'Software projects' },
            { key: 'leetcode', label: 'Interview preparation' },
          ].map((module) => {
            const enabled = modules.some((m) => m.key === module.key && m.enabled)
            return (
              <button
                type="button"
                key={module.key}
                className="button button-secondary"
                aria-pressed={enabled}
                disabled={enrollment.isPending}
                onClick={() => enrollment.mutate({ key: module.key, enabled: !enabled })}
              >
                {enabled ? 'Disable' : 'Enable'} {module.label}
              </button>
            )
          })}
        </div>
      </details>
      {modules.some((m) => m.key === 'leetcode' && m.enabled) && (
        <section className="card">
          <h2>Interview preparation</h2>
          <p>
            Practice, review your history, and choose your next problem within this
            project.
          </p>
          <div className="button-row">
            <Link
              className="button button-primary"
              to={`/interview?project=${project.id}`}
            >
              Open interview overview
            </Link>
            <Link
              className="button button-secondary"
              to={`/practice?project=${project.id}`}
            >
              Log practice
            </Link>
          </div>
        </section>
      )}
      {modules.some((m) => m.key === 'software' && m.enabled) && (
        <SoftwareWorkspace projectId={project.id} archived={project.isArchived} />
      )}
      {!modules.some((m) => m.enabled) && (
        <EmptyState
          title="Choose a module"
          description="Enable a module in project settings to start tracking work."
        />
      )}
    </>
  )
}

function notesFor(entry: Entry) {
  try {
    return (JSON.parse(entry.data) as { notes?: string }).notes ?? ''
  } catch {
    return ''
  }
}

export function SoftwareWorkspace({
  projectId,
  archived,
}: {
  projectId: string
  archived: boolean
}) {
  const { request } = useAuth()
  const queryClient = useQueryClient()
  const entries = useQuery({
    queryKey: ['software-entries', projectId],
    queryFn: () => request<Entry[]>(`/api/v1/projects/${projectId}/software/entries`),
  })
  const [type, setType] = useState('milestone')
  const [editing, setEditing] = useState<Entry | null>(null)
  const [title, setTitle] = useState('')
  const [notes, setNotes] = useState('')
  const [dueAt, setDueAt] = useState('')
  const [status, setStatus] = useState('planned')
  const reset = () => {
    setEditing(null)
    setTitle('')
    setNotes('')
    setDueAt('')
    setStatus('planned')
  }
  const save = useMutation({
    mutationFn: (input: SoftwareInput) =>
      request<Entry>(
        `/api/v1/projects/${projectId}/software/entries/${editing?.id ?? type}`,
        {
          method: editing ? 'PUT' : 'POST',
          body: JSON.stringify(input),
        },
      ),
    onSuccess: async () => {
      reset()
      await Promise.all([
        queryClient.invalidateQueries({ queryKey: ['software-entries', projectId] }),
        queryClient.invalidateQueries({ queryKey: ['overview'] }),
      ])
    },
  })
  function edit(entry: Entry) {
    save.reset()
    setEditing(entry)
    setType(entry.entryType)
    setTitle(entry.title ?? '')
    setNotes(notesFor(entry))
    setStatus(entry.status ?? 'planned')
    if (entry.reviewDueAt) {
      const date = new Date(entry.reviewDueAt)
      setDueAt(
        new Date(date.getTime() - date.getTimezoneOffset() * 60000)
          .toISOString()
          .slice(0, 16),
      )
    } else setDueAt('')
  }
  function submit(event: FormEvent) {
    event.preventDefault()
    save.mutate({
      title,
      notes: notes.trim() || null,
      schemaVersion: 1,
      dueAt: type === 'milestone' && dueAt ? new Date(dueAt).toISOString() : null,
      status: type === 'milestone' ? status : null,
    })
  }
  return (
    <section aria-labelledby="software-heading">
      <h2 id="software-heading">Software projects</h2>
      {archived && (
        <p>This project is archived. Restore it in settings to add or edit work.</p>
      )}
      <div className="dashboard-grid">
        <div className="card">
          {entries.isLoading && <LoadingState />}
          {entries.isError && <ErrorMessage error={entries.error} />}
          {['milestone', 'dev_log'].map((kind) => (
            <section className="work-section" key={kind}>
              <h3>{kind === 'milestone' ? 'Milestones' : 'Development log'}</h3>
              {entries.data && !entries.data.some((e) => e.entryType === kind) && (
                <p>
                  {kind === 'milestone'
                    ? 'Add a milestone to define your next outcome.'
                    : 'Record a decision, progress, or what you learned.'}
                </p>
              )}
              <ul className="activity-list">
                {entries.data
                  ?.filter((e) => e.entryType === kind)
                  .map((entry) => (
                    <li key={entry.id}>
                      <strong>{entry.title}</strong>
                      <span>
                        {entry.status?.replaceAll('_', ' ')}
                        {entry.reviewDueAt
                          ? ` · Due ${formatDate(entry.reviewDueAt)}`
                          : ''}
                        {kind === 'dev_log' ? formatDate(entry.loggedAt) : ''}
                      </span>
                      <p className="entry-notes">{notesFor(entry)}</p>
                      {!archived && (
                        <button
                          type="button"
                          className="button button-secondary"
                          disabled={save.isPending}
                          onClick={() => edit(entry)}
                        >
                          Edit {kind === 'milestone' ? 'milestone' : 'log'}
                        </button>
                      )}
                    </li>
                  ))}
              </ul>
            </section>
          ))}
        </div>
        {!archived && (
          <form className="card form-card" onSubmit={submit}>
            <h3>{editing ? 'Edit work' : 'Record progress'}</h3>
            {save.isError && <ErrorMessage error={save.error} />}
            {save.isSuccess && <p role="status">Work saved.</p>}
            <label>
              Entry kind
              <select
                value={type}
                disabled={!!editing || save.isPending}
                onChange={(e) => {
                  setType(e.target.value)
                  save.reset()
                }}
              >
                <option value="milestone">Milestone</option>
                <option value="dev_log">Development log</option>
              </select>
            </label>
            <label>
              Title
              <input
                required
                maxLength={200}
                value={title}
                onChange={(e) => setTitle(e.target.value)}
              />
            </label>
            <label>
              Notes
              <textarea
                required={type === 'dev_log'}
                maxLength={20000}
                rows={5}
                value={notes}
                onChange={(e) => setNotes(e.target.value)}
              />
            </label>
            {type === 'milestone' && (
              <>
                <label>
                  Due date (optional)
                  <input
                    type="datetime-local"
                    value={dueAt}
                    onChange={(e) => setDueAt(e.target.value)}
                  />
                </label>
                <label>
                  Status
                  <select value={status} onChange={(e) => setStatus(e.target.value)}>
                    <option value="planned">Planned</option>
                    <option value="in_progress">In progress</option>
                    <option value="done">Done</option>
                  </select>
                </label>
              </>
            )}
            <button className="button button-primary" disabled={save.isPending}>
              {save.isPending
                ? 'Saving…'
                : editing
                  ? 'Save changes'
                  : type === 'milestone'
                    ? 'Add milestone'
                    : 'Add development log'}
            </button>
            {editing && (
              <button
                className="button button-secondary"
                type="button"
                disabled={save.isPending}
                onClick={reset}
              >
                Cancel edit
              </button>
            )}
          </form>
        )}
      </div>
    </section>
  )
}
