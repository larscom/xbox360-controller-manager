<template>
  <v-tabs-content id="tab-comments" key="tab-comments">
    <v-card flat>
      <v-card-text>Comments Tab</v-card-text>
    </v-card>
  </v-tabs-content>
</template>
<script>
  export default {
    props: {
      isTabActive: Boolean
    },
    watch: {
      isTabActive: function (value) {
        if (!value) return;
        console.log('comments active?: ', value);
      }
    },
  }
</script>
