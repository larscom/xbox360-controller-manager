<template>
  <v-tabs-content id="tab-changes" key="tab-changes">
    <v-card flat>
      <v-card-text>


        <v-container grid-list-lg>
          <v-layout row wrap>

            <v-flex md3 lg3 sm12 xs12>
              <v-toolbar class="blue-grey darken-1" dark>
                <v-spacer></v-spacer>
                <v-icon large color="light-green accent-3">done</v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>3</v-card-text>
              </v-card>
            </v-flex>

            <v-flex md3 lg3 sm12 xs12>
              <v-toolbar class="blue-grey darken-1" dark>
                <v-spacer></v-spacer>
                <v-icon large color="light-green accent-3">done</v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>3</v-card-text>
              </v-card>
            </v-flex>

            <v-flex md3 lg3 sm12 xs12>
              <v-toolbar class="blue-grey darken-1" dark>
                <v-spacer></v-spacer>
                <v-icon large color="light-green accent-3">done</v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>3</v-card-text>
              </v-card>
            </v-flex>

            <v-flex md3 lg3 sm12 xs12>
              <v-toolbar class="blue-grey darken-1" dark>
                <v-spacer></v-spacer>
                <v-icon large color="light-green accent-3">done</v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>3</v-card-text>
              </v-card>
            </v-flex>

            <v-flex md3 lg3 sm12 xs12>
              <v-toolbar class="blue-grey darken-1" dark>
                <v-spacer></v-spacer>
                <v-icon large color="light-green accent-3">done</v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>3</v-card-text>
              </v-card>
            </v-flex>

            <v-flex md3 lg3 sm12 xs12>
              <v-toolbar class="blue-grey darken-1" dark>
                <v-spacer></v-spacer>
                <v-icon large color="light-green accent-3">done</v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>3</v-card-text>
              </v-card>
            </v-flex>

            <v-flex md3 lg3 sm12 xs12>
              <v-toolbar class="blue-grey darken-1" dark>
                <v-spacer></v-spacer>
                <v-icon large color="light-green accent-3">done</v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>3</v-card-text>
              </v-card>
            </v-flex>

            <v-flex md3 lg3 sm12 xs12>
              <v-toolbar class="blue-grey darken-1" dark>
                <v-spacer></v-spacer>
                <v-icon large color="light-green accent-3">done</v-icon>
              </v-toolbar>
              <v-card>
                <v-card-text>3</v-card-text>
              </v-card>
            </v-flex>

          </v-layout>
        </v-container>

      </v-card-text>
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
        console.log('changes active?: ', value);
      }
    },
  }
</script>
