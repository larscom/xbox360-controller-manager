<template>
  <v-layout class="mb-2" row wrap>
    <v-flex>
      <v-card>
        <v-card-title primary-title class="card-title mb-3">
          <div>
            <h1 class="mb-1 headline">XBOX 360 Controller Manager</h1>
            <h1
              class="mb-5 subheading"
            >Turn off multiple wireless XBOX 360 controllers simultaneously and see the battery status of each controller.</h1>
          </div>
        </v-card-title>

        <v-card-text class="mb-4">
          <v-layout row wrap>
            <v-flex md3 lg3 sm12 xs12 v-for="icon in icons" :key="icon.description" text-xs-center>
              <v-tooltip top>
                <img slot="activator" :src="icon.src">
                <span class="ml-2" slot="activator">{{icon.description}}</span>
                <span>{{icon.tooltip}}</span>
              </v-tooltip>
            </v-flex>
          </v-layout>
        </v-card-text>

        <v-flex xs12 class="span-height" text-xs-center>
          <v-btn
            round
            large
            :loading="loading"
            @click.native="download()"
            :disabled="loading"
            class="yellow darken-1 mt-3"
          >Download
            <v-icon right>cloud_download</v-icon>
            <span slot="loader" class="download-loader">
              <v-icon light>cached</v-icon>
            </span>
          </v-btn>
        </v-flex>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import axios from "axios";
import eventHub from "../../plugins/event-hub";

export default {
  data: () => ({
    loading: false,
    icons: [
      {
        description: "Windows 10",
        src:
          "data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTkuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iTGF5ZXJfMSIgeD0iMHB4IiB5PSIwcHgiIHZpZXdCb3g9IjAgMCA0OTcuODg2IDQ5Ny44ODYiIHN0eWxlPSJlbmFibGUtYmFja2dyb3VuZDpuZXcgMCAwIDQ5Ny44ODYgNDk3Ljg4NjsiIHhtbDpzcGFjZT0icHJlc2VydmUiIHdpZHRoPSI1MTJweCIgaGVpZ2h0PSI1MTJweCI+CjxnPgoJPGc+CgkJPGc+CgkJCTxwb2x5Z29uIHBvaW50cz0iMjI3Ljk1OSwzOS44NjkgMjI3Ljk1OSwyNDIuMzg2IDQ5Ni41NDksMjQyLjM4NiA0OTYuNTQ5LDAgICAgIiBmaWxsPSIjMDAwMDAwIi8+CgkJCTxwb2x5Z29uIHBvaW50cz0iMS4zMzYsMjQ0Ljc0NiAyMTEuMTcyLDI0NC43NDYgMjExLjE3Miw0MS44MTggMS4zMzYsNzIuNzk4ICAgICIgZmlsbD0iIzAwMDAwMCIvPgoJCQk8cG9seWdvbiBwb2ludHM9IjIyNy45NTksNDU4LjAxNyA0OTYuNTQ5LDQ5Ny44ODYgNDk2LjU0OSwyNjEuNTM1IDIyNy45NTksMjYxLjUzNSAgICAiIGZpbGw9IiMwMDAwMDAiLz4KCQkJPHBvbHlnb24gcG9pbnRzPSIxLjMzNiw0MjUuMDg2IDIxMS4xNzIsNDU2LjA2NiAyMTEuMTcyLDI2MS41MzEgMS4zMzYsMjYxLjUzMSAgICAiIGZpbGw9IiMwMDAwMDAiLz4KCQk8L2c+Cgk8L2c+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPC9zdmc+Cg==",
        tooltip: "Supports any version of Windows 10!"
      },
      {
        description: "4 Controllers",
        src:
          "data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTYuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iQ2FwYV8xIiB4PSIwcHgiIHk9IjBweCIgd2lkdGg9IjUxMnB4IiBoZWlnaHQ9IjUxMnB4IiB2aWV3Qm94PSIwIDAgNTc1LjI4NyA1NzUuMjg3IiBzdHlsZT0iZW5hYmxlLWJhY2tncm91bmQ6bmV3IDAgMCA1NzUuMjg3IDU3NS4yODc7IiB4bWw6c3BhY2U9InByZXNlcnZlIj4KPGc+Cgk8Zz4KCQk8cGF0aCBkPSJNMzUyLjk1LDMyNC4xMzhjLTE2LjgwNiwwLTMwLjQ3MiwxMy42NzItMzAuNDcyLDMwLjQ3OHMxMy42NjYsMzAuNDc4LDMwLjQ3MiwzMC40NzhzMzAuNDc4LTEzLjY3MiwzMC40NzgtMzAuNDc4ICAgIEMzODMuNDI4LDMzNy44MTEsMzY5Ljc1NiwzMjQuMTM4LDM1Mi45NSwzMjQuMTM4eiIgZmlsbD0iIzAwMDAwMCIvPgoJCTxjaXJjbGUgY3g9IjQwNS40MjMiIGN5PSIyNjUuMzY4IiByPSIxOC4wMTciIGZpbGw9IiMwMDAwMDAiLz4KCQk8cGF0aCBkPSJNMzEzLjUzNywyNjAuNDk3YzAtOC4xNDYtMy43NzYtMTUuMzQ5LTkuNTg0LTIwLjIwOGMtMy40ODIsMS42NDYtOS4yNDcsNC40LTkuODExLDcuNDZjMCwwLDE1LjI2NCwxNC44NDcsMTQuMjA1LDI4LjMzICAgIEMzMTEuNTczLDI3MS42OTYsMzEzLjUzNywyNjYuMzQxLDMxMy41MzcsMjYwLjQ5N3oiIGZpbGw9IiMwMDAwMDAiLz4KCQk8cGF0aCBkPSJNMjg2LjgzLDI1NC4zNTJjLTEzLjU3NCwxMC40ODMtMTcuODIxLDE5LjI0OC0xOS4xNDksMjQuMDAyYzQuODQxLDUuMjUxLDExLjcxMyw4LjYwNSwxOS40LDguNjA1ICAgIGM3LjQ4NSwwLDE0LjIxLTMuMTUyLDE5LjAyNy04LjE1OEMzMDQuOTIsMjc0LjE1NiwzMDAuODI2LDI2NS4xNiwyODYuODMsMjU0LjM1MnoiIGZpbGw9IiMwMDAwMDAiLz4KCQk8cGF0aCBkPSJNMjc5LjUxNiwyNDcuNzQ5Yy0wLjUzOS0yLjk2OC01Ljk5MS01LjY0OC05LjQ5OC03LjMxM2MtNS43MDQsNC44NTktOS40LDExLjk5NS05LjQsMjAuMDU1ICAgIGMwLDUuNTYzLDEuNzM4LDEwLjcxLDQuNjgyLDE0Ljk3NkMyNjQuNzM2LDI2Mi4xNDksMjc5LjUxNiwyNDcuNzQ5LDI3OS41MTYsMjQ3Ljc0OXoiIGZpbGw9IiMwMDAwMDAiLz4KCQk8cGF0aCBkPSJNMjk4LjcyMSwyMzYuODU1Yy0zLjUzMS0xLjc0NC03LjQ0MS0yLjgxNS0xMS42NC0yLjgxNWMtNC4xOTIsMC04LjEwOSwxLjA3MS0xMS42MzQsMi44MTUgICAgYzYuMjY3LDAuMzM2LDEwLjM5OCwzLjAxMSwxMS4zODMsMy43MjFDMjg3Ljg0NiwyMzkuODQxLDI5Mi4xNzksMjM3LjA2OSwyOTguNzIxLDIzNi44NTV6IiBmaWxsPSIjMDAwMDAwIi8+CgkJPGNpcmNsZSBjeD0iNDQ3LjcxMiIgY3k9IjIyMy4wNzkiIHI9IjE4LjAxNyIgZmlsbD0iIzAwMDAwMCIvPgoJCTxjaXJjbGUgY3g9IjQ0Ny43MTIiIGN5PSIzMDcuNjU3IiByPSIxOC4wMTciIGZpbGw9IiMwMDAwMDAiLz4KCQk8cGF0aCBkPSJNMTIzLjQ5MywyMjMuNjI0Yy0xNi44MDUsMC0zMC40NzgsMTMuNjcyLTMwLjQ3OCwzMC40NzhzMTMuNjcyLDMwLjQ3OCwzMC40NzgsMzAuNDc4ICAgIGMxNi44MDYsMCwzMC40NzgtMTMuNjcyLDMwLjQ3OC0zMC40NzhTMTQwLjI5OCwyMjMuNjI0LDEyMy40OTMsMjIzLjYyNHoiIGZpbGw9IiMwMDAwMDAiLz4KCQk8cGF0aCBkPSJNMzg3LjkyLDE2NC4wMjdjLTI2LjEzMywyNi4xMjYtMTAwLjI3NiwyMy41Mi0xMDAuMjc2LDIzLjUycy03NC4xNDQsMi42MTMtMTAwLjI3Ni0yMy41MiAgICBjLTI2LjEzMi0yNi4xMzItMTA2LjQ3Ni0yLjI4OS0xMjguMzYxLDMzLjk2NlMtOC45MzIsMzUwLjg1MiwxLjUyMSw0NjUuMTc0QzExLjk3NCw1NzkuNDksNjUuNTM3LDU0Mi45MSwxMDkuMzA3LDUwNi45OCAgICBjNDMuNzcxLTM1LjkzMSw1OC4xNC02Ny4yODQsMTc4LjMzNy02Ny4yODRjMTIwLjE5NywwLDEzNC41NjYsMzEuMzU0LDE3OC4zMzcsNjcuMjg0YzQzLjc2NCwzNS45Myw5Ny4zMzIsNzIuNTEsMTA3Ljc4NS00MS44MDYgICAgYzEwLjQ1My0xMTQuMzIyLTM1LjYtMjMwLjkyNi01Ny40ODUtMjY3LjE4MUM0OTQuMzk2LDE2MS43MzgsNDE0LjA0NiwxMzcuODk1LDM4Ny45MiwxNjQuMDI3eiBNNDQ3LjcxMiwxOTguOTQxICAgIGMxMy4zMTIsMCwyNC4xMzgsMTAuODI3LDI0LjEzOCwyNC4xMzdjMCwxMy4zMTEtMTAuODI2LDI0LjEzOC0yNC4xMzgsMjQuMTM4Yy0xMy4zMTEsMC0yNC4xMzctMTAuODI3LTI0LjEzNy0yNC4xMzggICAgQzQyMy41NzUsMjA5Ljc2OCw0MzQuNDAxLDE5OC45NDEsNDQ3LjcxMiwxOTguOTQxeiBNMjk0LjM2OSwyMjAuMDg2YzAuMDQzLDAuMDA2LDAuMzk4LDAuMDc5LDAuNDQsMC4wODUgICAgYzE2LjYyMiwzLjE0NiwyOS44MTEsMTYuNTE4LDMyLjcyNSwzMy4yNzRjMC4yOTMsMS42NjUtMC44MjYsMy4yNS0yLjQ4NSwzLjUzOGMtMC4xNzgsMC4wMzctMC4zNTQsMC4wNDktMC41MzIsMC4wNDkgICAgYy0xLjQ1NywwLTIuNzQ4LTEuMDQ2LTMuMDA1LTIuNTM0Yy0yLjQ3OS0xNC4yNTMtMTMuNzAzLTI1LjYzNy0yNy45MjYtMjguMzNjLTEuNjU4LTAuMzEyLTIuOS0xLjkyOC0yLjYwMS0zLjU4NiAgICBDMjkxLjI4NSwyMjAuOTI1LDI5Mi42OTIsMjE5LjgyMywyOTQuMzY5LDIyMC4wODZ6IE0yNDYuNzE5LDI1Mi45MjZjMy4xODgtMTYuODQyLDE2LjYxNi0zMC4wMzcsMzMuNDI3LTMyLjkwNyAgICBjMS42NjUtMC4yODgsMy4yNDQsMC44MzgsMy41MzEsMi41MDNjMC4yODIsMS42NjUtMC44MzgsMy4yNDQtMi41MDMsMy41MzFjLTE0LjMwMywyLjQzNi0yNS43MjksMTMuNjY2LTI4LjQzNCwyNy45MzggICAgYy0wLjI4MiwxLjQ4MS0xLjU5NywyLjU5NS0zLjA1NCwyLjU5NWMtMC4xNzEsMC0wLjM1NS0wLjAxOS0wLjUyNi0wLjA1NWMtMS42NTktMC4zMDYtMi43NzItMS43OTMtMi40NzMtMy40NTJsMy4wMTEsMC41NTEgICAgTDI0Ni43MTksMjUyLjkyNnogTTgwLjc2OSwyNTQuMTA3YzAtMjMuNTU2LDE5LjE2OC00Mi43MTgsNDIuNzE4LTQyLjcxOHM0Mi43MTgsMTkuMTY4LDQyLjcxOCw0Mi43MTggICAgcy0xOS4xNjgsNDIuNzE3LTQyLjcxOCw0Mi43MTdTODAuNzY5LDI3Ny42NTcsODAuNzY5LDI1NC4xMDd6IE0yMDYuNjk0LDQxNi41MzljLTI5LjU3OCwwLTUzLjY0OC0yNC4wNjQtNTMuNjQ4LTUzLjY0OCAgICBjMC0yOS41NzgsMjQuMDY0LTUzLjY0Nyw1My42NDgtNTMuNjQ3czUzLjY0OCwyNC4wNjMsNTMuNjQ4LDUzLjY0N1MyMzYuMjcyLDQxNi41MzksMjA2LjY5NCw0MTYuNTM5eiBNMjgwLjEyMiwzMDAuOTA3ICAgIGMtMC4xNjUsMC0wLjMzNi0wLjAxMi0wLjUwMi0wLjA0M2wtMC4xMS0wLjAxOGMtMTYuODc5LTMuMTg5LTMwLjA4Ni0xNi42NjUtMzIuOTI2LTMzLjUzMmMtMC4yODItMS42NjUsMC44NDUtMy4yNDQsMi41MDktMy41MjUgICAgYzEuNjY1LTAuMjY5LDMuMjQ0LDAuODQ1LDMuNTI1LDIuNTA5YzIuNDE3LDE0LjM1MiwxMy42NDgsMjUuODE0LDI3Ljk1NiwyOC41MmMxLjY1MywwLjMxMiwyLjc5MSwxLjkwMywyLjQ5NywzLjU0OSAgICBDMjgyLjgxNSwyOTkuODU0LDI4MS41NjYsMzAwLjkwNywyODAuMTIyLDMwMC45MDd6IE0yODcuMDgxLDI5My4wOGMtMTcuOTY4LDAtMzIuNTgzLTE0LjYyMS0zMi41ODMtMzIuNTgzICAgIGMwLTE3Ljk2MiwxNC42MjEtMzIuNTc3LDMyLjU4My0zMi41NzdzMzIuNTc3LDE0LjYxNCwzMi41NzcsMzIuNTc3QzMxOS42NTcsMjc4LjQ1OCwzMDUuMDQ5LDI5My4wOCwyODcuMDgxLDI5My4wOHogICAgIE0yOTMuMjgsMzAxLjA0N2MtMS40NjksMC0yLjc2Ny0xLjA2NC0zLjAxMi0yLjU1OGMtMC4yNzUtMS42NjUsMC44NTItMy4yNDQsMi41MTYtMy41MiAgICBjMTQuNDA2LTIuMzg3LDI1LjkwNi0xMy42MjMsMjguNjIzLTI3Ljk2OGMwLjMxMi0xLjY0NiwxLjkyOC0yLjkxMywzLjU4LTIuNjYyYzEuNjUzLDAuMywyLjc5NywxLjY1MiwyLjUyMSwzLjMwNSAgICBjLTAuMDA2LDAuMDQ5LTAuMDk4LDAuNTI2LTAuMTA5LDAuNTc2Yy0zLjE3MSwxNi43NzUtMTYuNjg5LDI5Ljk4Ny0zMy42MTEsMzIuNzg0ICAgIEMyOTMuNjE2LDMwMS4wMzYsMjkzLjQ0NSwzMDEuMDQ3LDI5My4yOCwzMDEuMDQ3eiBNMzUyLjk1LDM5Ny4zMzljLTIzLjU1NiwwLTQyLjcxMi0xOS4xNjctNDIuNzEyLTQyLjcxNyAgICBzMTkuMTYyLTQyLjcxOCw0Mi43MTItNDIuNzE4czQyLjcxOCwxOS4xNjgsNDIuNzE4LDQyLjcxOFMzNzYuNTA2LDM5Ny4zMzksMzUyLjk1LDM5Ny4zMzl6IE00MDUuNDIzLDI4OS41MDUgICAgYy0xMy4zMTEsMC0yNC4xMzctMTAuODI2LTI0LjEzNy0yNC4xMzdzMTAuODMyLTI0LjEzNywyNC4xMzctMjQuMTM3czI0LjEzOCwxMC44MjYsMjQuMTM4LDI0LjEzNyAgICBTNDE4LjczNCwyODkuNTA1LDQwNS40MjMsMjg5LjUwNXogTTQ0Ny43MTIsMzMxLjc5NGMtMTMuMzExLDAtMjQuMTM3LTEwLjgyNi0yNC4xMzctMjQuMTM3YzAtMTMuMzEyLDEwLjgzMi0yNC4xMzgsMjQuMTM3LTI0LjEzOCAgICBzMjQuMTM4LDEwLjgyNiwyNC4xMzgsMjQuMTM4QzQ3MS44NSwzMjAuOTY4LDQ2MS4wMjMsMzMxLjc5NCw0NDcuNzEyLDMzMS43OTR6IE00OTAuMDAxLDI4OS41MDUgICAgYy0xMy4zMTEsMC0yNC4xMzctMTAuODI2LTI0LjEzNy0yNC4xMzdzMTAuODI2LTI0LjEzNywyNC4xMzctMjQuMTM3YzEzLjMxMiwwLDI0LjEzOCwxMC44MjYsMjQuMTM4LDI0LjEzNyAgICBTNTAzLjMxMiwyODkuNTA1LDQ5MC4wMDEsMjg5LjUwNXoiIGZpbGw9IiMwMDAwMDAiLz4KCQk8Y2lyY2xlIGN4PSI0OTAuMDAxIiBjeT0iMjY1LjM2OCIgcj0iMTguMDE3IiBmaWxsPSIjMDAwMDAwIi8+CgkJPHBhdGggZD0iTTIwNi42OTQsMzE1LjM2OWMtMjYuMjA2LDAtNDcuNTI4LDIxLjMyMi00Ny41MjgsNDcuNTI3YzAsMjYuMjA2LDIxLjMxNiw0Ny41MjgsNDcuNTI4LDQ3LjUyOCAgICBjMjYuMjA2LDAsNDcuNTI4LTIxLjMyMiw0Ny41MjgtNDcuNTI4QzI1NC4yMjIsMzM2LjY4NCwyMzIuOSwzMTUuMzY5LDIwNi42OTQsMzE1LjM2OXogTTE5MS4zODgsMzkyLjczOHYzLjM5MSAgICBjLTcuOTAxLTMuNjU0LTE0LjI3OC0xMC4wMjUtMTcuOTMyLTE3LjkzMmgzLjM5MWgzLjYwNGMyLjY1Niw0LjUyOCw2LjQwMiw4LjI4LDEwLjkzNywxMC45M1YzOTIuNzM4eiBNMTkxLjM4OCwzMzMuMDQ5djMuNjA0ICAgIGMtNC41MjksMi42NTYtOC4yOCw2LjQwMS0xMC45MzcsMTAuOTM3aC0zLjYwNGgtMy4zOTFjMy42NTQtNy45MDEsMTAuMDI0LTE0LjI3OCwxNy45MzItMTcuOTMyVjMzMy4wNDl6IE0yMjEuOTk0LDM5Ni4xMjh2LTMuMzk3ICAgIHYtMy42MDRjNC41MjktMi42NTYsOC4yODEtNi40MDEsMTAuOTM3LTEwLjkzaDMuNTk5aDMuMzk2QzIzNi4yNzIsMzg2LjA5NywyMjkuODk1LDM5Mi40NzQsMjIxLjk5NCwzOTYuMTI4eiBNMjM2LjUzNiwzNDcuNTkgICAgaC0zLjYwNWMtMi42NTYtNC41MjktNi40MDEtOC4yOC0xMC45MzctMTAuOTM3di0zLjYwNHYtMy4zOTFjNy45MDcsMy42NTMsMTQuMjc4LDEwLjAzLDE3LjkzMiwxNy45MzJIMjM2LjUzNnoiIGZpbGw9IiMwMDAwMDAiLz4KCQk8Y2lyY2xlIGN4PSIyODYuODMiIGN5PSIxMzQuMjI5IiByPSIxOC43NTIiIGZpbGw9IiMwMDAwMDAiLz4KCQk8cGF0aCBkPSJNMzI0LjQ5MiwxMjYuMTY4YzAsNi43NTcsNS40ODMsMTIuMjQsMTIuMjQsMTIuMjRjNi43NTYsMCwxMi4yMzktNS40ODMsMTIuMjM5LTEyLjI0ICAgIGMwLTI5LjM0NS0yNy44NzYtNTMuMjEzLTYyLjEzNi01My4yMTNzLTYyLjEzNywyMy44NjgtNjIuMTM3LDUzLjIxM2MwLDYuNzU3LDUuNDg0LDEyLjI0LDEyLjI0LDEyLjI0czEyLjI0LTUuNDgzLDEyLjI0LTEyLjI0ICAgIGMwLTE1Ljg0NSwxNi44OTctMjguNzMzLDM3LjY1Ny0yOC43MzNDMzA3LjU5NSw5Ny40MzUsMzI0LjQ5MiwxMTAuMzMsMzI0LjQ5MiwxMjYuMTY4eiIgZmlsbD0iIzAwMDAwMCIvPgoJCTxwYXRoIGQ9Ik0zNzguNTQ0LDEzMi42NDRjNi43NTcsMCwxMi4yNC01LjQ4MywxMi4yNC0xMi4yNGMwLTQ4LjI3NS00Ni42MjktODcuNTUzLTEwMy45NDgtODcuNTUzICAgIGMtNTcuMzIsMC0xMDMuOTU1LDM5LjI3OC0xMDMuOTU1LDg3LjU1M2MwLDYuNzU2LDUuNDgzLDEyLjI0LDEyLjI0LDEyLjI0YzYuNzU2LDAsMTIuMjQtNS40ODMsMTIuMjQtMTIuMjQgICAgYzAtMzQuNzgsMzUuNjQ5LTYzLjA3Myw3OS40NjgtNjMuMDczYzQzLjgxOSwwLDc5LjQ2OCwyOC4yOTIsNzkuNDY4LDYzLjA3M0MzNjYuMzA0LDEyNy4xNjcsMzcxLjc4MSwxMzIuNjQ0LDM3OC41NDQsMTMyLjY0NHoiIGZpbGw9IiMwMDAwMDAiLz4KCTwvZz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8L3N2Zz4K",
        tooltip: "Turn OFF up to 4 connected controllers simultaneously"
      },
      {
        description: "Battery Status",
        src:
          "data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTkuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iQ2FwYV8xIiB4PSIwcHgiIHk9IjBweCIgdmlld0JveD0iMCAwIDYwIDYwIiBzdHlsZT0iZW5hYmxlLWJhY2tncm91bmQ6bmV3IDAgMCA2MCA2MDsiIHhtbDpzcGFjZT0icHJlc2VydmUiIHdpZHRoPSI1MTJweCIgaGVpZ2h0PSI1MTJweCI+CjxnPgoJPHBhdGggZD0iTTE0LDQ3djkuNTM2QzE0LDU4LjQ0NiwxNS41NTQsNjAsMTcuNDY0LDYwaDI1LjA3MkM0NC40NDYsNjAsNDYsNTguNDQ2LDQ2LDU2LjUzNlY0N0gxNHoiIGZpbGw9IiMwMDAwMDAiLz4KCTxwYXRoIGQ9Ik00Niw0NVY3LjQ2NEM0Niw1LjU1NCw0NC40NDYsNCw0Mi41MzYsNEgzNlYwSDI0djRoLTYuNTM2QzE1LjU1NCw0LDE0LDUuNTU0LDE0LDcuNDY0VjQ1SDQ2eiBNMTYsNy40NjQgICBDMTYsNi42NTYsMTYuNjU2LDYsMTcuNDY0LDZIMjRoMTJoNi41MzZDNDMuMzQ0LDYsNDQsNi42NTYsNDQsNy40NjRWMzFIMTZWNy40NjR6IiBmaWxsPSIjMDAwMDAwIi8+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPC9zdmc+Cg==",
        tooltip:
          "See battery status from up to 4 connected controllers at the same time"
      },
      {
        description: "Auto Turn Off",
        src:
          "data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTkuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iTGF5ZXJfMSIgeD0iMHB4IiB5PSIwcHgiIHZpZXdCb3g9IjAgMCA1MTIgNTEyIiBzdHlsZT0iZW5hYmxlLWJhY2tncm91bmQ6bmV3IDAgMCA1MTIgNTEyOyIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSIgd2lkdGg9IjUxMnB4IiBoZWlnaHQ9IjUxMnB4Ij4KPGc+Cgk8Zz4KCQk8cGF0aCBkPSJNNTA1LjY2NCwyNDMuNzM5bC01NC43ODMtMzguNjIyYy05LjkyNi02Ljk5Ny0yMy42NDUsMC4xMjgtMjMuNjQ1LDEyLjI2djIzLjYyMkgxNjQuMTk2ICAgIGMtOC4yODQsMC0xNS4wMDEsNi43MTYtMTUuMDAxLDE1LjAwMVMxNTUuOTEyLDI3MSwxNjQuMTk2LDI3MWgyNjMuMDM4djIzLjYyMWMwLDEyLjIxMiwxMy43OTIsMTkuMjA0LDIzLjY0NCwxMi4yNmw1NC43ODMtMzguNjIyICAgIEM1MTQuMDI3LDI2Mi4zNjUsNTE0LjE5NiwyNDkuNzY3LDUwNS42NjQsMjQzLjczOXoiIGZpbGw9IiMwMDAwMDAiLz4KCTwvZz4KPC9nPgo8Zz4KCTxnPgoJCTxwYXRoIGQ9Ik00MzAuNDcxLDM1Mi4zMTdjLTcuMTY5LTQuMTQ2LTE2LjM0Ny0xLjY5OC0yMC40OTYsNS40NzRjLTM1LjIzNiw2MC45MTYtMTAxLjEwMywxMDEuODExLTE3Ni4zNzIsMTAxLjgxMSAgICBjLTExMi4yNjYsMC0yMDMuNjAyLTkxLjMzNi0yMDMuNjAyLTIwMy42MDJTMTIxLjMzNyw1Mi4zOTgsMjMzLjYwMyw1Mi4zOThjNzUuMzE5LDAsMTQxLjE1Niw0MC45MzMsMTc2LjM3MSwxMDEuODA5ICAgIGM0LjE0OCw3LjE3MiwxMy4zMjgsOS42MTksMjAuNDk2LDUuNDc0YzcuMTcxLTQuMTQ4LDkuNjIxLTEzLjMyNSw1LjQ3NC0yMC40OTZDMzk1LjQxOCw2OS4xMjcsMzE5LjcyOSwyMi4zOTcsMjMzLjYwMywyMi4zOTcgICAgQzEwNC40OSwyMi4zOTcsMCwxMjYuODc2LDAsMjU2YzAsMTI5LjExMywxMDQuNDc5LDIzMy42MDMsMjMzLjYwMywyMzMuNjAzYzg2LjE2MywwLDE2MS44MzMtNDYuNzYzLDIwMi4zNDItMTE2Ljc5ICAgIEM0NDAuMDkyLDM2NS42NDIsNDM3LjY0MiwzNTYuNDY2LDQzMC40NzEsMzUyLjMxN3oiIGZpbGw9IiMwMDAwMDAiLz4KCTwvZz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8L3N2Zz4K",
        tooltip:
          "All connected controllers will turn OFF when your computer shuts down"
      }
    ]
  }),
  methods: {
    download: function() {
      this.loading = true;
      axios
        .get(
          "https://us-central1-xbox360-controller-manager.cloudfunctions.net/download"
        )
        .then(response => {
          this.loading = false;
          window.location = response.data.link_download;
        })
        .catch(error => {
          this.$ga.exception(error);
          this.loading = false;
          eventHub.$emit("error", {
            show: true,
            message: "There was an error retrieving download information."
          });
        });
      this.$ga.event("download", "click");
    }
  }
};
</script>

<style scoped>
.layout {
  padding-top: 35px;
}

.card-title {
  padding: 25px;
}

.application--light .btn.btn--disabled:not(.btn--icon):not(.btn--flat) {
  background-color: #fdd835 !important;
}

.download-loader {
  animation: loader 1s infinite;
  display: flex;
}

@-moz-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}

@-webkit-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}

@-o-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}

@keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}

img {
  vertical-align: middle;
  width: 50px;
  height: 50px;
}

.span-height {
  background-color: #37474f;
  height: 75px;
}
</style>
