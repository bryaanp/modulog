import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { Plus, ShieldCheck, Trash2 } from 'lucide-react'
import { type FormEvent, useState } from 'react'
import { Navigate } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'
import { ErrorMessage, LoadingState } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { Difficulty, Problem, ProblemInput } from '../types/api'

const emptyProblem: ProblemInput = {
  title: '',
  externalUrl: '',
  topicTags: [],
  difficulty: 'Easy',
}

export function AdminProblemsPage() {
  const { request, session } = useAuth()
  const queryClient = useQueryClient()
  const [form, setForm] = useState<ProblemInput>(emptyProblem)
  const [tags, setTags] = useState('')
  const problems = useQuery({
    queryKey: ['problems'],
    queryFn: () => request<Problem[]>('/api/v1/problems'),
  })
  const createProblem = useMutation({
    mutationFn: (input: ProblemInput) =>
      request<Problem>('/api/v1/problems', {
        method: 'POST',
        body: JSON.stringify(input),
      }),
    onSuccess: async () => {
      setForm(emptyProblem)
      setTags('')
      await queryClient.invalidateQueries({ queryKey: ['problems'] })
    },
  })
  const deleteProblem = useMutation({
    mutationFn: (id: string) =>
      request<void>(`/api/v1/problems/${id}`, { method: 'DELETE' }),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: ['problems'] }),
  })

  if (!session?.roles.includes('admin')) {
    return <Navigate to="/" replace />
  }

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault()
    createProblem.mutate({
      ...form,
      topicTags: tags
        .split(',')
        .map((tag) => tag.trim())
        .filter(Boolean),
    })
  }

  return (
    <div className="page">
      <PageHeader
        eyebrow="ADMINISTRATION"
        title="Manage the problem bank"
        description="Only curated problems belong here. User attempts remain separate and are never deleted with this form."
        actions={
          <span className="admin-badge">
            <ShieldCheck size={16} /> Admin access
          </span>
        }
      />
      <section className="admin-grid">
        <form className="card form-card" onSubmit={handleSubmit}>
          <div>
            <h2>Add a problem</h2>
            <p>Create a shared catalog entry that every user can discover.</p>
          </div>
          {createProblem.isError && <ErrorMessage error={createProblem.error} />}
          <label>
            Title
            <input
              value={form.title}
              onChange={(event) => setForm({ ...form, title: event.target.value })}
              required
            />
          </label>
          <label>
            LeetCode URL
            <input
              type="url"
              value={form.externalUrl}
              onChange={(event) => setForm({ ...form, externalUrl: event.target.value })}
              required
            />
          </label>
          <label>
            Topic tags
            <input
              placeholder="array, dynamic-programming"
              value={tags}
              onChange={(event) => setTags(event.target.value)}
              required
            />
            <span className="field-help">Separate tags with commas.</span>
          </label>
          <label>
            Difficulty
            <select
              value={form.difficulty}
              onChange={(event) =>
                setForm({ ...form, difficulty: event.target.value as Difficulty })
              }
            >
              <option value="Easy">Easy</option>
              <option value="Medium">Medium</option>
              <option value="Hard">Hard</option>
            </select>
          </label>
          <button className="button button-primary" disabled={createProblem.isPending}>
            <Plus size={17} />
            {createProblem.isPending ? 'Adding…' : 'Add problem'}
          </button>
        </form>

        <div className="card admin-list">
          <h2>Current catalog</h2>
          {problems.isLoading && <LoadingState />}
          {problems.isError && <ErrorMessage error={problems.error} />}
          {deleteProblem.isError && <ErrorMessage error={deleteProblem.error} />}
          {problems.data?.map((problem) => (
            <div className="admin-problem-row" key={problem.id}>
              <div>
                <strong>{problem.title}</strong>
                <span>
                  {problem.difficulty} · {problem.topicTags.join(', ')}
                </span>
              </div>
              <button
                className="icon-button danger-button"
                type="button"
                aria-label={`Delete ${problem.title}`}
                onClick={() => {
                  if (
                    window.confirm(
                      `Delete "${problem.title}" from the shared problem bank?`,
                    )
                  ) {
                    deleteProblem.mutate(problem.id)
                  }
                }}
              >
                <Trash2 size={17} />
              </button>
            </div>
          ))}
        </div>
      </section>
    </div>
  )
}
