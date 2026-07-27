import type { Entry, LeetCodeEntryData } from '../types/api'

export function formatDate(value: string) {
  return new Intl.DateTimeFormat(undefined, {
    month: 'short',
    day: 'numeric',
    year: 'numeric',
  }).format(new Date(value))
}

export function parseEntryData(entry: Entry): LeetCodeEntryData | null {
  try {
    return JSON.parse(entry.data) as LeetCodeEntryData
  } catch {
    return null
  }
}

export function topicLabel(topic: string) {
  return topic
    .split('-')
    .map((part) => part.charAt(0).toUpperCase() + part.slice(1))
    .join(' ')
}
