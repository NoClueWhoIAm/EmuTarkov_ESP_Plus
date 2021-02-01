## EmuTarkov 12.9.10532 ESP/Aimbot
#### code updated by NoClueWhoIAm
__(Credits to https://github.com/JoakimCarlsson & @Zat on UC as this is completely based off their release back in march 2020)__

### How to install:

Drop Managed into the EmuTarkov installation folder under EscapeFromTarkov_Data/ and replace all, then it should work.
(only works with SP-AKI 1.0.0.7-3, update tutorial on the bottom.)


### Used Libraries
- Assembly-CSharp
- Comfort
- Comfort.Unity
- Newtonsoft.Json
- UnityEngine
- UnityEngine.CoreModule
- UnityEngine.IMGUIModule
- UnityEngine.PhysicsModule
- UnityEngine.UI

### Features:

- Player ESP (includes: Draw Players, Draw Player Box, Draw Player Name, Draw Player Line, Draw Player Health, Player distance slider)
- Item ESP (includes: Loot Item Distance slider || This version only shows the High valueable loot and quest item locations => Update soon to insert own loot tables)
- Container ESP (includes: Distance slider)
- Exfil ESP
- Aimbot (includes: Aimbot smooth per meter slider, Aimbot FOV slider calculated by meters) Left CTRL for aimbot.
- No-Recoil
- Open any locked doors with NUM4


### Updates that are being worked on:
- Custom loot table option
- In-Depth aimbot
- Infinite Stamina
- UI Overhaul
- More optimization and code cleanup

### How to update to newest version yourself:

Find your way to my github and find the source of this release, download that as a ZIP.

You need the following programs in order to update it.

- Microsoft Visual Studio
- DnSpy
- Basic to very low csharp knowledge

Open up the Visual Studio Solution file and open References in the solution explorer.
Add any missing reference files. You can find those by going to your EmuTarkov installation folder
EscapeFromTarkov_Data > Managed > **.dll

To add missing references you right click on References and click on Add Reference... (sad that I need to explain this sometimes)

If the all references are complete, save the solution and build the solution by doing CTRL + SHIFT + B       < default keybind >

The solution will build into the save location of the solution folder into > bin/x64/Debug/EscapeFromTarkovCheat.dll

Copy this dll file and paste it into the EmuTarkov installation folder EscapeFromTarkov_Data > Managed >


Now open DnSpy, clear any open projects from the explorer and open a new file CTRL + O

Find the Assembly-CSharp.dll from your EmuTarkov installation folder EscapeFromTarkov_Data > Managed > Assembly-CSharp.dll
open it.

Go to the yellow name EFT and click on the drop down menu, select AudioArray and open it through the dropdown menu once again.

open the function Awake() : void and right click on the item and click on Edit Method (C#)...

A new venster will open and you can now type in this venster.

Under this.Init(null);
type the following:

EscapeFromTarkovCheat.Loader.Load();

Add the Assembly Reference by click on the map with the arrow on the bottom left of this venster

Find the EscapeFromTarkovCheat.dll that you placed in the EmuTarkov Instllation folder under Managed. 
Add it to the reference and click on Compile and then on OK 

Make sure that the path is set to the EmuTarkov Instllation folder under EscapeFromTarkov_Data > Managed >

Now Save-all on the top navigation bar in DnSpy by clicking on the save icon or by pressing CTRL + Shift + S

You should now have:

EscapeFromTarkovCheat.dll in the managed folder
Edited Assembly-CSharp.dll in the manged folder

You can now run the EmuTarkov like usual and the cheat should work like intended on the updated version.


#### if you have any questions, please do so on my GitHub or on the release forum.
