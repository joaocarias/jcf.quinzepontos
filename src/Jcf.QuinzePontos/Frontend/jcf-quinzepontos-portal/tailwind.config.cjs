/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    extend: {
      fontFamily: {
        display: ['"Space Grotesk"', 'sans-serif'],
        body: ['"Inter"', 'sans-serif'],
        mono: ['"JetBrains Mono"', 'monospace'],
      },
      colors: {
        canvas: 'var(--color-canvas)',
        surface: 'var(--color-surface)',
        overlay: 'var(--color-overlay)',
        control: 'var(--color-control)',
        ink: {
          DEFAULT: 'var(--color-ink)',
          secondary: 'var(--color-ink-secondary)',
          tertiary: 'var(--color-ink-tertiary)',
          muted: 'var(--color-ink-muted)',
        },
        hairline: {
          DEFAULT: 'var(--color-hairline)',
          subtle: 'var(--color-hairline-subtle)',
          strong: 'var(--color-hairline-strong)',
        },
        selo: {
          DEFAULT: 'var(--color-selo)',
          ink: 'var(--color-selo-ink)',
          soft: 'var(--color-selo-soft)',
        },
        brass: {
          DEFAULT: 'var(--color-brass)',
          dim: 'var(--color-brass-dim)',
          soft: 'var(--color-brass-soft)',
        },
        danger: {
          DEFAULT: 'var(--color-danger)',
          soft: 'var(--color-danger-soft)',
        },
        success: {
          DEFAULT: 'var(--color-success)',
          soft: 'var(--color-success-soft)',
        },
      },
      boxShadow: {
        none: 'none',
      },
      keyframes: {
        spin: {
          to: { transform: 'rotate(360deg)' },
        },
      },
    },
  },
  plugins: [],
}
