import {
  BookOpen,
  BrainCircuit,
  ClipboardPlus,
  Gauge,
  History,
  LogOut,
  Menu,
  ShieldCheck,
  X,
} from 'lucide-react'
import { useState } from 'react'
import { NavLink, Outlet } from 'react-router-dom'
import { useAuth } from '../auth/useAuth'

const links = [
  { to: '/', label: 'Overview', icon: Gauge, end: true },
  { to: '/problems', label: 'Problem bank', icon: BookOpen },
  { to: '/practice', label: 'Log practice', icon: ClipboardPlus },
  { to: '/entries', label: 'History', icon: History },
  { to: '/system-design', label: 'System design', icon: BrainCircuit },
]

export function AppShell() {
  const { session, logout } = useAuth()
  const [menuOpen, setMenuOpen] = useState(false)
  const isAdmin = session?.roles.includes('admin')

  return (
    <div className="app-shell">
      <header className="mobile-header">
        <a className="brand" href="/">
          <span className="brand-mark">M</span>
          <span>modulog</span>
        </a>
        <button
          className="icon-button"
          type="button"
          aria-label={menuOpen ? 'Close navigation' : 'Open navigation'}
          onClick={() => setMenuOpen((open) => !open)}
        >
          {menuOpen ? <X /> : <Menu />}
        </button>
      </header>

      <aside className={`sidebar ${menuOpen ? 'sidebar-open' : ''}`}>
        <a className="brand desktop-brand" href="/">
          <span className="brand-mark">M</span>
          <span>modulog</span>
        </a>
        <div className="module-label">LEETCODE MODULE</div>
        <nav aria-label="Primary navigation">
          {links.map(({ to, label, icon: Icon, end }) => (
            <NavLink key={to} to={to} end={end} onClick={() => setMenuOpen(false)}>
              <Icon size={18} />
              {label}
            </NavLink>
          ))}
          {isAdmin && (
            <NavLink to="/admin/problems" onClick={() => setMenuOpen(false)}>
              <ShieldCheck size={18} />
              Admin
            </NavLink>
          )}
        </nav>
        <div className="sidebar-footer">
          <div className="user-email" title={session?.email}>
            {session?.email}
          </div>
          <button className="button button-ghost button-full" onClick={logout}>
            <LogOut size={17} />
            Sign out
          </button>
        </div>
      </aside>

      <div
        className={`sidebar-scrim ${menuOpen ? 'sidebar-scrim-visible' : ''}`}
        onClick={() => setMenuOpen(false)}
      />
      <main className="main-content">
        <Outlet />
      </main>
    </div>
  )
}
