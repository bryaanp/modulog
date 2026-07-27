import { Navigate, Route, Routes } from 'react-router-dom'
import { AppShell } from './components/AppShell'
import { ProtectedRoute } from './components/ProtectedRoute'
import { AdminProblemsPage } from './pages/AdminProblemsPage'
import { DashboardPage } from './pages/DashboardPage'
import { EntriesPage } from './pages/EntriesPage'
import { LoginPage } from './pages/LoginPage'
import { PracticePage } from './pages/PracticePage'
import { ProblemsPage } from './pages/ProblemsPage'
import { RegisterPage } from './pages/RegisterPage'
import { SystemDesignPage } from './pages/SystemDesignPage'

export default function App() {
  return (
    <Routes>
      <Route path="/login" element={<LoginPage />} />
      <Route path="/register" element={<RegisterPage />} />
      <Route element={<ProtectedRoute />}>
        <Route element={<AppShell />}>
          <Route index element={<DashboardPage />} />
          <Route path="problems" element={<ProblemsPage />} />
          <Route path="practice" element={<PracticePage />} />
          <Route path="entries" element={<EntriesPage />} />
          <Route path="system-design" element={<SystemDesignPage />} />
          <Route path="admin/problems" element={<AdminProblemsPage />} />
        </Route>
      </Route>
      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  )
}
