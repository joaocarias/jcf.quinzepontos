# JCF Quinze Pontos — Portal Admin — Design System

## Direction

Sala de controle de uma operação de sorteio oficial: séria, precisa, discretamente "oficial".
Não é a landing page (festiva, gradientes, Bebas Neue) — é o backstage: registro, auditoria,
controle de acesso. A marca (magenta/dourado da Lotofácil) aparece só como acento (selo, foco,
estado ativo), nunca como fundo ou decoração.

Domínio de referência: concurso, volante, esfera numerada, globo sorteador, rateio por faixa de
acerto (11 a 15 pontos), atraso, acumulado, auditoria de acesso, selo de autenticidade.

## Depth Strategy

**Borders-only.** Sem sombras. Hierarquia vem de bordas sutis (`hairline`) e pequenos saltos de
superfície (`canvas` → `surface` → `overlay`), nunca de `box-shadow`.

## Tokens (tailwind.config.cjs)

### Cores

Cada token do Tailwind aponta pra uma CSS custom property (`var(--color-x)`, definida em
`src/index.css`), nunca um hex direto — é isso que permite trocar tema sem tocar nas classes.

| Token | Valor escuro (`:root`) | Valor claro (`:root.light`) | Uso |
|---|---|---|---|
| `canvas` | `#14121A` | `#F6F3ED` | fundo base da página |
| `surface` | `#1B1822` | `#FFFFFF` | cards, painéis (nível 1) |
| `overlay` | `#241F2D` | `#EEE9DE` | dropdowns, badges (nível 2) |
| `control` | `#17141D` | `#F1ECE1` | fundo de inputs (mais "encaixado" que surface) |
| `ink` / `ink-secondary` / `ink-tertiary` / `ink-muted` | branco quente em 94%/68%/46%/28% opacidade | preto quente (`#1A140C`) em 92%/66%/46%/28% opacidade | hierarquia de texto (4 níveis, sempre usar os 4) |
| `hairline` / `hairline-subtle` / `hairline-strong` | branco em 8%/5%/16% opacidade | preto quente em 10%/6%/20% opacidade | bordas |
| `selo` / `selo-ink` / `selo-soft` | `#B0286F` / `#8A1F57` / rgba 14% | mesmos valores (já tem contraste em ambos os fundos) | magenta de marca — ações primárias, foco |
| `brass` / `brass-dim` / `brass-soft` | `#C9A227` / `#8A701C` / rgba 14% | `#8A6A10` / `#6B540F` / rgba 12% (dourado mais escuro — o tom claro não teria contraste como texto sobre fundo branco) | selo/distintivo "tier alto" (Admin) |
| `danger` / `danger-soft` | `#E5484D` / rgba 12% | `#C53137` / rgba 10% | erros |
| `success` / `success-soft` | `#4CAF7D` / rgba 12% | `#2F8F5E` / rgba 10% | confirmações |

Nunca usar hex fora dessa lista — tudo mapeia pra esses tokens. Ao adicionar um token novo, sempre
definir os dois valores (escuro e claro) em `src/index.css`, nunca só um.

## Modo claro/escuro

- **Mecanismo:** classe `light` na tag `<html>` (ausência da classe = escuro, que é o tema default
  do produto). Ver `:root` vs `:root.light` em `src/index.css`.
- **Persistência:** `localStorage["jcf-portal-theme"]`. Se não houver preferência salva, usa
  `prefers-color-scheme` do sistema.
- **Sem flash:** script inline em `index.html` (antes do CSS carregar) aplica a classe antes do
  primeiro paint.
- **Toggle:** componente `src/components/ThemeToggle.tsx` (ícone sol/lua), hook de estado em
  `src/lib/theme.ts` (`useTheme()`). Presente no canto superior direito do login e na topbar do
  dashboard, ao lado do `RoleBadge`.
- Componentes fora do Tailwind (como o stroke do `Seal` em `tone="muted"`) também usam
  `var(--color-x)` diretamente — nunca hardcodar cor ali.

### Tipografia

- **Display** (`font-display`): Space Grotesk 500/600/700 — títulos, wordmark, botões primários.
- **Body** (`font-body`, padrão do `<body>`): Inter 400/500/600/700 — texto corrido, labels, inputs.
- **Mono** (`font-mono`): JetBrains Mono — reservado pra dados tabulares (IDs, timestamps, números de concurso) quando telas de dados chegarem.

Fontes carregadas via Google Fonts no `index.html`.

### Espaçamento

Base 4px (escala padrão do Tailwind). Padding sempre simétrico (`p-8`, não `pt-8 px-6`).

### Border radius

`rounded-md` (inputs, botões) / `rounded-lg` (cards) — nada maior. Cantos discretos, não
"friendly rounded SaaS".

## Assinatura: o Selo

Componente `src/components/Seal.tsx` — círculo com **15 marcas** ao redor (uma por número da
Lotofácil premiada), não decoração: é a marca de autoridade/verificação do produto.

- Usado no login (`tone="brass"`, tamanho 56/40) como selo institucional.
- Usado em `RoleBadge` (`src/components/RoleBadge.tsx`) como distintivo de papel — lido como
  faixa de acerto: **Admin = "15 pontos" (`tone="brass"`)**, **Basic = faixa modesta
  (`tone="muted"`)**. Ao adicionar novos papéis/tiers, seguir essa lógica de "faixa de prêmio",
  não inventar outro sistema de cor.
- Usado como estado vazio/placeholder (`tone="muted"`, tamanho 40) em telas ainda não
  construídas (ver `DashboardPage`).

Reusar o componente `<Seal />` sempre que precisar desse selo — não recriar o SVG.

## Padrões de componente

### Input (texto/senha)
- `rounded-md border border-hairline bg-control px-3 py-2.5 text-sm text-ink placeholder:text-ink-muted outline-none transition-colors focus:border-selo`
- Label acima, `text-xs font-medium tracking-wide text-ink-tertiary`, maiúsculo.
- Senha: botão de mostrar/ocultar absoluto à direita (ícone olho), nunca esconder sem essa opção — é ferramenta de acesso administrativo, o operador precisa conferir o que digitou.

### Botão primário
- `rounded-md bg-selo py-2.5 font-display text-sm font-semibold tracking-wide text-white hover:bg-selo-ink disabled:opacity-60`
- Estado de loading: spinner SVG + texto ("Entrando...") — nunca só desabilitar sem feedback.

### Card de credencial/documento
- `rounded-lg border border-hairline bg-surface p-8` — usado pro card de login e pro card de estado vazio do dashboard. Reusar essa combinação para qualquer "cartão oficial" (não usar sombra).

### Topbar autenticado
- `border-b border-hairline` separando do conteúdo (nunca cor de fundo diferente) — selo pequeno (24-32px) + wordmark à esquerda, nome/e-mail + `RoleBadge` + botão "Sair" à direita.

### Padrão de tela (split login)
- Split 2 colunas em `lg:` — painel de marca à esquerda (`rings-pattern` de fundo, contexto/benefícios), formulário à direita. Em mobile, colapsa pra 1 coluna com header compacto (selo 40px + wordmark) acima do form.

## Microcopy

Tom institucional/auditoria, não "amigável SaaS": "Acesso restrito. Uso monitorado.",
"Acesso restrito a administradores autorizados." — reforça o registro/controle de acesso, não
inventar tom de boas-vindas caloroso.
