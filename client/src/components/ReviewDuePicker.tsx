import { useId } from 'react'

type ReviewDuePickerProps = {
  value: string | null
  onChange: (value: string | null) => void
}

export function ReviewDuePicker({ value, onChange }: ReviewDuePickerProps) {
  const inputId = useId()

  return (
    <div>
      <label htmlFor={inputId}>Review due</label>
      <input
        id={inputId}
        type="datetime-local"
        value={value ?? ''}
        onChange={(event) => onChange(event.target.value || null)}
        placeholder="Select date and time"
      />
      <span className="field-help">
        Optional. An overdue review increases the weakness signal.
      </span>
    </div>
  )
}
