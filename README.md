# RCT2 Content Browser

* Author: Robert Jordan
* Version: v1.1.1.0

RCT2 Content Browser is a more advanced program originally designed to replace DatChecker.
With this you can easily browse and manage all content in your RCT2 directory.
RCT2CB not only shows you a visual representation of the object, but all of it's information and data as well.
This makes the tool useful for Studying RCT2 file types as well.
All variables and flags listed in the info tab have information on them in the source code.
Please note that not all objects are 100% accurately displayed in the view window.

## Requirements

Works with Windows 7, Windows 8 has not been tested. Has partial Linux support.

Your DPI setting must be at 100% percent, otherwise the scan button won't be visible.

## Tabs

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Tabs/TabInfo.png"></img>
The info tab. Most of the information is low level which means you may not understand it.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Tabs/TabSettings.png"></img>
The settings tab.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Tabs/TabAll.png"></img>
The *all* tab. Every object type is shown in the list.

## Controls

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Buttons/ButtonRotate.png"></img>
Rotate the object or change the path pattern.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Buttons/ButtonSlope.png"></img>
Change the slope for applicable objects.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Buttons/ButtonCorner.png"></img>
Change the corner for applicable small scenery objects, change between queue and normal paths, or change the car type of the attraction.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Buttons/ButtonElevate.png"></img>
Elevate the path.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Buttons/ButtonLeft.png"></img>
<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Buttons/ButtonRight.png"></img>
Change the currently selected object.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Buttons/ButtonBack.png"></img>
<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2Browser/Resources/Buttons/ButtonForward.png"></img>
Change the current image being viewed in image mode or change the current frame being viewed.

**Dialog Checkbox:** Changes the view to dialog view.

**Image Checkbox:** Changes the view to individual images in the file.

**Drag Object from List:** Allows you to copy the object and place it in the dropped location.

## Settings

**Default Directory:** The default directory to use for RCT2 data. Make sure to use the ObjData folder.

**Objects Per Tick:** Changes how many objects are loaded inbetween pauses. More objects will make the program run slower until fully loaded and less objects will make the loading take longer.

**Quick Load Attractions:** Only allows attractions to load 35 images. This is useful when browsing attractions as many of them can have thousands of images, which takes awhile to load.

**Remap Image View:** When in image view, the remap option will be available.

**Save:** Saves the settings to *Settings.xml*.

# RCT2 Graphics Extractor

* Author: Robert Jordan
* Version: v1.0.0.0

RCT2 Graphics Extractor is a simple tool for extracting all graphics in RollerCoaster Tycoon 2 from the *g1.dat* file. All the images are output into the specified directory in PNG format. Palettes are saved as images as well as text files in a subfolder. To find your g1.dat file go to your RCT2 directory and select your Data folder.

## Requirements

Works with Windows 7, Windows 8 has not been tested. Has partial Linux support.

Your DPI setting may need to be at 100% percent.
