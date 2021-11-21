# XBOX 360 Controller Manager

Turn off multiple wireless XBOX 360 controllers simultaneously and see the battery status of each controller.

## Supports

- &#10003; Supports any version of Windows 10
- &#10003; Turn OFF up to 4 connected controllers simultaneously
- &#10003; See battery status from up to 4 connected controllers at the same time
- &#10003; All connected controllers will turn OFF when your computer shuts down

## How to Install
 1. Download release
    - https://github.com/larscom/xbox360-controller-manager/releases
 2. Unzip the .exe anywhere on your PC
 3. Double click the application
 4. An icon appears in the taskbar, bottom right

![xbox360_controller_manager](https://github.com/larscom/xbox360-controller-manager/blob/master/images/app.png?raw=true)
## Requirements
- Windows Vista SP2+
- .NET Framework 4.5
    - https://www.microsoft.com/en-us/download/details.aspx?id=30653
- DirectX runtimes
    - https://www.microsoft.com/en-us/download/confirmation.aspx?id=8109

## How to use
![how_to_use](https://github.com/larscom/xbox360-controller-manager/blob/master/images/howto.png?raw=true)

## Using the guide button in Windows
If you wish to use the 'guide' button to turn off the controller (which is configurable in the menu, default is 'start & back')
you need to go to 'Xbox Game Bar' settings in Windows and leave the 'Xbox Game Bar' ON, but turn OFF the setting: 'Open Xbox Game Bar using this button on a controller' 

![windows_settings](https://github.com/larscom/xbox360-controller-manager/blob/master/images/gamebar_settings.png?raw=true)

## Steam Big Picture
Prevent Steam Big Picture from starting up when you press the GUIDE button:
- Inside the release package (.zip) there is a folder called `steam_xinput` with a `README.txt`

## Checkout & Build

You can checkout the project and make a release build.

Executable `(XBOX360_Controller.exe)` will be put into `bin/Release` and is ready to use.

