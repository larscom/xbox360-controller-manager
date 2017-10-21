<template>
  <v-layout>
    <v-flex></v-flex>
    <v-progress-circular v-if="loading" indeterminate :width="width" :size="size" color="warning"></v-progress-circular>
    <v-flex></v-flex>
  </v-layout>
</template>
<script>
  export default {
    props: {
      loading: Boolean,
      size: Number,
      width: Number
    }
  }
</script>
