import { render, screen } from '@testing-library/react'
import { describe, expect, it, vi } from 'vitest'
import { ReviewDuePicker } from './ReviewDuePicker'

describe('ReviewDuePicker', () => {
  it('renders an accessible review due input', () => {
    render(<ReviewDuePicker value={null} onChange={vi.fn()} />)

    expect(screen.getByLabelText(/review due/i)).toBeInTheDocument()
    expect(screen.getByPlaceholderText(/select date and time/i)).toBeInTheDocument()
  })
})
