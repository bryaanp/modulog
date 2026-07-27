const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? 'http://localhost:5079'

interface ProblemDetails {
  title?: string
  detail?: string
  errors?: Record<string, string[]>
}

export class ApiError extends Error {
  readonly status: number
  readonly errors: Record<string, string[]>

  constructor(message: string, status: number, errors: Record<string, string[]> = {}) {
    super(message)
    this.name = 'ApiError'
    this.status = status
    this.errors = errors
  }
}

export async function readApiResponse<T>(response: Response): Promise<T> {
  if (response.ok) {
    if (response.status === 204) {
      return undefined as T
    }

    return (await response.json()) as T
  }

  let problem: ProblemDetails = {}
  try {
    problem = (await response.json()) as ProblemDetails
  } catch {
    // Some infrastructure errors do not return JSON. The status text is the fallback.
  }

  const validationMessage = Object.values(problem.errors ?? {}).flat()[0]
  throw new ApiError(
    validationMessage ?? problem.detail ?? problem.title ?? response.statusText,
    response.status,
    problem.errors,
  )
}

export function apiUrl(path: string) {
  return `${API_BASE_URL}${path}`
}
