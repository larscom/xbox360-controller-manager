<template>
  <div>
    <img v-if="usesInternetExplorer" src="/images/ie.png" alt="Browser not Supported!" title="Browser not Supported!">
    <v-app v-if="!usesInternetExplorer" class="grey lighten-3">

      <app-header></app-header>

      <v-container class="mt-5">

        <v-alert v-if="error.show" class="mb-1" color="error" icon="warning" dismissible v-model="error">
          {{ error.message }}
        </v-alert>

        <app-top-section></app-top-section>

        <app-middle-section></app-middle-section>

        <app-bottom-section></app-bottom-section>

      </v-container>

      <app-footer></app-footer>

    </v-app>
  </div>

</template>

<script>
import Header from '../components/Header';
import Footer from '../components/Footer';
import TopSection from '../components/top/TopSection';
import MiddleSection from '../components/middle/MiddleSection';
import BottomSection from '../components/bottom/BottomSection';
import eventHub from '../plugins/event-hub';

export default {
  data: () => ({
    usesInternetExplorer: false,
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
    'app-bottom-section': BottomSection
  },
  mounted() {
    this.usesInternetExplorer = document.documentMode != null;
    eventHub.$on('error', error => {
      this.error = error;
    });
  }
};
</script>
<style scoped>
img {
  display: block;
  margin: auto;
}
</style>
