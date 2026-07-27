import { useQuery } from '@tanstack/react-query'
import { ExternalLink, Search } from 'lucide-react'
import { useMemo, useState } from 'react'
import { Link } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'
import { EmptyState, ErrorMessage, LoadingState } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { Difficulty, Problem } from '../types/api'
import { topicLabel } from '../utils/format'

export function ProblemsPage() {
  const { request } = useAuth()
  const [search, setSearch] = useState('')
  const [topic, setTopic] = useState('')
  const [company, setCompany] = useState('')
  const [difficulty, setDifficulty] = useState<Difficulty | ''>('')
  const problems = useQuery({
    queryKey: ['problems'],
    queryFn: () => request<Problem[]>('/api/v1/problems'),
  })

  const topics = useMemo(
    () =>
      [...new Set(problems.data?.flatMap((problem) => problem.topicTags) ?? [])].sort(),
    [problems.data],
  )
  const companies = useMemo(
    () =>
      [...new Set(problems.data?.flatMap((problem) => problem.companies) ?? [])].sort(),
    [problems.data],
  )
  const filtered = useMemo(() => {
    const normalizedSearch = search.trim().toLowerCase()
    return problems.data?.filter(
      (problem) =>
        (!normalizedSearch || problem.title.toLowerCase().includes(normalizedSearch)) &&
        (!topic || problem.topicTags.includes(topic)) &&
        (!company || problem.companies.includes(company)) &&
        (!difficulty || problem.difficulty === difficulty),
    )
  }, [company, difficulty, problems.data, search, topic])

  return (
    <div className="page">
      <PageHeader
        eyebrow="CURATED CATALOG"
        title="Problem bank"
        description="Browse known problems. Modulog recommends from this catalog; it never invents LeetCode content."
      />
      <section className="filter-bar" aria-label="Problem filters">
        <label className="search-field">
          <Search size={17} />
          <input
            aria-label="Search problems"
            placeholder="Search by title"
            value={search}
            onChange={(event) => setSearch(event.target.value)}
          />
        </label>
        <select
          aria-label="Filter by topic"
          value={topic}
          onChange={(event) => setTopic(event.target.value)}
        >
          <option value="">All topics</option>
          {topics.map((value) => (
            <option key={value} value={value}>
              {topicLabel(value)}
            </option>
          ))}
        </select>
        <select
          aria-label="Filter by company"
          value={company}
          onChange={(event) => setCompany(event.target.value)}
        >
          <option value="">All companies</option>
          {companies.map((value) => (
            <option key={value} value={value}>
              {value}
            </option>
          ))}
        </select>
        <select
          aria-label="Filter by difficulty"
          value={difficulty}
          onChange={(event) => setDifficulty(event.target.value as Difficulty | '')}
        >
          <option value="">All difficulties</option>
          <option value="Easy">Easy</option>
          <option value="Medium">Medium</option>
          <option value="Hard">Hard</option>
        </select>
      </section>

      {problems.isLoading && <LoadingState label="Loading the problem bank…" />}
      {problems.isError && <ErrorMessage error={problems.error} />}
      {filtered?.length === 0 && (
        <EmptyState
          title="No matching problems"
          description="Try removing one of the filters."
        />
      )}
      <section className="problem-grid">
        {filtered?.map((problem) => (
          <article className="problem-card" key={problem.id}>
            <div className="problem-card-top">
              <div className="badge-list">
                <span
                  className={`difficulty difficulty-${problem.difficulty.toLowerCase()}`}
                >
                  {problem.difficulty}
                </span>
                {problem.companies.map((value) => (
                  <span className="company-badge" key={value}>
                    {value}
                  </span>
                ))}
              </div>
              <a
                href={problem.externalUrl}
                target="_blank"
                rel="noreferrer"
                aria-label={`Open ${problem.title}`}
              >
                <ExternalLink size={17} />
              </a>
            </div>
            <h2>{problem.title}</h2>
            <div className="tag-list">
              {problem.topicTags.map((tag) => (
                <span className="tag" key={tag}>
                  {topicLabel(tag)}
                </span>
              ))}
            </div>
            <Link className="text-link" to={`/practice?problem=${problem.id}`}>
              Log an attempt
            </Link>
          </article>
        ))}
      </section>
    </div>
  )
}
