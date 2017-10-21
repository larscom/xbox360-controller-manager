module.exports = {
  head: {
    title: 'XBOX 360 Controller Manager',
    meta: [
      {charset: 'utf-8'},
      {name: 'viewport', content: 'width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no, minimal-ui'},
      {
        hid: 'description',
        name: 'description',
        content: 'XBOX 360 Controller Manager, turn off a wireless XBOX 360 controller for PC. Works on all versions of windows.'
      }
    ],
    link: [
      {rel: 'icon', type: 'image/x-icon', href: '/favicon.ico'},
      {rel: 'stylesheet', href: 'https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Material+Icons'}
    ]
  },
  plugins: ['~plugins/filters.js','~plugins/event-hub.js'],
  modules: [
    '@nuxtjs/vuetify'
  ],
  loading: {color: '#fdd835'},
  build: {
    vendor: ['axios'],
    extend (config, ctx) {
      if (ctx.dev && ctx.isClient) {
        config.module.rules.push({
          enforce: 'pre',
          test: /\.(js|vue)$/,
          exclude: /(node_modules)/
        })
      }
    }
  }
}
