<template>
  <v-layout row wrap>
    <v-flex>
      <v-card>
        <v-tabs dark fixed icons centered v-model="activeTab">
          <v-tabs-bar class="blue-grey darken-3">
            <v-tabs-slider class="yellow"></v-tabs-slider>
            <v-tabs-item href="#tab-comments">
              <v-icon>comment</v-icon>Comments
            </v-tabs-item>
            <v-tabs-item href="#tab-changes">
              <v-icon>history</v-icon>Changes
            </v-tabs-item>
          </v-tabs-bar>
          <v-tabs-items>
            <app-comments-tab></app-comments-tab>
            <app-changes-tab :isTabActive="activeTab === 'tab-changes'"></app-changes-tab>
          </v-tabs-items>
        </v-tabs>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import ChangesTab from "./ChangesTab";
import CommentsTab from "./CommentsTab";

export default {
  data: () => ({
    activeTab: null
  }),
  components: {
    "app-comments-tab": CommentsTab,
    "app-changes-tab": ChangesTab
  },
  mounted: function() {
    if (this.$nuxt.$route.query.changes) {
      this.activeTab = "tab-changes";
    }
  }
};
</script>
