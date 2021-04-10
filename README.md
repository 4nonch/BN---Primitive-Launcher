# BN - Primitive Launcher
![alt text](https://i.ibb.co/k8rvP7h/1.png)

Adds a primitive launcher that should be able update and run the game.

Download link: https://github.com/4nonch/BN---Primitive-Launcher/releases/download/0.9.1/BN.-.Primitive.Launcher.exe

**How it works:**
1. Creates "BN - old data" folder and moves all directories and files in root folder to it
2. Downloads archive with the latest **win64-tiles** or **win32-tiles** release 
3. Extracts to the root folder you specified
4. Deletes the downloaded archive
5. Moves folders from "BN - old data" to root folder according to your settings
If you use english version launcher will create \en folder to store it dll in it.

**Settings:**
1-8 settings moves *something* from old to new version
1. Saves - Moves your saves
2. Sounds - Moves your sounds from \sound and \data\sound
3. \Mods folder - Moves your \Mods or \mods folder if it exists
4. \font folder - Moves your \font folder
5. \config folder - Moves your \config folder
6. \templates folder - Moves your \templates folder
7. \memorial folder - Moves your \memorial folder
8. \graveyard folder - Moves your \graveyard folder
9. Current version full backup - Makes backup of all root folder (Actually all directories and files in "BN - old data")
10. Install Kenan's modpack - Downloads and installs Kenan's modpack after extracting new version

It has option to download&install [Kenan modpack](https://github.com/Kenan2000/CDDA-Kenan-Modpack) after updating the game.
The advantage of this modpack is that it already contains the necessary tilesets from [SomeDeadGuy](https://github.com/SomeDeadGuy) for mods.
This way, if you use [UndeadPeopleTileset](https://github.com/SomeDeadGuy/UndeadPeopleTileset), you don't have to install graphical mods separately
