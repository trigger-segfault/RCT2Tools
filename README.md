# RCT2 Content Browser

* Author: Robert Jordan
* Version: v1.2.1.0

RCT2 Content Browser is a more advanced program originally designed to replace DatChecker.
With this you can easily browse and manage all content in your RCT2 directory.
RCT2CB not only shows you a visual representation of the object, but all of it's information and data as well.
This makes the tool useful for Studying RCT2 file types as well.
All variables and flags listed in the info tab have information on them in the source code.
Please note that not all objects are 100% accurately displayed in the view window.

**[Standalone Download](http://www.mediafire.com/download/p6vwt3d8x9rrn8p/RCT2+Content+Browser+v1.2.1.0.zip)**

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

**Delete Key:** Will delete the selected objects in the last used list if *Allow Deletions* is checked.

## Settings

**Default Directory:** The default directory to use for RCT2 data. Make sure to use the ObjData folder.

**Objects Per Tick:** Changes how many objects are loaded inbetween pauses. More objects will make the program run slower until fully loaded and less objects will make the loading take longer.

**Quick Load Attractions:** Only allows attractions to load 35 images. This is useful when browsing attractions as many of them can have thousands of images, which takes awhile to load.

**Remap Image View:** When in image view, the remap option will be available.

**Allow Deletions:** Enables the delete key, allowing users to delete objects from the list that they no longer want. Objects without a *Custom* source cannot be deleted for safetey reasons.

**Backup Deletions:** All deleted object files will be sent to a folder in the executable directory.

**Extract Images:** Extracts all images and palettes in the object file into a folder in the executable directory.

**Open Directory:** Opens the executable directory making it easier to access extracted images and deleted object files.

**Save:** Saves the settings to *Settings.xml*.

## Other features

**Open With:** Opening a dat file with RCT2 Content Browser will automatically load the object without having to scan for it.

# RCT2 Group Creator

* Author: Robert Jordan
* Version: v1.0.0.0

A simple program for creating scenery groups for RollerCoaster Tycoon 2. You can edit existing groups, or create your own from scratch. All scenery in the program can be visually represented making it easier to decide if it's worthy for the group.

**[Standalone Download](http://www.mediafire.com/download/nx51qnony7wmowi/RCT2+Group+Creator+v1.0.0.0.zip)**

## Requirements

Works with Windows 7, Windows 8 has not been tested.

Your DPI setting may need to be at 100% percent.

## Controls

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2GroupCreator/Resources/Buttons/ButtonLeft.png"></img>
<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2GroupCreator/Resources/Buttons/ButtonRight.png"></img>
Change the currently selected scenery object.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2GroupCreator/Resources/Buttons/ButtonPlus.png"></img>
<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2GroupCreator/Resources/Buttons/ButtonMinus.png"></img>
Add and remove scenery objects from the list. Note you can also drag objects in, (even from RCT2 Content Browser!).

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2GroupCreator/Resources/Buttons/ButtonNames.png"></img>
Change the names of the scenery group for each language.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2GroupCreator/Resources/Buttons/ButtonIcon.png"></img>
Change the scenery group icon. Images must be transparent and of the size 31x27.

**Browse:** Change the default to directory to look for scenery objects in so they can be viewed.

**Drag Files Onto List:** Allows you to add scenery objects to the group without using a file dialog. (You can even drag them from RCT2 Content Browser!).

**Drag Files In List:** Allows you to rearange the order of scenery objects in the list.

# RCT2 Water Creator

* Author: Robert Jordan
* Version: v1.0.0.0

A simple program for creating water types for RollerCoaster Tycoon 2. You can edit existing water types, or create your own from scratch.

**[Standalone Download](http://www.mediafire.com/download/01w8j7smwpwqpi4/RCT2+Water+Creator+v1.0.0.0.zip)**

## Requirements

Works with Windows 7, Windows 8 has not been tested.

Your DPI setting may need to be at 100% percent.

## Explanation

**General:** These colors are used for color remapping as well as in flat water.

**Waves:** These three rows animate the waves in the water and on water rides. The rows are used in the following order: Sunny, Cloudy, Rainy.

**Sparkles:** These three rows animate the sparkles in the water and on water rides. The rows are used in the following order: Sunny, Cloudy, Rainy.

## Controls

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2WaterCreator/Resources/Buttons/ButtonSun.png"></img>
Change the lighting to sunny.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2WaterCreator/Resources/Buttons/ButtonCloud.png"></img>
Change the lighting to cloudy.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2WaterCreator/Resources/Buttons/ButtonRain.png"></img>
Change the lighting to rainy.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2WaterCreator/Resources/Buttons/ButtonRide.png"></img>
Change the view to a water ride.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2WaterCreator/Resources/Buttons/ButtonWater.png"></img>
Change the view to an open expanse of water.

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2WaterCreator/Resources/Buttons/ButtonPaint.png"></img>
Open up the color dialog for the selected color

<img src="https://raw.githubusercontent.com/trigger-death/RCT2Tools/master/RCT2WaterCreator/Resources/Buttons/ButtonNames.png"></img>
Change the names of the water type for each language.

**Click Selected Color:** Automatically opens up the color dialog without having to press the color dialog button.

**Ctrl+C & Ctrl+V:** Allows you to copy and paste the selected color.

# RCT2 Graphics Extractor

* Author: Robert Jordan
* Version: v1.1.0.0

RCT2 Graphics Extractor is a simple tool for extracting all graphics in RollerCoaster Tycoon 2 from the *g1.dat* file. All the images are output into the specified directory in PNG format. Palettes are saved as images as well as text files in a subfolder. To find your g1.dat file go to your RCT2 directory and select your Data folder.

**[Standalone Download](http://www.mediafire.com/download/l53loa6creb4dq0/RCT2+Graphics+Extractor+v1.1.0.0.zip)**

## Requirements

Works with Windows 7, Windows 8 has not been tested.

Your DPI setting may need to be at 100% percent.

## Settings

**Extract RCT2 Images:** Also extracts images in the format used by RCT2. Only useful for programmers.

# RCT2 Maze Generator

* Authors: Robert Jordan, Lewis Fox
* Version: v0.0.1.2

RCT2 Maze Generator allows you to edit and procedurally generate mazes that can be loaded into RCT2. It is a work in progress, and is not completely funcitonal yet. 
