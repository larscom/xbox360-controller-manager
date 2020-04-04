<template>
  <v-container grid-list-md>
    <v-layout row wrap class="mb-2">
      <v-flex md4 lg4 sm12 xs12>
        <v-card class="card card-height">
          <v-card-text>
            <h1 class="mb-1 headline">Requirements</h1>
            <ul>
              <li>Windows Vista SP2+</li>
              <li>
                <a
                  href="https://www.microsoft.com/en-us/download/details.aspx?id=30653"
                  target="_blank"
                >Download</a>
                .NET Framework 4.5
              </li>
              <li>
                <a
                  href="http://www.microsoft.com/en-us/download/confirmation.aspx?id=8109"
                  target="_blank"
                >Download</a> DirectX runtimes
              </li>
            </ul>
          </v-card-text>
        </v-card>
      </v-flex>

      <v-flex md4 lg4 sm12 xs12>
        <v-card class="card card-height">
          <v-card-text>
            <h5 class="mb-1 headline">How to Install</h5>
            <ol>
              <li>Unzip the .exe anywhere on your PC</li>
              <li>Double click the application</li>
              <li>An icon appears in the taskbar, bottom right</li>
            </ol>
            <img
              class="notifyicon"
              src="/images/middle-section/app.png"
              alt="notifyIcon bottom windows"
              title="notifyIcon in Windows"
            >
          </v-card-text>
        </v-card>
      </v-flex>

      <v-flex md4 lg4 sm12 xs12>
        <v-card class="card card-height">
          <v-card-text>
            <h5 class="mb-1 headline">How to use</h5>
            <ul>
              <li>
                Press and hold
                <img
                  width="16px"
                  height="16px"
                  src="/images/controller-buttons/back.png"
                  alt="XBOX 360 Controller Back Button"
                  title="Back button"
                > and
                <img
                  width="16px"
                  height="16px"
                  src="/images/controller-buttons/start.png"
                  alt="XBOX 360 Controller Start Button"
                  title="Start button"
                > on the controller to turn it OFF (default setting)
              </li>
              <li>
                Press and hold
                <img
                  width="16px"
                  height="16px"
                  src="/images/controller-buttons/guide.png"
                  alt="XBOX 360 Controller Guide Button"
                  title="Guide button"
                > on the controller to turn it OFF (configurable in the menu)
              </li>
              <li>
                Press and hold
                <img
                  width="16px"
                  height="16px"
                  src="/images/controller-buttons/back.png"
                  alt="XBOX 360 Controller Back Button"
                  title="Back button"
                > and
                <img
                  width="16px"
                  height="16px"
                  src="/images/controller-buttons/b.png"
                  alt="XBOX 360 Controller B Button"
                  title="B button"
                > on the controller to get a notification about the battery
              </li>
              <li>
                <strong>Click</strong> the taskbar icon:
                <img
                  width="16px"
                  height="16px"
                  src="/favicon.ico"
                  alt="XBOX 360 Controller Manager logo"
                > to show battery information about all connected controllers
              </li>
              <li>
                <strong>Click</strong> the taskbar icon:
                <img
                  width="16px"
                  height="16px"
                  src="/favicon.ico"
                  alt="XBOX 360 Controller Manager logo"
                > and left click on a controller to turn it
                <strong>off</strong>
              </li>
            </ul>
          </v-card-text>
        </v-card>
      </v-flex>

      <v-flex xs12 class="mt-2">
        <v-card class="card">
          <v-card-text>
            <h4>Steam & Guide Button</h4>
            <p>
              In order to use the Guide button in Windows and to prevent
              <strong>Steam Big Picture</strong> from starting up, you have to take some additional steps.
            </p>
            <br>
            <h1 class="mb-1 headline">Prevent Windows Game Bar from starting up</h1>
            <p>
              In Windows: go to
              <strong>Start > Settings > Gaming > Game Bar</strong> and turn off everything there.
            </p>
            <img
              height="75%"
              width="75%"
              src="/images/middle-section/gamebar.png"
              alt="Disable Game Bar in Windows"
            >
            <br>
            <br>
            <br>
            <h1 class="mb-1 headline">Prevent Steam Big Picture from starting up</h1>
            <p>Download the file below, this will filter out Guide button presses when you have steam running.
              <br>This file is just a simple DLL file which you have to place in your steam folder
            </p>
            <p>Default location: 'C:\Program Files (x86)\Steam'</p>
            <p>
              Download
              <a
                href="https://firebasestorage.googleapis.com/v0/b/xbox360-controller-manager.appspot.com/o/steam%2Fsteam_xinput.zip?alt=media&token=ff133246-28b8-40db-aaca-e01b06287bec"
              >here</a>
            </p>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<style scoped>
.notifyicon {
  padding: 5%;
  width: 100%;
  height: auto;
}
.card-height {
  height: 100% !important;
}
.card {
  padding: 15px;
}
</style>
