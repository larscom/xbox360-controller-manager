<template>
  <v-toolbar dark class="blue-grey darken-4">
    <img
      @click="home()"
      width="32px"
      height="32px"
      alt="XBOX 360 Controller Manager Logo"
      src="data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTguMS4xLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iQ2FwYV8xIiB4PSIwcHgiIHk9IjBweCIgdmlld0JveD0iMCAwIDI1LjczMiAyNS43MzIiIHN0eWxlPSJlbmFibGUtYmFja2dyb3VuZDpuZXcgMCAwIDI1LjczMiAyNS43MzI7IiB4bWw6c3BhY2U9InByZXNlcnZlIiB3aWR0aD0iMjU2cHgiIGhlaWdodD0iMjU2cHgiPgo8Zz4KCTxwYXRoIGQ9Ik01LjczMywyLjE4M0M1LjcyLDIuMTkzLDUuNzEsMi4yMDQsNS42OTgsMi4yMTRjMC4wNzMtMC4wNzcsMC4xNzgtMC4xNiwwLjI0Ny0wLjIwNSAgIEM3Ljk1OSwwLjcsMTAuMjg2LDAsMTIuODY4LDBjMi40MTUsMCw0LjY3NywwLjY2Nyw2LjYwOCwxLjgyN2MwLjE0LDAuMDgzLDAuNTIyLDAuMzQ1LDAuNzE5LDAuNTgzdjAuMDAxICAgYy0xLjg2My0yLjA1NC03LjMzOSwyLjM1My03LjMzOSwyLjM1M2MtMS44OTQtMS40Ni0zLjYzNi0yLjQ1NS00LjkzMy0yLjgwOUM2LjgzOSwxLjY1OCw2LjA4OSwxLjkwNiw1LjczMywyLjE4M3ogTTIyLjMwNSw0LjEyNSAgIGMtMC4wNTctMC4wNjMtMC4xMTktMC4xMjItMC4xNzYtMC4xODdjLTAuNDcxLTAuNTE3LTEuMDUtMC42NDItMS41NzItMC42MDhjLTAuNDc1LDAuMTQ5LTIuNjcsMC45NC01LjM3NSwzLjQ5NCAgIGMwLDAsMy4wNDUsMi45NjEsNC45MSw1Ljk4OGMxLjg2MywzLjAyNywyLjk3Nyw1LjQwNiwyLjI5Miw4LjcwOGMyLjA3OS0yLjI4NSwzLjM0Ny01LjMyMSwzLjM0Ny04LjY1NSAgIEMyNS43MzEsOS40OTEsMjQuNDMyLDYuNDIsMjIuMzA1LDQuMTI1eiBNMTcuNjU3LDE0LjEwNWMtMC44MjYtMC45MjctMi4wNTUtMi4yNTUtMy42NzgtMy44NjkgICBjLTAuMzU1LTAuMzUzLTAuNzMtMC43MjEtMS4xMjQtMS4xMDJjMCwwLTAuNTkzLDAuNTkzLTEuMzY1LDEuMzczdi0wLjAwMWMtMC45ODgsMC45OTgtMi4yNjksMi4zLTIuOTgsMy4wNiAgIGMtMS4yNjYsMS4zNTEtNC44OTMsNS41OTQtNS4wOTcsNy45NzNjMCwwLTAuODA3LTEuODg3LDAuOTY0LTYuMjM5YzEuMTU3LTIuODQ1LDQuNjUzLTcuMTE3LDYuMTEzLTguNTA5ICAgYzAsMC0xLjMzNC0xLjQ2OC0zLjAwOC0yLjQ4MmwtMC4wMS0wLjAwM2MwLDAtMC4wMTktMC4wMTUtMC4wNDktMC4wMzRjLTAuODA1LTAuNDgtMS42ODQtMC44NS0yLjUzLTAuODk5ICAgQzQuMDI5LDMuNDM0LDMuNDgyLDQuMDY2LDMuNDgyLDQuMDY2Yy0yLjE1OSwyLjMwMi0zLjQ4LDUuMzk2LTMuNDgsOC44YzAsNy4xMDUsNS43NiwxMi44NjYsMTIuODY2LDEyLjg2NiAgIGMzLjc3MSwwLDcuMTY0LTEuNjI2LDkuNTE4LTQuMjExYy0wLjAwMS0wLjAwNC0wLjI3MS0xLjctMi4wMDItNC4xMzNDMTkuOTc3LDE2LjgxOCwxOC40OSwxNS4wMzksMTcuNjU3LDE0LjEwNXoiIGZpbGw9IiNGRkZGRkYiLz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8L3N2Zz4K"
    />
    <v-spacer></v-spacer>
    <span class="hidden-sm-and-down">
      <v-tooltip left>
        <img
          @click="btc()"
          slot="activator"
          src="https://en.cryptobadges.io/badge/micro/16NPW9wRi9kj69qY6pCoxN7f8yRbF3dTyT"
        />
        <span>Thanks for the support!</span>
      </v-tooltip>
    </span>
    <v-spacer></v-spacer>
    <span class="hidden-sm-and-down">
      <v-tooltip left>
        <img
          @click="ltc()"
          slot="activator"
          src="https://en.cryptobadges.io/badge/micro/LbA8HA5RbDfL5JWdVNdymsf1hpFdqTusiq"
        />
        <span>Thanks for the support!</span>
      </v-tooltip>
    </span>
    <v-spacer></v-spacer>
    <span class="hidden-sm-and-down">
      <v-tooltip left>
        <img
          @click="eth()"
          slot="activator"
          src="https://en.cryptobadges.io/badge/micro/0xc13a96f3cC66ca8586C31F04b7b78fc222c38C7F"
        />
        <span>Thanks for the support!</span>
      </v-tooltip>
    </span>
    <v-spacer></v-spacer>
    <v-tooltip left>
      <img @click="paypal()" slot="activator" src="/paypal-button.svg" />
      <span>Thanks for the support!</span>
    </v-tooltip>
  </v-toolbar>
</template>

<script>
export default {
  methods: {
    home: function() {
      window.location = "/";
    },
    btc: function() {
      window.open(
        "https://en.cryptobadges.io/donate/16NPW9wRi9kj69qY6pCoxN7f8yRbF3dTyT",
        "_blank"
      );
    },
    ltc: function() {
      window.open(
        "https://en.cryptobadges.io/donate/LbA8HA5RbDfL5JWdVNdymsf1hpFdqTusiq",
        "_blank"
      );
    },
    eth: function() {
      window.open(
        "https://en.cryptobadges.io/donate/0xc13a96f3cC66ca8586C31F04b7b78fc222c38C7F",
        "_blank"
      );
    },
    paypal: function() {
      window.open(
        "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=6MLLT5T7XDNWQ",
        "_blank"
      );
      this.$ga.event("donate", "click");
    }
  }
};
</script>
<style scoped>
.toolbar {
  position: fixed;
  z-index: 5;
}
img {
  cursor: pointer;
}
</style>
