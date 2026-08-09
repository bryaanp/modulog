import { cleanup, render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { afterEach, describe, expect, it } from 'vitest'
import { CompanyBadges } from './CompanyBadges'

afterEach(cleanup)

describe('CompanyBadges', () => {
  it('shows three companies initially and toggles the remainder', async () => {
    const user = userEvent.setup()
    render(
      <CompanyBadges companies={['Amazon', 'Google', 'Meta', 'Microsoft', 'Uber']} />,
    )

    expect(screen.getByText('Amazon')).toBeInTheDocument()
    expect(screen.getByText('Google')).toBeInTheDocument()
    expect(screen.getByText('Meta')).toBeInTheDocument()
    expect(screen.queryByText('Microsoft')).not.toBeInTheDocument()
    expect(screen.queryByText('Uber')).not.toBeInTheDocument()

    const showMore = screen.getByRole('button', { name: '+2 more' })
    expect(showMore).toHaveAttribute('aria-expanded', 'false')
    await user.click(showMore)

    expect(screen.getByText('Microsoft')).toBeInTheDocument()
    expect(screen.getByText('Uber')).toBeInTheDocument()
    expect(screen.getByRole('button', { name: 'Show less' })).toHaveAttribute(
      'aria-expanded',
      'true',
    )

    await user.click(screen.getByRole('button', { name: 'Show less' }))
    expect(screen.queryByText('Microsoft')).not.toBeInTheDocument()
  })

  it('does not render a toggle when every company is visible', () => {
    render(<CompanyBadges companies={['Amazon', 'Google', 'Meta']} />)

    expect(screen.queryByRole('button')).not.toBeInTheDocument()
  })
})
