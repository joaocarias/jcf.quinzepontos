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
        canvas: '#14121A',
        surface: '#1B1822',
        overlay: '#241F2D',
        control: '#17141D',
        ink: {
          DEFAULT: 'rgba(242, 239, 234, 0.94)',
          secondary: 'rgba(242, 239, 234, 0.68)',
          tertiary: 'rgba(242, 239, 234, 0.46)',
          muted: 'rgba(242, 239, 234, 0.28)',
        },
        hairline: {
          DEFAULT: 'rgba(255, 255, 255, 0.08)',
          subtle: 'rgba(255, 255, 255, 0.05)',
          strong: 'rgba(255, 255, 255, 0.16)',
        },
        selo: {
          DEFAULT: '#B0286F',
          ink: '#8A1F57',
          soft: 'rgba(176, 40, 111, 0.14)',
        },
        brass: {
          DEFAULT: '#C9A227',
          dim: '#8A701C',
          soft: 'rgba(201, 162, 39, 0.14)',
        },
        danger: {
          DEFAULT: '#E5484D',
          soft: 'rgba(229, 72, 77, 0.12)',
        },
        success: {
          DEFAULT: '#4CAF7D',
          soft: 'rgba(76, 175, 125, 0.12)',
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
