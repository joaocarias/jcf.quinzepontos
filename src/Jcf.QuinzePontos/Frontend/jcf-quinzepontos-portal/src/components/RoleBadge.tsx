import { Seal } from './Seal'

interface RoleBadgeProps {
  role: string
}

/** Papéis lidos como faixas de acerto: Admin é o "15 pontos" (acesso pleno), Basic uma faixa mais modesta. */
export function RoleBadge({ role }: RoleBadgeProps) {
  const isAdmin = role === 'Admin'
  const tone = isAdmin ? 'brass' : 'muted'

  return (
    <span className="inline-flex items-center gap-1.5 rounded-full border border-hairline bg-overlay py-1 pl-1.5 pr-3">
      <Seal tone={tone} size={18} label={`Distintivo ${role}`} />
      <span className={`font-display text-xs font-semibold tracking-wide ${isAdmin ? 'text-brass' : 'text-ink-tertiary'}`}>
        {role}
      </span>
    </span>
  )
}
