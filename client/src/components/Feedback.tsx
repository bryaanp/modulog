import { AlertCircle, Inbox } from 'lucide-react'
import { ApiError } from '../api/http'

export function ErrorMessage({ error }: { error: unknown }) {
  const message =
    error instanceof ApiError || error instanceof Error
      ? error.message
      : 'Something went wrong.'

  return (
    <div className="feedback feedback-error" role="alert">
      <AlertCircle size={18} />
      <span>{message}</span>
    </div>
  )
}

export function EmptyState({
  title,
  description,
}: {
  title: string
  description: string
}) {
  return (
    <div className="empty-state">
      <Inbox size={28} />
      <h3>{title}</h3>
      <p>{description}</p>
    </div>
  )
}

export function LoadingState({ label = 'Loading…' }: { label?: string }) {
  return (
    <div className="loading-state" aria-live="polite">
      <div className="loading-mark" />
      <span>{label}</span>
    </div>
  )
}
