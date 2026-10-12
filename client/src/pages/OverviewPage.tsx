import { useQuery } from '@tanstack/react-query'
import { Link } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'
import { EmptyState, ErrorMessage, LoadingState } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { Entry, Overview } from '../types/api'
import { formatDate } from '../utils/format'

export function OverviewPage() {
  const { request } = useAuth()
  const overview = useQuery({
    queryKey: ['overview'],
    queryFn: () => request<Overview>('/api/v1/overview'),
  })
  const entryLink = (entry: Entry) =>
    entry.entryType === 'problem_attempt'
      ? `/entries?project=${entry.projectId}`
      : `/projects/${entry.projectId}`
  return (
    <div className="page">
      <PageHeader
        eyebrow="PERSONAL OVERVIEW"
        title="Keep your work moving."
        description="Your projects, next milestones, and recent progress in one place."
        actions={
          <Link className="button button-primary" to="/projects">
            Manage projects
          </Link>
        }
      />
      {overview.isLoading && <LoadingState />}
      {overview.isError && <ErrorMessage error={overview.error} />}
      {overview.data && (
        <>
          <section aria-labelledby="active-projects">
            <h2 id="active-projects">Active projects</h2>
            {!overview.data.projects.length && (
              <EmptyState
                title="Make room for your next goal"
                description="Create a project and choose the modules that support it."
              />
            )}
            <div className="project-grid">
              {overview.data.projects.map((project) => (
                <article className="card" key={project.id}>
                  <h3>
                    <Link to={`/projects/${project.id}`}>{project.name}</Link>
                  </h3>
                  <p>{project.description || 'An ongoing effort, one step at a time.'}</p>
                  {overview.data.summaries
                    .filter((s) => s.projectId === project.id)
                    .map((summary) => (
                      <div className="module-summary" key={summary.moduleKey}>
                        <strong>
                          {summary.moduleKey === 'leetcode'
                            ? 'Interview preparation'
                            : summary.moduleName}
                        </strong>
                        <span>
                          {summary.entryCount} entries
                          {summary.moduleKey === 'software'
                            ? ` · ${summary.openMilestones} open milestones`
                            : ''}
                        </span>
                      </div>
                    ))}
                </article>
              ))}
            </div>
          </section>
          <section className="dashboard-grid">
            <article className="card">
              <h2>Upcoming & overdue</h2>
              {!overview.data.upcoming.length && (
                <p>No scheduled milestones or reviews.</p>
              )}
              <ul className="activity-list">
                {overview.data.upcoming.map((entry) => (
                  <li key={entry.id}>
                    <Link to={entryLink(entry)}>{entry.title || 'Interview review'}</Link>
                    <span>
                      {entry.entryType === 'problem_attempt' ? 'Review' : 'Milestone'} ·{' '}
                      {formatDate(entry.reviewDueAt!)}
                      {new Date(entry.reviewDueAt!) < new Date() ? ' · Overdue' : ''}
                    </span>
                    <small>
                      {overview.data.projects.find((p) => p.id === entry.projectId)?.name}
                    </small>
                  </li>
                ))}
              </ul>
            </article>
            <article className="card">
              <h2>Recent activity</h2>
              {!overview.data.recent.length && <p>Your saved work will appear here.</p>}
              <ul className="activity-list">
                {overview.data.recent.map((entry) => (
                  <li key={entry.id}>
                    <Link to={entryLink(entry)}>{entry.title || 'Problem attempt'}</Link>
                    <span>
                      {entry.entryType.replaceAll('_', ' ')} ·{' '}
                      {formatDate(entry.loggedAt)}
                    </span>
                    <small>
                      {overview.data.projects.find((p) => p.id === entry.projectId)?.name}
                    </small>
                  </li>
                ))}
              </ul>
            </article>
          </section>
        </>
      )}
    </div>
  )
}
