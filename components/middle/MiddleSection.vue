<template>
  <v-container grid-list-md>
    <v-layout row wrap class="mb-4 pa-2">
      <v-flex md4 lg4 sm12 xs12>
        <v-card>
          <v-card-text>
            <h1 class="mb-1 headline">Requirements</h1>
            <ul>
              <li>Windows Vista SP2+</li>
              <li><a href="https://www.microsoft.com/en-us/download/details.aspx?id=30653" target="_blank">Download</a>
                .NET Framework 4.5
              </li>
              <li><a href="http://www.microsoft.com/en-us/download/confirmation.aspx?id=8109"
                     target="_blank">Download</a> DirectX runtimes
              </li>
            </ul>
          </v-card-text>
        </v-card>
      </v-flex>

      <v-flex md4 lg4 sm12 xs12>
        <v-card>
          <v-card-text>
            <h5 class="mb-1 headline">How to Install</h5>
            <ol>
              <li>Unzip the .exe anywhere on your PC</li>
              <li>Double click the application</li>
              <li>An icon appears in the taskbar, bottom right</li>
            </ol>
          </v-card-text>
        </v-card>
      </v-flex>

      <v-flex md4 lg4 sm12 xs12>
        <v-card>
          <v-card-text>
            <h5 class="mb-1 headline">How to use</h5>
            <ul>
              <li>Press and hold <img width="16px" height="16px" src="/images/controller-buttons/back.png" alt="XBOX 360 Controller Back Button"> and <img width="16px" height="16px" src="/images/controller-buttons/start.png" alt="XBOX 360 Controller Start Button"> on the controller to turn it OFF</li>
              <li>Press and hold <img width="16px" height="16px" src="/images/controller-buttons/back.png" alt="XBOX 360 Controller Back Button"> and <img width="16px" height="16px" src="/images/controller-buttons/b.png" alt="XBOX 360 Controller B Button"> on the controller to get a notification about the battery</li>
              <li><strong>Click</strong> the taskbar icon: <img width="16px" height="16px" src="/favicon.ico" alt="XBOX 360 Controller Manager Logo"> to show battery information about all connected controllers</li>
            </ul>
          </v-card-text>
        </v-card>
      </v-flex>

    </v-layout>
  </v-container>
</template>
