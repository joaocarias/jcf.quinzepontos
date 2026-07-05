import { useState } from 'react'
import { NavLink } from 'react-router-dom'
import { useAuth } from '../lib/auth'

interface NavLinkItem {
  label: string
  path: string
  adminOnly?: boolean
}

interface NavGroupItem {
  label: string
  adminOnly?: boolean
  items: NavLinkItem[]
}

const NAV_LINKS: NavLinkItem[] = [{ label: 'Home', path: '/' }]

const NAV_GROUPS: NavGroupItem[] = [
  {
    label: 'Configurações',
    items: [{ label: 'Usuários', path: '/configuracoes/usuarios', adminOnly: true }],
  },
  {
    label: 'Sistemas',
    adminOnly: true,
    items: [
      { label: 'Coleta de Resultado', path: '/sistemas/coleta-resultado' },
      { label: 'Coleta de Estatísticas', path: '/sistemas/coleta-estatisticas' },
    ],
  },
]

function ChevronIcon({ open }: { open: boolean }) {
  return (
    <svg
      width="14"
      height="14"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      strokeWidth="2"
      strokeLinecap="round"
      strokeLinejoin="round"
      className={`transition-transform ${open ? 'rotate-90' : ''}`}
    >
      <path d="M9 6l6 6-6 6" />
    </svg>
  )
}

function linkClasses({ isActive }: { isActive: boolean }) {
  return `block rounded-md px-3 py-2 text-sm transition-colors ${
    isActive ? 'bg-overlay font-medium text-selo' : 'text-ink-secondary hover:bg-overlay hover:text-ink'
  }`
}

export function Sidebar() {
  const { session } = useAuth()
  const isAdmin = session?.roles.includes('Admin') ?? false

  const [openGroups, setOpenGroups] = useState<Record<string, boolean>>(() =>
    Object.fromEntries(NAV_GROUPS.map((group) => [group.label, true])),
  )

  function toggleGroup(label: string) {
    setOpenGroups((current) => ({ ...current, [label]: !current[label] }))
  }

  return (
    <nav className="min-h-[calc(100vh-73px)] w-60 shrink-0 border-r border-hairline bg-surface p-4">
      <ul className="space-y-1">
        {NAV_LINKS.map((link) => (
          <li key={link.path}>
            <NavLink to={link.path} end className={linkClasses}>
              {link.label}
            </NavLink>
          </li>
        ))}
      </ul>

      {NAV_GROUPS.filter((group) => !group.adminOnly || isAdmin).map((group) => {
        const items = group.items.filter((item) => !item.adminOnly || isAdmin)
        if (items.length === 0) return null

        const isOpen = openGroups[group.label]

        return (
          <div key={group.label} className="mt-4">
            <button
              type="button"
              onClick={() => toggleGroup(group.label)}
              className="flex w-full items-center justify-between rounded-md px-3 py-2 text-xs font-medium uppercase tracking-wide text-ink-tertiary transition-colors hover:text-ink-secondary"
            >
              {group.label}
              <ChevronIcon open={isOpen} />
            </button>

            {isOpen && (
              <ul className="mt-1 space-y-1">
                {items.map((item) => (
                  <li key={item.path}>
                    <NavLink to={item.path} className={linkClasses}>
                      <span className="pl-3">{item.label}</span>
                    </NavLink>
                  </li>
                ))}
              </ul>
            )}
          </div>
        )
      })}
    </nav>
  )
}
