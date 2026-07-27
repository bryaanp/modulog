import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { CheckCircle2 } from 'lucide-react'
import { type FormEvent, useState } from 'react'
import { useSearchParams } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'
import { ErrorMessage, LoadingState } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { Entry, EntryInput, Problem } from '../types/api'

export function PracticePage() {
  const { request } = useAuth()
  const queryClient = useQueryClient()
  const [searchParams] = useSearchParams()
  const problems = useQuery({
    queryKey: ['problems'],
    queryFn: () => request<Problem[]>('/api/v1/problems'),
  })
  const [problemId, setProblemId] = useState(searchParams.get('problem') ?? '')
  const [minutes, setMinutes] = useState(30)
  const [hints, setHints] = useState(0)
  const [confidence, setConfidence] = useState<number | ''>('')
  const [reviewDueAt, setReviewDueAt] = useState('')

  const createEntry = useMutation({
    mutationFn: (input: EntryInput) =>
      request<Entry>('/api/v1/entries', {
        method: 'POST',
        body: JSON.stringify(input),
      }),
    onSuccess: async () => {
      await Promise.all([
        queryClient.invalidateQueries({ queryKey: ['entries'] }),
        queryClient.invalidateQueries({ queryKey: ['weak-topics'] }),
        queryClient.invalidateQueries({ queryKey: ['recommendation'] }),
      ])
    },
  })

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault()
    createEntry.mutate({
      problemBankId: problemId,
      timeSpentMinutes: minutes,
      hintsUsed: hints,
      selfRatedConfidence: confidence === '' ? null : confidence,
      reviewDueAt: reviewDueAt ? new Date(reviewDueAt).toISOString() : null,
    })
  }

  return (
    <div className="page narrow-page">
      <PageHeader
        eyebrow="CAPTURE THE ATTEMPT"
        title="Log practice"
        description="Record effort and confidence while the details are fresh. Topic tags are copied from the problem automatically."
      />
      {problems.isLoading && <LoadingState />}
      {problems.isError && <ErrorMessage error={problems.error} />}
      {problems.data && (
        <form className="card form-card" onSubmit={handleSubmit}>
          {createEntry.isError && <ErrorMessage error={createEntry.error} />}
          {createEntry.isSuccess && (
            <div className="feedback feedback-success" role="status">
              <CheckCircle2 size={18} />
              Attempt saved. Your insights and recommendation have been recalculated.
            </div>
          )}
          <label>
            Problem
            <select
              value={problemId}
              onChange={(event) => setProblemId(event.target.value)}
              required
            >
              <option value="">Choose a problem</option>
              {problems.data.map((problem) => (
                <option key={problem.id} value={problem.id}>
                  {problem.title} · {problem.difficulty}
                  {problem.companies.length > 0
                    ? ` · ${problem.companies.join(', ')}`
                    : ''}
                </option>
              ))}
            </select>
          </label>
          <div className="form-grid">
            <label>
              Time spent (minutes)
              <input
                type="number"
                min="1"
                value={minutes}
                onChange={(event) => setMinutes(event.target.valueAsNumber)}
                required
              />
            </label>
            <label>
              Hints used
              <input
                type="number"
                min="0"
                value={hints}
                onChange={(event) => setHints(event.target.valueAsNumber)}
                required
              />
            </label>
          </div>
          <label>
            Self-rated confidence
            <select
              value={confidence}
              onChange={(event) =>
                setConfidence(event.target.value ? Number(event.target.value) : '')
              }
            >
              <option value="">Not rated</option>
              <option value="1">1 · Could not reproduce</option>
              <option value="2">2 · Needed major help</option>
              <option value="3">3 · Partial understanding</option>
              <option value="4">4 · Mostly comfortable</option>
              <option value="5">5 · Can explain and reproduce</option>
            </select>
          </label>
          <label>
            Review due
            <input
              type="datetime-local"
              value={reviewDueAt}
              onChange={(event) => setReviewDueAt(event.target.value)}
            />
            <span className="field-help">
              Optional. An overdue review increases the weakness signal.
            </span>
          </label>
          <button className="button button-primary" disabled={createEntry.isPending}>
            {createEntry.isPending ? 'Saving attempt…' : 'Save attempt'}
          </button>
        </form>
      )}
    </div>
  )
}
