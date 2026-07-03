const API_BASE_URL = import.meta.env.VITE_API_BASE_URL

export interface LoginPayload {
  email: string
  password: string
}

export interface AuthResult {
  success: boolean
  errors: string[]
  token: string | null
  expiresAt: string | null
  userId: string | null
  fullName: string | null
  email: string | null
  roles: string[]
}

export async function login(payload: LoginPayload): Promise<AuthResult> {
  const response = await fetch(`${API_BASE_URL}/api/auth/login`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(payload),
  })

  const data = await response.json().catch(() => null)

  if (!response.ok) {
    return {
      success: false,
      errors: data?.errors ?? ['Não foi possível entrar. Tente novamente.'],
      token: null,
      expiresAt: null,
      userId: null,
      fullName: null,
      email: null,
      roles: [],
    }
  }

  return data as AuthResult
}
