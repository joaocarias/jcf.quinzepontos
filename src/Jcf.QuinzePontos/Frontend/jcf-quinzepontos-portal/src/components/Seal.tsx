const TICK_COUNT = 15

const TONE_STROKES: Record<'brass' | 'selo' | 'muted', string> = {
  brass: '#C9A227',
  selo: '#B0286F',
  muted: 'rgba(242, 239, 234, 0.30)',
}

interface SealProps {
  tone?: 'brass' | 'selo' | 'muted'
  size?: number
  label?: string
}

/**
 * Selo circular com 15 marcas — uma por número da Lotofácil premiada — em vez de decoração,
 * é usado como sinal de autoridade/verificação (login, distintivos de role).
 */
export function Seal({ tone = 'brass', size = 56, label }: SealProps) {
  const stroke = TONE_STROKES[tone]
  const center = 50
  const outerRadius = 46
  const tickInner = 38
  const tickOuter = 44

  const ticks = Array.from({ length: TICK_COUNT }, (_, index) => {
    const angle = (index / TICK_COUNT) * 2 * Math.PI - Math.PI / 2
    const x1 = center + tickInner * Math.cos(angle)
    const y1 = center + tickInner * Math.sin(angle)
    const x2 = center + tickOuter * Math.cos(angle)
    const y2 = center + tickOuter * Math.sin(angle)
    return { x1, y1, x2, y2, key: index }
  })

  return (
    <svg width={size} height={size} viewBox="0 0 100 100" role="img" aria-label={label ?? 'Selo JCF'}>
      <circle cx={center} cy={center} r={outerRadius} fill="none" stroke={stroke} strokeOpacity={0.9} strokeWidth={1.5} />
      <circle cx={center} cy={center} r={30} fill="none" stroke={stroke} strokeOpacity={0.35} strokeWidth={1} />
      {ticks.map((tick) => (
        <line
          key={tick.key}
          x1={tick.x1}
          y1={tick.y1}
          x2={tick.x2}
          y2={tick.y2}
          stroke={stroke}
          strokeOpacity={0.7}
          strokeWidth={1.5}
          strokeLinecap="round"
        />
      ))}
      <text
        x={center}
        y={center + 5}
        textAnchor="middle"
        fontFamily="'Space Grotesk', sans-serif"
        fontSize={20}
        fontWeight={600}
        fill={stroke}
      >
        JCF
      </text>
    </svg>
  )
}
