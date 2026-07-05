import { Seal } from './Seal'
import { RoleBadge } from './RoleBadge'
import { ThemeToggle } from './ThemeToggle'
import { useAuth } from '../lib/auth'

export function Topbar() {
  const { session, signOut } = useAuth()

  return (
    <header className="flex items-center justify-between border-b border-hairline px-8 py-4">
      <div className="flex items-center gap-3">
        <Seal tone="brass" size={32} />
        <p className="font-display text-sm font-semibold tracking-wide">JCF QUINZE PONTOS</p>
      </div>

      <div className="flex items-center gap-4">
        <div className="text-right">
          <p className="text-sm text-ink">{session?.fullName}</p>
          <p className="text-xs text-ink-tertiary">{session?.email}</p>
        </div>
        {session?.roles.map((role) => <RoleBadge key={role} role={role} />)}
        <ThemeToggle />
        <button
          type="button"
          onClick={signOut}
          className="rounded-md border border-hairline px-3 py-1.5 text-xs font-medium text-ink-secondary transition-colors hover:border-hairline-strong hover:text-ink"
        >
          Sair
        </button>
      </div>
    </header>
  )
}
