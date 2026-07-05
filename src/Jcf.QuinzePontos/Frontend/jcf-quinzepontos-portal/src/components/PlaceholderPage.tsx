import { Seal } from './Seal'

interface PlaceholderPageProps {
  title: string
  description: string
}

export function PlaceholderPage({ title, description }: PlaceholderPageProps) {
  return (
    <div className="flex min-h-[calc(100vh-137px)] items-center justify-center">
      <div className="max-w-md rounded-lg border border-hairline bg-surface p-10 text-center">
        <Seal tone="muted" size={40} />
        <h1 className="mt-5 font-display text-xl font-semibold">{title}</h1>
        <p className="mt-2 text-sm text-ink-secondary">{description}</p>
      </div>
    </div>
  )
}
