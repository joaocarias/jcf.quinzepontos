import { useState, useEffect, CSSProperties } from 'react'

// ─── palette ────────────────────────────────────────────────────────────────
const C = {
  bg:        '#08031A',
  bgCard:    '#0E0528',
  purple:    '#7020C8',
  purpleL:   '#A04FE8',
  pink:      '#E91E8C',
  pinkL:     '#FF4DB8',
  gold:      '#FFD700',
  goldD:     '#CC8800',
  muted:     '#7050A0',
  lavender:  '#C8A8F0',
} as const

// ─── data ───────────────────────────────────────────────────────────────────
const DEMO_SELECTED = new Set([1, 3, 5, 7, 9, 11, 13, 16, 18, 20, 21, 22, 23, 24, 25])

const TICKER_ITEMS = [
  'CONCURSO #3042 · 01/07/2026 · 01 03 05 07 09 11 13 16 18 20 21 22 23 24 25 · PRÊMIO: R$ 1.500.000,00',
  'CONCURSO #3041 · 30/06/2026 · 02 04 06 08 10 12 14 15 17 19 20 21 22 24 25 · PRÊMIO: R$ 870.000,00',
  'CONCURSO #3040 · 28/06/2026 · 01 02 05 07 08 11 13 14 16 18 19 21 23 24 25 · ACUMULOU!!!',
  'CONCURSO #3039 · 26/06/2026 · 03 04 06 09 10 12 15 17 18 20 21 22 23 24 25 · PRÊMIO: R$ 3.200.000,00',
]

const FEATURES = [
  {
    color: C.gold,
    bg: 'rgba(255,215,0,0.1)',
    border: 'rgba(255,215,0,0.25)',
    glow: 'rgba(255,215,0,0.15)',
    icon: (
      <svg width="28" height="28" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
        <circle cx="12" cy="12" r="10"/><polyline points="12 6 12 12 16 14"/>
      </svg>
    ),
    title: 'Atualização Automática',
    desc: 'Worker dedicado busca novos resultados a cada minuto direto da API oficial da Caixa Econômica Federal. Zero atraso, máxima precisão.',
  },
  {
    color: C.pink,
    bg: 'rgba(233,30,140,0.1)',
    border: 'rgba(233,30,140,0.25)',
    glow: 'rgba(233,30,140,0.15)',
    icon: (
      <svg width="28" height="28" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
        <rect x="3" y="3" width="18" height="18" rx="2"/><line x1="3" y1="9" x2="21" y2="9"/><line x1="9" y1="21" x2="9" y2="9"/>
      </svg>
    ),
    title: 'Histórico Completo',
    desc: 'Todos os concursos desde o início da Lotofácil armazenados em PostgreSQL — dezenas, rateios e ganhadores por estado.',
  },
]

const STATS = [
  { value: '3.042', label: 'Concursos', grad: `linear-gradient(135deg, ${C.gold}, #FF8C00)` },
  { value: '45.630', label: 'Dezenas Sorteadas', grad: `linear-gradient(135deg, ${C.pink}, ${C.pinkL})` },
  { value: '< 1min', label: 'Tempo de Sync', grad: `linear-gradient(135deg, ${C.purpleL}, #C080FF)` },
  { value: '100%', label: 'Open Source', grad: 'linear-gradient(135deg, #4FE8A0, #00D4FF)' },
]

// ─── Ball ────────────────────────────────────────────────────────────────────
interface BallProps {
  n: number
  selected: boolean
  size?: number
  floatClass?: string
}

function Ball({ n, selected, size = 54, floatClass }: BallProps) {
  const s: CSSProperties = {
    width: size,
    height: size,
    borderRadius: '50%',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    position: 'relative',
    flexShrink: 0,
    cursor: 'default',
    userSelect: 'none',
    transition: 'transform 0.25s ease, box-shadow 0.25s ease',
    background: selected
      ? 'radial-gradient(circle at 36% 30%, #FFE566 0%, #FFD700 42%, #AA7000 100%)'
      : 'radial-gradient(circle at 36% 30%, #C070FF 0%, #6010B8 42%, #2E0060 100%)',
    boxShadow: selected
      ? `0 0 18px rgba(255,215,0,0.8), 0 0 36px rgba(255,215,0,0.35), 0 4px 14px rgba(0,0,0,0.5), inset 0 -4px 8px rgba(0,0,0,0.25)`
      : `0 0 8px rgba(90,0,160,0.5), 0 4px 14px rgba(0,0,0,0.5), inset 0 -4px 8px rgba(0,0,0,0.3)`,
  }

  return (
    <div className={`hover:scale-110 ${floatClass ?? ''}`} style={s}>
      {/* shine */}
      <span style={{
        position: 'absolute', top: '13%', left: '20%',
        width: '30%', height: '18%', borderRadius: '50%',
        background: 'rgba(255,255,255,0.42)', filter: 'blur(2px)',
        pointerEvents: 'none',
      }} />
      <span style={{
        fontFamily: '"Bebas Neue", sans-serif',
        fontSize: size * 0.36,
        letterSpacing: '0.02em',
        lineHeight: 1,
        color: selected ? '#3D1A00' : '#DDB8FF',
        textShadow: selected
          ? '0 1px 2px rgba(255,255,255,0.3)'
          : '0 1px 3px rgba(0,0,0,0.6)',
        zIndex: 1,
        position: 'relative',
      }}>
        {n.toString().padStart(2, '0')}
      </span>
    </div>
  )
}

// ─── Ticker ──────────────────────────────────────────────────────────────────
function Ticker() {
  const text = TICKER_ITEMS.join('   ◆   ')
  const doubled = `${text}   ◆   ${text}`
  return (
    <div style={{
      background: '#0C0430',
      borderTop: `1px solid rgba(120,40,200,0.3)`,
      borderBottom: `1px solid rgba(120,40,200,0.3)`,
      overflow: 'hidden',
      padding: '12px 0',
    }}>
      <div className="animate-ticker" style={{ display: 'flex', whiteSpace: 'nowrap', willChange: 'transform' }}>
        <span style={{
          fontFamily: '"Bebas Neue", sans-serif',
          fontSize: 14,
          letterSpacing: '0.1em',
          color: C.lavender,
          opacity: 0.8,
          paddingRight: 40,
        }}>
          {doubled}
        </span>
      </div>
    </div>
  )
}

// ─── Nav ─────────────────────────────────────────────────────────────────────
function Nav() {
  const [scrolled, setScrolled] = useState(false)
  useEffect(() => {
    const fn = () => setScrolled(window.scrollY > 20)
    window.addEventListener('scroll', fn)
    return () => window.removeEventListener('scroll', fn)
  }, [])

  return (
    <nav style={{
      position: 'sticky', top: 0, zIndex: 50,
      background: scrolled ? 'rgba(8, 3, 26, 0.92)' : 'transparent',
      backdropFilter: scrolled ? 'blur(14px)' : 'none',
      borderBottom: scrolled ? '1px solid rgba(120,40,200,0.2)' : '1px solid transparent',
      transition: 'all 0.3s ease',
    }}>
      <div style={{ maxWidth: 1280, margin: '0 auto', padding: '0 24px', height: 68, display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>

        {/* logo */}
        <div style={{ display: 'flex', alignItems: 'center', gap: 12 }}>
          <div style={{
            width: 38, height: 38, borderRadius: '50%', flexShrink: 0,
            background: 'radial-gradient(circle at 36% 30%, #FFE566, #FFD700, #AA7000)',
            boxShadow: '0 0 14px rgba(255,215,0,0.55)',
            display: 'flex', alignItems: 'center', justifyContent: 'center',
            position: 'relative',
          }}>
            <span style={{ position: 'absolute', top: '12%', left: '20%', width: '30%', height: '18%', borderRadius: '50%', background: 'rgba(255,255,255,0.4)', filter: 'blur(1px)' }} />
            <span style={{ fontFamily: '"Bebas Neue"', fontSize: 13, color: '#3D1A00', zIndex: 1, position: 'relative' }}>15</span>
          </div>
          <div style={{ fontFamily: '"Bebas Neue"', fontSize: 20, letterSpacing: '0.12em' }}>
            JCF <span style={{ color: C.gold }}>QUINZE PONTOS</span>
          </div>
        </div>

        {/* links */}
        <div style={{ display: 'flex', alignItems: 'center', gap: 32 }} className="hidden md:flex">
          {['Início', 'Resultados', 'GitHub'].map(item => (
            <a key={item} href="#"
              style={{ color: C.muted, fontSize: 14, fontWeight: 500, textDecoration: 'none', transition: 'color 0.2s' }}
              onMouseEnter={e => ((e.target as HTMLElement).style.color = '#fff')}
              onMouseLeave={e => ((e.target as HTMLElement).style.color = C.muted)}
            >
              {item}
            </a>
          ))}
          <a href={import.meta.env.VITE_PORTAL_URL} style={{
            background: `linear-gradient(135deg, ${C.purple}, #4A0898)`,
            color: '#fff', fontSize: 13, fontWeight: 700,
            padding: '9px 22px', borderRadius: 9, textDecoration: 'none',
            border: `1px solid rgba(160,79,232,0.45)`,
            boxShadow: '0 0 22px rgba(112,32,200,0.4)',
            transition: 'box-shadow 0.2s',
          }}>
            Login →
          </a>
        </div>
      </div>
    </nav>
  )
}

// ─── Hero ─────────────────────────────────────────────────────────────────────
function Hero() {
  const [mounted, setMounted] = useState(false)
  useEffect(() => { const t = setTimeout(() => setMounted(true), 60); return () => clearTimeout(t) }, [])

  const transition = (delay: number): CSSProperties => ({
    opacity: mounted ? 1 : 0,
    transform: mounted ? 'translateY(0)' : 'translateY(28px)',
    transition: `opacity 0.9s ease ${delay}ms, transform 0.9s ease ${delay}ms`,
  })

  return (
    <section style={{ position: 'relative', overflow: 'hidden', paddingTop: 80, paddingBottom: 100 }}>
      {/* background orbs */}
      <div style={{ position: 'absolute', pointerEvents: 'none', inset: 0 }}>
        <div style={{ position: 'absolute', top: '-15%', left: '-8%', width: 680, height: 680, borderRadius: '50%', background: 'radial-gradient(circle, rgba(112,32,200,0.22) 0%, transparent 68%)' }} />
        <div style={{ position: 'absolute', bottom: '-12%', right: '-5%', width: 560, height: 560, borderRadius: '50%', background: 'radial-gradient(circle, rgba(233,30,140,0.18) 0%, transparent 68%)' }} />
        <div style={{ position: 'absolute', top: '35%', right: '22%', width: 320, height: 320, borderRadius: '50%', background: 'radial-gradient(circle, rgba(255,215,0,0.07) 0%, transparent 68%)' }} />
      </div>

      <div style={{ maxWidth: 1280, margin: '0 auto', padding: '0 24px', position: 'relative', zIndex: 1 }}>
        <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: 64, alignItems: 'center' }} className="lg:grid-cols-2 grid-cols-1">

          {/* copy */}
          <div style={transition(0)}>
            <div style={{
              display: 'inline-flex', alignItems: 'center', gap: 8,
              background: 'rgba(255,215,0,0.1)', border: '1px solid rgba(255,215,0,0.3)',
              borderRadius: 999, padding: '6px 16px', marginBottom: 28,
            }}>
              <span style={{ fontSize: 12, color: C.gold, fontWeight: 700, letterSpacing: '0.1em' }}>
                🎯 RASTREADOR LOTOFÁCIL
              </span>
            </div>

            <h1 style={{ fontFamily: '"Bebas Neue"', lineHeight: 0.92, marginBottom: 28, fontSize: 'clamp(58px, 7.5vw, 104px)', letterSpacing: '0.02em' }}>
              <span style={{ display: 'block', color: '#fff' }}>QUINZE</span>
              <span style={{
                display: 'block',
                background: `linear-gradient(135deg, ${C.gold} 0%, #FF8C00 55%, ${C.gold} 100%)`,
                WebkitBackgroundClip: 'text', WebkitTextFillColor: 'transparent', backgroundClip: 'text',
              }}>NÚMEROS.</span>
              <span style={{ display: 'block', color: C.muted, fontSize: '62%' }}>INFINITAS ANÁLISES.</span>
            </h1>

            <p style={{ color: '#9870C0', fontSize: 17, lineHeight: 1.75, maxWidth: 480, marginBottom: 40 }}>
              Acompanhe todos os resultados da <strong style={{ color: '#fff' }}>Lotofácil</strong> em tempo real.
              Histórico completo desde o primeiro concurso, com
              atualização automática a cada minuto.
            </p>

            <div style={{ display: 'flex', flexWrap: 'wrap', gap: 14 }}>
              <a href="#" style={{
                background: `linear-gradient(135deg, ${C.purple}, #4A0898)`,
                color: '#fff', fontSize: 16, fontWeight: 700,
                padding: '14px 34px', borderRadius: 10, textDecoration: 'none',
                border: '1px solid rgba(160,79,232,0.4)',
                boxShadow: '0 0 32px rgba(112,32,200,0.45)',
              }}>
                Ver Resultados →
              </a>
            </div>
          </div>

          {/* ball grid card */}
          <div style={transition(200)}>
            <div className="glass" style={{ borderRadius: 22, padding: '28px 28px 24px', boxShadow: '0 24px 64px rgba(0,0,0,0.45)' }}>

              {/* card header */}
              <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: 20 }}>
                <div>
                  <div style={{ fontFamily: '"Bebas Neue"', fontSize: 11, letterSpacing: '0.2em', color: C.muted }}>ÚLTIMO CONCURSO</div>
                  <div style={{ fontFamily: '"Bebas Neue"', fontSize: 18, letterSpacing: '0.06em', color: '#fff' }}>#3042 · 01/07/2026</div>
                </div>
                <div style={{ display: 'flex', alignItems: 'center', gap: 6, background: 'rgba(233,30,140,0.15)', border: '1px solid rgba(233,30,140,0.3)', borderRadius: 999, padding: '5px 12px' }}>
                  <span style={{ width: 7, height: 7, borderRadius: '50%', background: C.pink, display: 'inline-block', animation: 'pulse 2s ease-in-out infinite' }} />
                  <span style={{ fontFamily: '"Bebas Neue"', fontSize: 11, letterSpacing: '0.15em', color: C.pink }}>AO VIVO</span>
                </div>
              </div>

              {/* 5×5 grid */}
              <div style={{ display: 'grid', gridTemplateColumns: 'repeat(5, 1fr)', gap: 8 }}>
                {Array.from({ length: 25 }, (_, i) => i + 1).map(n => (
                  <div key={n} style={{ display: 'flex', justifyContent: 'center' }}>
                    <Ball n={n} selected={DEMO_SELECTED.has(n)} size={50} />
                  </div>
                ))}
              </div>

              {/* card footer */}
              <div style={{ marginTop: 20, paddingTop: 16, borderTop: '1px solid rgba(120,40,200,0.2)', display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <div style={{ display: 'flex', alignItems: 'center', gap: 6 }}>
                  <span style={{ width: 8, height: 8, borderRadius: '50%', background: C.gold, display: 'inline-block', boxShadow: '0 0 8px rgba(255,215,0,0.7)' }} />
                  <span style={{ fontSize: 12, color: C.muted }}>15 dezenas sorteadas</span>
                </div>
                <span style={{ fontSize: 12, color: C.gold, fontWeight: 600 }}>Prêmio: R$ 1.500.000,00</span>
              </div>
            </div>
          </div>

        </div>
      </div>
    </section>
  )
}

// ─── Stats ───────────────────────────────────────────────────────────────────
function Stats() {
  return (
    <section style={{ background: 'rgba(14,5,40,0.7)', padding: '64px 0' }}>
      <div style={{ maxWidth: 1280, margin: '0 auto', padding: '0 24px' }}>
        <div style={{ display: 'grid', gridTemplateColumns: 'repeat(4, 1fr)', gap: 32 }} className="grid-cols-2 md:grid-cols-4">
          {STATS.map((s, i) => (
            <div key={i} style={{ textAlign: 'center' }}>
              <div style={{
                fontFamily: '"Bebas Neue"',
                fontSize: 'clamp(42px, 5vw, 64px)',
                letterSpacing: '0.02em',
                background: s.grad,
                WebkitBackgroundClip: 'text',
                WebkitTextFillColor: 'transparent',
                backgroundClip: 'text',
                lineHeight: 1,
                marginBottom: 8,
              }}>
                {s.value}
              </div>
              <div style={{ fontSize: 12, color: C.muted, fontWeight: 600, letterSpacing: '0.12em', textTransform: 'uppercase' }}>
                {s.label}
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
  )
}

// ─── Features ────────────────────────────────────────────────────────────────
function Features() {
  return (
    <section id="recursos" style={{ padding: '100px 0' }}>
      <div style={{ maxWidth: 1280, margin: '0 auto', padding: '0 24px' }}>

        <div style={{ textAlign: 'center', marginBottom: 64 }}>
          <h2 style={{ fontFamily: '"Bebas Neue"', fontSize: 'clamp(40px, 5.5vw, 68px)', letterSpacing: '0.04em', marginBottom: 16, lineHeight: 1 }}>
            TUDO QUE VOCÊ{' '}
            <span style={{
              background: `linear-gradient(135deg, ${C.purpleL}, ${C.pink})`,
              WebkitBackgroundClip: 'text', WebkitTextFillColor: 'transparent', backgroundClip: 'text',
            }}>PRECISA</span>
          </h2>
          <p style={{ color: C.muted, maxWidth: 480, margin: '0 auto', lineHeight: 1.75, fontSize: 16 }}>
            Uma plataforma completa para acompanhar e analisar os dados da Lotofácil.
          </p>
        </div>

        <div style={{ display: 'grid', gridTemplateColumns: 'repeat(2, 1fr)', gap: 24, maxWidth: 800, margin: '0 auto' }} className="md:grid-cols-2 grid-cols-1">
          {FEATURES.map((f, i) => (
            <div key={i}
              style={{
                background: C.bgCard, borderRadius: 20,
                border: `1px solid ${f.border}`,
                padding: '36px 32px',
                transition: 'transform 0.28s ease, box-shadow 0.28s ease',
                cursor: 'default',
              }}
              onMouseEnter={e => {
                const el = e.currentTarget as HTMLElement
                el.style.transform = 'translateY(-6px)'
                el.style.boxShadow = `0 24px 56px ${f.glow}`
              }}
              onMouseLeave={e => {
                const el = e.currentTarget as HTMLElement
                el.style.transform = 'translateY(0)'
                el.style.boxShadow = 'none'
              }}
            >
              <div style={{
                width: 60, height: 60, borderRadius: 14,
                background: f.bg, border: `1px solid ${f.border}`,
                display: 'flex', alignItems: 'center', justifyContent: 'center',
                color: f.color, marginBottom: 24,
              }}>
                {f.icon}
              </div>
              <h3 style={{ fontFamily: '"Bebas Neue"', fontSize: 22, letterSpacing: '0.05em', color: '#fff', marginBottom: 12 }}>
                {f.title}
              </h3>
              <p style={{ color: '#7050A0', lineHeight: 1.75, fontSize: 15 }}>
                {f.desc}
              </p>
            </div>
          ))}
        </div>
      </div>
    </section>
  )
}

// ─── BallShowcase ────────────────────────────────────────────────────────────
function BallShowcase() {
  const floats = ['animate-float-a', 'animate-float-b', 'animate-float-c']

  return (
    <section style={{ padding: '80px 0', background: 'rgba(10,4,30,0.6)' }}>
      <div style={{ maxWidth: 1280, margin: '0 auto', padding: '0 24px', textAlign: 'center' }}>
        <div style={{ marginBottom: 12, fontFamily: '"Bebas Neue"', fontSize: 12, letterSpacing: '0.2em', color: C.muted }}>
          DEZENAS 01 A 25
        </div>
        <h2 style={{ fontFamily: '"Bebas Neue"', fontSize: 'clamp(36px, 5vw, 60px)', letterSpacing: '0.04em', marginBottom: 10 }}>
          TODAS AS{' '}
          <span style={{
            background: `linear-gradient(135deg, ${C.gold}, #FF8C00)`,
            WebkitBackgroundClip: 'text', WebkitTextFillColor: 'transparent', backgroundClip: 'text',
          }}>POSSIBILIDADES</span>
        </h2>
        <p style={{ color: C.muted, marginBottom: 52, fontSize: 15 }}>
          Na Lotofácil você escolhe de 15 a 20 números entre 1 e 25. Nosso sistema rastreia cada combinação sorteada.
        </p>

        <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center', gap: 14 }}>
          {Array.from({ length: 25 }, (_, i) => i + 1).map(n => (
            <Ball
              key={n}
              n={n}
              selected={DEMO_SELECTED.has(n)}
              size={62}
              floatClass={floats[n % 3]}
            />
          ))}
        </div>

        <div style={{ marginTop: 40, display: 'flex', justifyContent: 'center', gap: 32, flexWrap: 'wrap' }}>
          <div style={{ display: 'flex', alignItems: 'center', gap: 8 }}>
            <div style={{ width: 24, height: 24, borderRadius: '50%', background: 'radial-gradient(circle at 36% 30%, #FFE566, #FFD700, #AA7000)', boxShadow: '0 0 10px rgba(255,215,0,0.6)' }} />
            <span style={{ fontSize: 13, color: C.muted }}>Dezenas sorteadas</span>
          </div>
          <div style={{ display: 'flex', alignItems: 'center', gap: 8 }}>
            <div style={{ width: 24, height: 24, borderRadius: '50%', background: 'radial-gradient(circle at 36% 30%, #C070FF, #6010B8, #2E0060)', boxShadow: '0 0 8px rgba(90,0,160,0.5)' }} />
            <span style={{ fontSize: 13, color: C.muted }}>Não sorteadas</span>
          </div>
        </div>
      </div>
    </section>
  )
}

// ─── CTA ─────────────────────────────────────────────────────────────────────
function CTA() {
  return (
    <section style={{ padding: '100px 0' }}>
      <div style={{ maxWidth: 860, margin: '0 auto', padding: '0 24px' }}>
        <div style={{
          position: 'relative', overflow: 'hidden', borderRadius: 28,
          background: 'linear-gradient(135deg, rgba(112,32,200,0.28), rgba(233,30,140,0.22))',
          border: '1px solid rgba(160,79,232,0.3)',
          padding: '68px 48px',
          textAlign: 'center',
        }}>
          {/* glow orb */}
          <div style={{
            position: 'absolute', top: '-45%', left: '50%', transform: 'translateX(-50%)',
            width: 480, height: 320, borderRadius: '50%',
            background: 'radial-gradient(circle, rgba(255,215,0,0.07), transparent 70%)',
            pointerEvents: 'none',
          }} />

          <div style={{ position: 'relative', zIndex: 1 }}>
            <h2 style={{ fontFamily: '"Bebas Neue"', fontSize: 'clamp(44px, 6vw, 80px)', letterSpacing: '0.04em', lineHeight: 0.95, marginBottom: 20 }}>
              COMECE{' '}
              <span style={{
                background: `linear-gradient(135deg, ${C.gold}, ${C.pink})`,
                WebkitBackgroundClip: 'text', WebkitTextFillColor: 'transparent', backgroundClip: 'text',
              }}>AGORA</span>
            </h2>
            <p style={{ color: '#9070B8', maxWidth: 420, margin: '0 auto 36px', lineHeight: 1.75, fontSize: 16 }}>
              Acompanhe os resultados da Lotofácil com histórico completo e atualização automática, gratuitamente.
            </p>
            <div style={{ display: 'flex', flexWrap: 'wrap', gap: 16, justifyContent: 'center' }}>
              <a href="#" style={{
                background: `linear-gradient(135deg, ${C.gold}, ${C.goldD})`,
                color: '#1A0A00', fontSize: 16, fontWeight: 800,
                padding: '15px 38px', borderRadius: 11, textDecoration: 'none',
                boxShadow: '0 0 32px rgba(255,215,0,0.4)',
              }}>
                Ver Resultados →
              </a>
              <a href="#" style={{
                background: 'transparent', color: C.lavender, fontSize: 16, fontWeight: 600,
                padding: '15px 32px', borderRadius: 11, textDecoration: 'none',
                border: `1px solid rgba(160,79,232,0.4)`,
              }}>
                Ver no GitHub
              </a>
            </div>
          </div>
        </div>
      </div>
    </section>
  )
}

// ─── Footer ───────────────────────────────────────────────────────────────────
function Footer() {
  return (
    <footer style={{ borderTop: '1px solid rgba(120,40,200,0.18)', padding: '40px 0' }}>
      <div style={{ maxWidth: 1280, margin: '0 auto', padding: '0 24px', display: 'flex', flexWrap: 'wrap', alignItems: 'center', justifyContent: 'space-between', gap: 16 }}>
        <div style={{ display: 'flex', alignItems: 'center', gap: 10 }}>
          <div style={{
            width: 30, height: 30, borderRadius: '50%', flexShrink: 0,
            background: 'radial-gradient(circle at 36% 30%, #FFE566, #FFD700, #AA7000)',
            boxShadow: '0 0 10px rgba(255,215,0,0.4)',
            display: 'flex', alignItems: 'center', justifyContent: 'center',
          }}>
            <span style={{ fontFamily: '"Bebas Neue"', fontSize: 10, color: '#3D1A00' }}>15</span>
          </div>
          <span style={{ fontFamily: '"Bebas Neue"', fontSize: 15, letterSpacing: '0.1em', color: '#5030A0' }}>
            JCF QUINZE PONTOS
          </span>
        </div>
        <p style={{ color: '#4A2880', fontSize: 13, margin: 0 }}>
          © 2026 · Dados fornecidos pela Caixa Econômica Federal · Projeto open source
        </p>
      </div>
    </footer>
  )
}

// ─── App ──────────────────────────────────────────────────────────────────────
export default function App() {
  return (
    <div style={{ minHeight: '100vh', background: C.bg, fontFamily: '"Plus Jakarta Sans", sans-serif', color: '#fff' }}>
      <Nav />
      <Hero />
      <Ticker />
      <Stats />
      <Features />
      <BallShowcase />
      <CTA />
      <Footer />
    </div>
  )
}
