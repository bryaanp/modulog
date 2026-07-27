import { Navigate, Outlet, useLocation } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'

export function ProtectedRoute() {
  const { session, isInitializing } = useAuth()
  const location = useLocation()

  if (isInitializing) {
    return (
      <main className="centered-page" aria-live="polite">
        <div className="loading-mark" />
        <p>Restoring your session…</p>
      </main>
    )
  }

  if (!session) {
    return <Navigate to="/login" state={{ from: location }} replace />
  }

  return <Outlet />
}
