<template>

  <v-app class="grey lighten-3">

    <app-header></app-header>
    <v-layout row wrap>
      <v-flex>
        <adsense adClient="ca-pub-3490692845417843" adSlot="3162154194"></adsense>
      </v-flex>
    </v-layout>


    <v-container class="mt-5">

      <v-alert v-if="error.show" class="mb-1" color="error" icon="warning" dismissible v-model="error">
        {{error.message}}
      </v-alert>

      <app-top-section></app-top-section>

      <app-middle-section></app-middle-section>

      <app-bottom-section></app-bottom-section>

    </v-container>

    <app-footer></app-footer>

  </v-app>

</template>

<script>
  import Header from '../components/Header'
  import Footer from '../components/Footer'
  import TopSection from '../components/top/TopSection'
  import MiddleSection from '../components/middle/MiddleSection'
  import BottomSection from '../components/bottom/BottomSection'
  import Adsense from '../components/Adsense'
  import eventHub from '../plugins/event-hub'

  export default {
    data: () => ({
      error: {
        show: false,
        message: null
      }
    }),
    components: {
      'app-header': Header,
      'app-footer': Footer,
      'app-top-section': TopSection,
      'app-middle-section': MiddleSection,
      'app-bottom-section': BottomSection,
      'adsense': Adsense
    },
    mounted () {
      eventHub.$on('error', (error) => {
        this.error = error
      })
    }
  }
</script>
