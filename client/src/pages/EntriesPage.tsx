import { useQuery } from '@tanstack/react-query'
import { CalendarDays, Clock3, Lightbulb } from 'lucide-react'
import { useMemo, useState } from 'react'
import { useAuth } from '../auth/useAuth'
import { EmptyState, ErrorMessage, LoadingState } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { Entry, Problem } from '../types/api'
import { formatDate, parseEntryData, topicLabel } from '../utils/format'

export function EntriesPage() {
  const { request } = useAuth()
  const [topic, setTopic] = useState('')
  const [from, setFrom] = useState('')
  const [to, setTo] = useState('')
  const entries = useQuery({
    queryKey: ['entries', from, to, topic],
    queryFn: () => {
      const params = new URLSearchParams()
      if (from) params.set('from', new Date(`${from}T00:00:00`).toISOString())
      if (to) params.set('to', new Date(`${to}T23:59:59`).toISOString())
      if (topic) params.set('topic', topic)
      const suffix = params.size ? `?${params}` : ''
      return request<Entry[]>(`/api/v1/entries${suffix}`)
    },
  })
  const problems = useQuery({
    queryKey: ['problems'],
    queryFn: () => request<Problem[]>('/api/v1/problems'),
  })

  const problemTitles = useMemo(
    () => new Map(problems.data?.map((problem) => [problem.id, problem.title]) ?? []),
    [problems.data],
  )
  const topics = useMemo(
    () =>
      [
        ...new Set(
          entries.data?.flatMap((entry) => parseEntryData(entry)?.topic_tags ?? []) ?? [],
        ),
      ].sort(),
    [entries.data],
  )

  return (
    <div className="page">
      <PageHeader
        eyebrow="EVIDENCE LOG"
        title="Practice history"
        description="Review what you attempted, how much help you needed, and how confident you felt."
      />
      <section className="filter-bar">
        <label>
          From
          <input
            type="date"
            value={from}
            onChange={(event) => setFrom(event.target.value)}
          />
        </label>
        <label>
          To
          <input type="date" value={to} onChange={(event) => setTo(event.target.value)} />
        </label>
        <label>
          Topic
          <select value={topic} onChange={(event) => setTopic(event.target.value)}>
            <option value="">All topics</option>
            {topics.map((value) => (
              <option key={value} value={value}>
                {topicLabel(value)}
              </option>
            ))}
          </select>
        </label>
      </section>

      {(entries.isLoading || problems.isLoading) && (
        <LoadingState label="Loading your history…" />
      )}
      {entries.isError && <ErrorMessage error={entries.error} />}
      {entries.data?.length === 0 && (
        <EmptyState
          title="No attempts found"
          description="Log an attempt or broaden the date filters."
        />
      )}
      <section className="timeline">
        {entries.data?.map((entry) => {
          const data = parseEntryData(entry)
          if (!data) return null
          return (
            <article className="timeline-item" key={entry.id}>
              <div className="timeline-dot" />
              <div className="timeline-card">
                <div className="timeline-heading">
                  <div>
                    <span className="eyebrow">{formatDate(entry.loggedAt)}</span>
                    <h2>
                      {problemTitles.get(data.problem_bank_id) ?? 'Problem attempt'}
                    </h2>
                  </div>
                  {entry.reviewDueAt && (
                    <span className="review-date">
                      <CalendarDays size={15} />
                      Review {formatDate(entry.reviewDueAt)}
                    </span>
                  )}
                </div>
                <div className="entry-metrics">
                  <span>
                    <Clock3 size={16} /> {data.time_spent_minutes} minutes
                  </span>
                  <span>
                    <Lightbulb size={16} /> {data.hints_used} hints
                  </span>
                  <span>Confidence {data.self_rated_confidence ?? '—'} / 5</span>
                </div>
                <div className="tag-list">
                  {data.topic_tags.map((tag) => (
                    <span className="tag" key={tag}>
                      {topicLabel(tag)}
                    </span>
                  ))}
                </div>
              </div>
            </article>
          )
        })}
      </section>
    </div>
  )
}
