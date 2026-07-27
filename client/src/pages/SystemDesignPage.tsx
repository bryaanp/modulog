import { useMutation } from '@tanstack/react-query'
import { BrainCircuit, Sparkles } from 'lucide-react'
import { type FormEvent, useState } from 'react'
import { useAuth } from '../auth/useAuth'
import { ErrorMessage } from '../components/Feedback'
import { PageHeader } from '../components/PageHeader'
import type { SystemDesignResult } from '../types/api'

export function SystemDesignPage() {
  const { request } = useAuth()
  const [level, setLevel] = useState('intermediate')
  const [weakTopic, setWeakTopic] = useState('')
  const generation = useMutation({
    mutationFn: () =>
      request<SystemDesignResult>('/api/v1/system-design/generate', {
        method: 'POST',
        body: JSON.stringify({
          level,
          weakTopic: weakTopic.trim() || null,
        }),
      }),
  })

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault()
    generation.mutate()
  }

  return (
    <div className="page narrow-page">
      <PageHeader
        eyebrow="OPEN-ENDED PRACTICE"
        title="System-design prompt"
        description="Ask the AI provider for a scenario informed by your weak topics. The API key stays on the server."
      />
      <section className="split-card">
        <form className="prompt-controls" onSubmit={handleSubmit}>
          <div className="card-icon card-icon-large">
            <BrainCircuit />
          </div>
          <h2>Shape the interview</h2>
          <p>Leave the topic blank to let Modulog use your current weak-topic ranking.</p>
          <label>
            Candidate level
            <select value={level} onChange={(event) => setLevel(event.target.value)}>
              <option value="beginner">Beginner</option>
              <option value="intermediate">Intermediate</option>
              <option value="advanced">Advanced</option>
            </select>
          </label>
          <label>
            Optional topic override
            <input
              placeholder="For example: caching"
              value={weakTopic}
              onChange={(event) => setWeakTopic(event.target.value)}
            />
          </label>
          <button className="button button-primary" disabled={generation.isPending}>
            <Sparkles size={17} />
            {generation.isPending ? 'Generating…' : 'Generate scenario'}
          </button>
        </form>
        <div className="prompt-result">
          {generation.isError && <ErrorMessage error={generation.error} />}
          {!generation.data && !generation.isError && (
            <div className="prompt-placeholder">
              <Sparkles />
              <h3>Your scenario will appear here</h3>
              <p>
                The provider returns requirements, constraints, and interviewer
                follow-ups—never a full solution.
              </p>
            </div>
          )}
          {generation.data && (
            <>
              <div className="eyebrow">GENERATED SCENARIO</div>
              <div className="scenario-text">{generation.data.scenario}</div>
              <p className="data-note">
                Context: {generation.data.weakTopicContext || 'general system design'}
              </p>
            </>
          )}
        </div>
      </section>
    </div>
  )
}
