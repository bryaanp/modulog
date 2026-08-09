import { useId, useState } from 'react'

type CompanyBadgesProps = {
  companies: string[]
  initialCount?: number
}

export function CompanyBadges({ companies, initialCount = 3 }: CompanyBadgesProps) {
  const [expanded, setExpanded] = useState(false)
  const badgeListId = useId()
  const hasOverflow = companies.length > initialCount
  const visibleCompanies = expanded ? companies : companies.slice(0, initialCount)

  return (
    <>
      <span id={badgeListId} className="company-badges">
        {visibleCompanies.map((company) => (
          <span className="company-badge" key={company}>
            {company}
          </span>
        ))}
      </span>
      {hasOverflow && (
        <button
          className="company-badge company-badge-toggle"
          type="button"
          aria-controls={badgeListId}
          aria-expanded={expanded}
          onClick={() => setExpanded((value) => !value)}
        >
          {expanded ? 'Show less' : `+${companies.length - initialCount} more`}
        </button>
      )}
    </>
  )
}
