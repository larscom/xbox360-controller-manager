<template>
  <v-tabs-content id="tab-comments" key="tab-comments" class="pa-3">
    <v-card flat>
      <v-card-text>
        <disqus shortname="xbox360-controller-manager"
                url="https://xbox360controller.software"></disqus>
      </v-card-text>
    </v-card>
  </v-tabs-content>
</template>
<script>
  import VueDisqus from 'vue-disqus/VueDisqus.vue'

  export default {
    components: {
      'disqus': VueDisqus
    }
  }
</script>
<style scoped>

</style>
