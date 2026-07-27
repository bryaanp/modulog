import { useQuery } from '@tanstack/react-query'
import { ArrowRight, CalendarClock, Lightbulb, Target } from 'lucide-react'
import { Link } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'
import { EmptyState, ErrorMessage, LoadingState } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { Problem, TopicWeakness } from '../types/api'
import { formatDate, topicLabel } from '../utils/format'

export function DashboardPage() {
  const { request } = useAuth()
  const weaknesses = useQuery({
    queryKey: ['weak-topics'],
    queryFn: () => request<TopicWeakness[]>('/api/v1/insights/weak-topics'),
  })
  const recommendation = useQuery({
    queryKey: ['recommendation'],
    queryFn: () => request<Problem>('/api/v1/problems/recommend'),
    retry: false,
  })

  return (
    <div className="page">
      <PageHeader
        eyebrow="PRACTICE OVERVIEW"
        title="Make the next session count."
        description="Your recent work is translated into weak-topic signals and a practical next problem."
        actions={
          <Link className="button button-primary" to="/practice">
            Log an attempt
            <ArrowRight size={17} />
          </Link>
        }
      />

      <section className="dashboard-grid">
        <article className="card recommendation-card">
          <div className="card-heading-row">
            <div>
              <div className="eyebrow">NEXT RECOMMENDATION</div>
              <h2>A focused next move</h2>
            </div>
            <div className="card-icon">
              <Target size={21} />
            </div>
          </div>
          {recommendation.isLoading && <LoadingState label="Choosing a problem…" />}
          {recommendation.isError && (
            <EmptyState
              title="No recommendation yet"
              description="Log an attempt or expand the problem bank to create more options."
            />
          )}
          {recommendation.data && (
            <div className="recommendation-body">
              <div className="badge-list">
                <span
                  className={`difficulty difficulty-${recommendation.data.difficulty.toLowerCase()}`}
                >
                  {recommendation.data.difficulty}
                </span>
                {recommendation.data.companies.map((company) => (
                  <span className="company-badge" key={company}>
                    {company}
                  </span>
                ))}
              </div>
              <h3>{recommendation.data.title}</h3>
              <div className="tag-list">
                {recommendation.data.topicTags.map((tag) => (
                  <span className="tag" key={tag}>
                    {topicLabel(tag)}
                  </span>
                ))}
              </div>
              <div className="button-row">
                <a
                  className="button button-secondary"
                  href={recommendation.data.externalUrl}
                  target="_blank"
                  rel="noreferrer"
                >
                  Open problem
                </a>
                <Link
                  className="text-link"
                  to={`/practice?problem=${recommendation.data.id}`}
                >
                  Log this attempt <ArrowRight size={15} />
                </Link>
              </div>
            </div>
          )}
        </article>

        <article className="card">
          <div className="card-heading-row">
            <div>
              <div className="eyebrow">WEAK-TOPIC SIGNALS</div>
              <h2>Where to spend attention</h2>
            </div>
            <div className="card-icon">
              <Lightbulb size={21} />
            </div>
          </div>
          {weaknesses.isLoading && <LoadingState />}
          {weaknesses.isError && <ErrorMessage error={weaknesses.error} />}
          {weaknesses.data?.length === 0 && (
            <EmptyState
              title="No history yet"
              description="Your topic ranking appears after you log the first attempt."
            />
          )}
          <div className="weakness-list">
            {weaknesses.data?.slice(0, 5).map((weakness, index) => (
              <div className="weakness-row" key={weakness.topic}>
                <span className="rank">{String(index + 1).padStart(2, '0')}</span>
                <div className="weakness-copy">
                  <strong>{topicLabel(weakness.topic)}</strong>
                  <span>
                    {weakness.attemptCount} attempt
                    {weakness.attemptCount === 1 ? '' : 's'}
                  </span>
                </div>
                <div className="score">
                  <span>{weakness.score.toFixed(2)}</span>
                  <div>
                    <i style={{ width: `${Math.min(100, weakness.score * 50)}%` }} />
                  </div>
                </div>
              </div>
            ))}
          </div>
        </article>
      </section>

      <section className="quick-links">
        <Link className="quick-link" to="/entries">
          <CalendarClock />
          <span>
            <strong>Review your history</strong>
            <small>See the evidence behind your weak-topic ranking.</small>
          </span>
          <ArrowRight />
        </Link>
        <Link className="quick-link" to="/system-design">
          <Lightbulb />
          <span>
            <strong>Generate a system-design prompt</strong>
            <small>Use weak-topic context for an open-ended scenario.</small>
          </span>
          <ArrowRight />
        </Link>
      </section>

      {weaknesses.data?.[0] && (
        <p className="data-note">
          Latest signal: {topicLabel(weaknesses.data[0].topic)} · last attempted{' '}
          {formatDate(weaknesses.data[0].lastAttemptAt)}
        </p>
      )}
    </div>
  )
}
