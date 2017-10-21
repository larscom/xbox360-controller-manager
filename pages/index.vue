<template>

  <v-app class="grey lighten-3">

    <app-header></app-header>

    <v-container class="mt-5">

      <!--<v-alert v-if="error.show" class="mb-1" color="error" icon="warning" dismissible v-model="error">-->
      <!--{{error.message}}-->
      <!--</v-alert>-->

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

  export default {
    components: {
      'app-header': Header,
      'app-footer': Footer,
      'app-top-section': TopSection,
      'app-middle-section': MiddleSection,
      'app-bottom-section': BottomSection
    }
  }
</script>

<style>
  @import url('https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Material+Icons');
</style>
