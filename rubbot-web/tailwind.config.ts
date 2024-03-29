import type { Config } from 'tailwindcss'

const config: Config = {
  content: [
    './src/pages/**/*.{js,ts,jsx,tsx,mdx}',
    './src/components/**/*.{js,ts,jsx,tsx,mdx}',
    './src/app/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
      backgroundImage: {
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic':
          'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
      },
      colors: {
        'primary-bg': '#F1F1F1',
        'secondary-bg': '#FFF3DA',
        'primary-font': '#545454',
        'primary-bright': '#FAAB4E',
        'secondary-dark': '#482A25',
        'bot-message-bg': '#66564A',
      }
    },
  },
  plugins: [],
}
export default config
