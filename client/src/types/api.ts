export type Difficulty = 'Easy' | 'Medium' | 'Hard'

export interface TokenPair {
  accessToken: string
  refreshToken: string
  accessTokenExpiresAt: string
}

export interface RegistrationResult {
  id: string
  email: string
  emailConfirmed: boolean
}

export interface Problem {
  id: string
  title: string
  externalUrl: string
  topicTags: string[]
  companies: string[]
  difficulty: Difficulty
  createdAt: string
}

export interface ProblemInput {
  title: string
  externalUrl: string
  topicTags: string[]
  companies: string[]
  difficulty: Difficulty
}

export interface Entry {
  id: string
  userId: string
  moduleId: string
  projectId: string
  schemaVersion: number
  title: string | null
  status: string | null
  entryType: string
  data: string
  reviewDueAt: string | null
  loggedAt: string
}

export interface LeetCodeEntryData {
  problem_bank_id: string
  time_spent_minutes: number
  hints_used: number
  self_rated_confidence: number | null
  topic_tags: string[]
}

export interface EntryInput {
  problemBankId: string
  timeSpentMinutes: number
  hintsUsed: number
  selfRatedConfidence: number | null
  reviewDueAt: string | null
  notes?: string | null
}

export interface TopicWeakness {
  topic: string
  score: number
  attemptCount: number
  lastAttemptAt: string
}

export interface SystemDesignResult {
  scenario: string
  weakTopicContext: string
}

export interface Project {
  id: string
  name: string
  description: string | null
  isArchived: boolean
  isDefaultInterview: boolean
  createdAt: string
}

export interface ProjectDetail {
  project: Project
  modules: { key: string; name: string; enabled: boolean }[]
}

export interface Overview {
  projects: Project[]
  summaries: {
    projectId: string
    projectName: string
    moduleKey: string
    moduleName: string
    entryCount: number
    openMilestones: number
  }[]
  upcoming: Entry[]
  recent: Entry[]
}

export interface SoftwareInput {
  title: string
  notes: string | null
  dueAt: string | null
  status: string | null
  schemaVersion: 1
}
