# BN - Primitive Launcher
![alt text](https://i.ibb.co/k8rvP7h/1.png)

Adds a primitive launcher that should be able update and run the game.

**DOWNLOAD LINK**: https://github.com/4nonch/BN---Primitive-Launcher/releases

**Problem? I'm not responding on github for a long time?**
Ping me on official BN discrod server (anonch#4587): https://discord.gg/XW7XhXuZ89

**WARNING**:
**cataclysm\data\mods folder deletes after update. Keep custom mods in cataclysm\Mods folder instead.**

Translated/edited mods better not to keep in cataclysm\data\mods (try to keep it in cataclysm\Mods). Why? Because if you choose option to install KenanModpack it will rewrite mods in cataclysm\data\mods folder. Also every time updating Launcher install and rewrite UndeapPeople tiles for mods in cataclysm\data\mods folder.

**How it works:** [description needs updating]
1. Creates "BN - old data" folder and moves all directories and files in root folder to it
2. Downloads archive with the latest **win64-tiles** or **win32-tiles** release 
3. Extracts to the root folder you specified
4. Deletes the downloaded archive
5. Moves folders from "BN - old data" to root folder according to your settings
If you use english version launcher will create \en folder to store it dll in it.

**Settings:** [description needs updating]
1-8 settings moves *something* from old to new version
1. Saves - Moves your saves
2. Sounds - Moves your sounds from \sound and \data\sound
3. \Mods folder - Moves **only** your "\Mods" or "\mods" folder if it exists (**not** \data\mods)
4. \font folder - Moves your \font folder
5. \config folder - Moves your \config folder
6. \templates folder - Moves your \templates folder
7. \memorial folder - Moves your \memorial folder
8. \graveyard folder - Moves your \graveyard folder
9. Current version full backup - Makes backup of all root folder (Actually all directories and files in "BN - old data")
10. Install Kenan's modpack - Downloads and installs Kenan's modpack after extracting new version

It has option to download&install [Kenan modpack](https://github.com/Kenan2000/Bright-Nights-Kenan-Mod-Pack) after updating the game.
The advantage of this modpack is that it already contains the necessary tilesets from [SomeDeadGuy](https://github.com/SomeDeadGuy) for mods.
This way, if you use [UndeadPeopleTileset](https://github.com/SomeDeadGuy/UndeadPeopleTileset), you don't have to install graphical mods separately

# TODO:
1. ~~Different soundpack download&install~~
2. ~~Make option to replace music on soundpack_name to [CO.AG MusicPack](https://discourse.cataclysmdda.org/t/musicpack-co-ag-musicpack-redux-11-dec-2019/18992) or smth~~
3. ~~[UndeadPeopleTileset](https://github.com/SomeDeadGuy/UndeadPeopleTileset) tileset install. (BN & Kenan modpack has older version with bugs)~~
4. ~~Remove Property.Settings and replace it with XML Serialization and store it within Launcher's folder (Currently this Launcher stores your settings in %appdata%\local\BN_Primitive_Launcher\, shiting your appdata up) (PROBABLY DONE, NEEDS TESTING)~~
5. ~~Make Controls unavailable during update~~
6. ~~Display current work near progressbar (like downloading Kenan; UPT; installing CO.AG and all that stuff)~~
7. (?)Add "Cancel" button to cancel updation
8. (?)Launcher update feature 
9. (?)Display new version description

(?)Complete rewrite on WPF(?)
