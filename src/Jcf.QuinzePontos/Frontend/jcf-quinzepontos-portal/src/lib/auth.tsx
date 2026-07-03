import { createContext, useContext, useMemo, useState, type ReactNode } from 'react'
import { Navigate, useLocation } from 'react-router-dom'
import { login as loginRequest, type LoginPayload } from './api'

export interface Session {
  token: string
  expiresAt: string
  userId: string
  fullName: string
  email: string
  roles: string[]
}

const STORAGE_KEY = 'jcf-portal-session'

function readSession(): Session | null {
  const raw = localStorage.getItem(STORAGE_KEY)
  if (!raw) return null

  try {
    const session = JSON.parse(raw) as Session
    if (new Date(session.expiresAt).getTime() <= Date.now()) {
      localStorage.removeItem(STORAGE_KEY)
      return null
    }
    return session
  } catch {
    return null
  }
}

interface AuthContextValue {
  session: Session | null
  signIn: (payload: LoginPayload) => Promise<{ success: boolean; errors: string[] }>
  signOut: () => void
}

const AuthContext = createContext<AuthContextValue | null>(null)

export function AuthProvider({ children }: { children: ReactNode }) {
  const [session, setSession] = useState<Session | null>(() => readSession())

  const value = useMemo<AuthContextValue>(
    () => ({
      session,
      async signIn(payload) {
        const result = await loginRequest(payload)

        if (!result.success || !result.token || !result.expiresAt) {
          return { success: false, errors: result.errors }
        }

        const nextSession: Session = {
          token: result.token,
          expiresAt: result.expiresAt,
          userId: result.userId ?? '',
          fullName: result.fullName ?? '',
          email: result.email ?? '',
          roles: result.roles,
        }

        localStorage.setItem(STORAGE_KEY, JSON.stringify(nextSession))
        setSession(nextSession)
        return { success: true, errors: [] }
      },
      signOut() {
        localStorage.removeItem(STORAGE_KEY)
        setSession(null)
      },
    }),
    [session],
  )

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>
}

export function useAuth() {
  const context = useContext(AuthContext)
  if (!context) throw new Error('useAuth precisa estar dentro de um AuthProvider')
  return context
}

export function RequireAuth({ children }: { children: ReactNode }) {
  const { session } = useAuth()
  const location = useLocation()

  if (!session) {
    return <Navigate to="/login" replace state={{ from: location }} />
  }

  return children
}
