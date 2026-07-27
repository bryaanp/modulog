import type { PropsWithChildren } from 'react'

export function AuthLayout({ children }: PropsWithChildren) {
  return (
    <main className="auth-page">
      <section className="auth-intro">
        <a className="brand brand-light" href="/">
          <span className="brand-mark">M</span>
          <span>modulog</span>
        </a>
        <div className="auth-intro-copy">
          <div className="eyebrow eyebrow-light">LEETCODE PRACTICE, WITH MEMORY</div>
          <h1>Turn every attempt into a better next decision.</h1>
          <p>
            Log the work, see where confidence is slipping, and choose the next problem
            with evidence instead of guesswork.
          </p>
        </div>
        <div className="auth-proof">
          <span>Private by default</span>
          <span>Built for deliberate practice</span>
        </div>
      </section>
      <section className="auth-form-panel">{children}</section>
    </main>
  )
}
