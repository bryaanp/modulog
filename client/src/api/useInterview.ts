import { useSearchParams } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'

// Legacy URLs intentionally use the user's default interview project.
export function useInterview() {
  const auth = useAuth()
  const [params] = useSearchParams()
  const projectId = params.get('project')
  const link = (path: string) =>
    projectId
      ? `${path}${path.includes('?') ? '&' : '?'}project=${encodeURIComponent(projectId)}`
      : path
  const request: typeof auth.request = (path, init) =>
    auth.request(
      projectId
        ? `${path}${path.includes('?') ? '&' : '?'}projectId=${encodeURIComponent(projectId)}`
        : path,
      init,
    )
  return { request, projectId, link }
}
