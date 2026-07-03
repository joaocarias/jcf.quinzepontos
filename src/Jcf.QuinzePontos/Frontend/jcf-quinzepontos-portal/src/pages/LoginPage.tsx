import { useState, type FormEvent } from 'react'
import { Navigate, useLocation, useNavigate, type Location } from 'react-router-dom'
import { Seal } from '../components/Seal'
import { useAuth } from '../lib/auth'

interface LocationState {
  from?: Location
}

function EyeIcon({ open }: { open: boolean }) {
  if (open) {
    return (
      <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="1.75">
        <path d="M1 12s4-7 11-7 11 7 11 7-4 7-11 7-11-7-11-7Z" />
        <circle cx="12" cy="12" r="3" />
      </svg>
    )
  }
  return (
    <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="1.75">
      <path d="M3 3l18 18" />
      <path d="M10.6 5.2A11.6 11.6 0 0 1 12 5c7 0 11 7 11 7a13.9 13.9 0 0 1-3.4 4.1M6.5 6.6C3.4 8.4 1 12 1 12s4 7 11 7a10.7 10.7 0 0 0 4.2-.9" />
      <path d="M9.5 9.7A3 3 0 0 0 12 15a3 3 0 0 0 2.3-1.1" />
    </svg>
  )
}

function Spinner() {
  return (
    <svg className="animate-spin" width="16" height="16" viewBox="0 0 24 24" fill="none">
      <circle cx="12" cy="12" r="9" stroke="currentColor" strokeOpacity="0.25" strokeWidth="3" />
      <path d="M21 12a9 9 0 0 0-9-9" stroke="currentColor" strokeWidth="3" strokeLinecap="round" />
    </svg>
  )
}

export default function LoginPage() {
  const { session, signIn } = useAuth()
  const navigate = useNavigate()
  const location = useLocation()

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [showPassword, setShowPassword] = useState(false)
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  if (session) {
    const redirectTo = (location.state as LocationState)?.from?.pathname ?? '/'
    return <Navigate to={redirectTo} replace />
  }

  async function handleSubmit(event: FormEvent) {
    event.preventDefault()
    setError(null)
    setLoading(true)

    try {
      const result = await signIn({ email, password })

      if (!result.success) {
        setError(result.errors[0] ?? 'Não foi possível entrar. Verifique suas credenciais.')
        return
      }

      const redirectTo = (location.state as LocationState)?.from?.pathname ?? '/'
      navigate(redirectTo, { replace: true })
    } catch {
      setError('Não foi possível entrar. Tente novamente.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="grid min-h-screen font-body text-ink lg:grid-cols-2">
      <aside className="rings-pattern relative hidden flex-col justify-between overflow-hidden border-r border-hairline bg-canvas p-14 lg:flex">
        <div className="flex items-center gap-4">
          <Seal tone="brass" size={56} />
          <div>
            <p className="font-display text-lg font-semibold tracking-wide">JCF QUINZE PONTOS</p>
            <p className="text-sm text-ink-secondary">Painel administrativo</p>
          </div>
        </div>

        <div className="max-w-sm space-y-5">
          <p className="font-display text-2xl leading-snug text-ink">
            Registro oficial de concursos, usuários e acessos da operação.
          </p>
          <ul className="space-y-3 text-sm text-ink-secondary">
            <li className="flex items-center gap-3">
              <span className="h-1.5 w-1.5 rounded-full bg-brass" />
              Acompanhamento de concursos e estatísticas por número
            </li>
            <li className="flex items-center gap-3">
              <span className="h-1.5 w-1.5 rounded-full bg-brass" />
              Controle de usuários e níveis de acesso
            </li>
            <li className="flex items-center gap-3">
              <span className="h-1.5 w-1.5 rounded-full bg-brass" />
              Auditoria de quem criou e alterou cada registro
            </li>
          </ul>
        </div>

        <p className="text-xs text-ink-muted">Acesso restrito. Uso monitorado.</p>
      </aside>

      <main className="flex items-center justify-center bg-canvas p-6">
        <div className="w-full max-w-sm">
          <div className="mb-8 flex items-center gap-3 lg:hidden">
            <Seal tone="brass" size={40} />
            <div>
              <p className="font-display text-base font-semibold tracking-wide">JCF QUINZE PONTOS</p>
              <p className="text-xs text-ink-secondary">Painel administrativo</p>
            </div>
          </div>

          <div className="rounded-lg border border-hairline bg-surface p-8">
            <h1 className="font-display text-2xl font-semibold text-ink">Acesso administrativo</h1>
            <p className="mt-1.5 text-sm text-ink-secondary">Entre com suas credenciais para continuar.</p>

            <form className="mt-7 space-y-5" onSubmit={handleSubmit} noValidate>
              <div className="space-y-1.5">
                <label htmlFor="email" className="text-xs font-medium tracking-wide text-ink-tertiary">
                  E-MAIL
                </label>
                <input
                  id="email"
                  type="email"
                  autoComplete="username"
                  required
                  value={email}
                  onChange={(event) => setEmail(event.target.value)}
                  placeholder="seu.email@jcfquinzepontos.com.br"
                  className="w-full rounded-md border border-hairline bg-control px-3 py-2.5 text-sm text-ink placeholder:text-ink-muted outline-none transition-colors focus:border-selo"
                />
              </div>

              <div className="space-y-1.5">
                <label htmlFor="password" className="text-xs font-medium tracking-wide text-ink-tertiary">
                  SENHA
                </label>
                <div className="relative">
                  <input
                    id="password"
                    type={showPassword ? 'text' : 'password'}
                    autoComplete="current-password"
                    required
                    value={password}
                    onChange={(event) => setPassword(event.target.value)}
                    placeholder="••••••••"
                    className="w-full rounded-md border border-hairline bg-control px-3 py-2.5 pr-10 text-sm text-ink placeholder:text-ink-muted outline-none transition-colors focus:border-selo"
                  />
                  <button
                    type="button"
                    onClick={() => setShowPassword((value) => !value)}
                    aria-label={showPassword ? 'Ocultar senha' : 'Mostrar senha'}
                    className="absolute inset-y-0 right-0 flex items-center pr-3 text-ink-muted transition-colors hover:text-ink-secondary"
                  >
                    <EyeIcon open={showPassword} />
                  </button>
                </div>
              </div>

              {error && (
                <div role="alert" className="rounded-md border border-danger/30 bg-danger-soft px-3 py-2.5 text-sm text-danger">
                  {error}
                </div>
              )}

              <button
                type="submit"
                disabled={loading}
                className="flex w-full items-center justify-center gap-2 rounded-md bg-selo py-2.5 font-display text-sm font-semibold tracking-wide text-white transition-colors hover:bg-selo-ink disabled:cursor-not-allowed disabled:opacity-60"
              >
                {loading ? (
                  <>
                    <Spinner />
                    Entrando...
                  </>
                ) : (
                  'Entrar'
                )}
              </button>
            </form>
          </div>

          <p className="mt-6 text-center text-xs text-ink-muted">Acesso restrito a administradores autorizados.</p>
        </div>
      </main>
    </div>
  )
}
