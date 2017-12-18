module.exports = {
  head: {
    title: 'XBOX 360 Controller Manager for PC',
    meta: [
      { charset: 'utf-8' },
      {
        name: 'viewport',
        content:
          'width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no, minimal-ui'
      },
      {
        hid: 'description',
        name: 'description',
        content:
          'Turn OFF and see Battery status from up to 4 Wireless XBOX 360 Controllers connected to a PC (simultaneously). Works on almost all versions of Windows, including Windows 10!'
      },
      { property: 'og:type', content: 'article' },
      { property: 'og:title', content: 'XBOX 360 Controller Manager for PC' },
      {
        property: 'og:description',
        content:
          'Turn OFF and see Battery status from up to 4 Wireless XBOX 360 Controllers connected to a PC (simultaneously). Works on almost all versions of Windows, including Windows 10!'
      },
      {
        property: 'og:image',
        content: 'https://xbox360controller.software/favicon.ico'
      },
      { property: 'twitter:card', content: 'summary' },
      {
        property: 'twitter:title',
        content: 'XBOX 360 Controller Manager for PC'
      },
      {
        property: 'twitter:description',
        content:
          'Turn OFF and see Battery status from up to 4 Wireless XBOX 360 Controllers connected to a PC (simultaneously). Works on almost all versions of Windows, including Windows 10!'
      },
      {
        property: 'twitter:image',
        content: 'https://xbox360controller.software/favicon.ico'
      }
    ],
    link: [
      { rel: 'canonical', href: 'https://xbox360controller.software' },
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' },
      {
        rel: 'stylesheet',
        href:
          'https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Material+Icons'
      }
    ]
  },
  plugins: [
    '~plugins/filters.js',
    '~plugins/event-hub.js',
    '~plugins/analytics.js'
  ],
  modules: ['@nuxtjs/vuetify'],
  loading: { color: '#fdd835' },
  build: {
    vendor: ['axios'],
    extend(config, ctx) {
      if (ctx.dev && ctx.isClient) {
        config.module.rules.push({
          enforce: 'pre',
          test: /\.(js|vue)$/,
          exclude: /(node_modules)/
        });
      }
    }
  }
};
