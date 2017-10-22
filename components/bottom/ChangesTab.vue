<template>
  <v-tabs-content id="tab-changes" key="tab-changes" class="pa-3">
    <v-card flat>
      <v-card-text>

        <app-loader :loading="loading" :size="75" :width="2"></app-loader>

        <v-container grid-list-lg v-if="!loading">
          <v-layout row wrap>

            <v-flex md3 lg3 sm12 xs12 v-for="(change, index) in changes" :key="change.version">
              <v-toolbar class="blue-grey darken-1" dark>
                <span><strong>V{{change.version}}</strong></span>
                <v-spacer></v-spacer>
                <span>{{change.date | date}}</span>
                <v-spacer></v-spacer>
                <v-icon v-if="index === 0" medium color="blue lighten-1" title="This is the latest version.">
                  new_releases
                </v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>
                  <ul>
                    <li v-for="update in change.updates">{{update.text}}</li>
                  </ul>
                </v-card-text>
              </v-card>
            </v-flex>

          </v-layout>
        </v-container>

      </v-card-text>
    </v-card>
  </v-tabs-content>
</template>

<script>
  import Loader from '../Loader'
  import axios from 'axios'
  import eventHub from '../../plugins/event-hub'

  export default {
    props: {
      isTabActive: Boolean
    },
    data: () => ({
      loading: false,
      changes: null
    }),
    components: {
      'app-loader': Loader
    },
    watch: {
      isTabActive: function (value) {
        if (!value) return
        this.$ga.event('changes', 'click')

        this.loading = true
        axios.get('https://us-central1-xbox360-controller-manager.cloudfunctions.net/changes').then(response => {
          this.changes = response.data
          this.loading = false
        }).catch(() => {
          this.loading = false
          eventHub.$emit('error', {show: true, message: 'There was an error retrieving changes.'})
        })
      }
    }
  }
</script>
