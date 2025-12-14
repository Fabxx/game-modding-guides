# REQUIREMENTS

- `3DS Max 2025`

- `KAMs Scripts`


# MAP STRUCTURE

- First, check if your map is using vanilla DFFs from the game
  - If so, use `IMG Factory` to export the DFFs from `gta3.img` and `gta_ing.img`
  - You can open the IPL file of the map, and search the DFFs inside the imgs with the names provided by the IPL.
    Example:
	
	```
	15850, rarui, 0, 406.842664255, -2434.60642006, 8.8890625, 0, 0, 0, 1, -1
	15851, lodrarui, 0, 406.842664255, -2434.60642006, 8.8890625, 0, 0, 0, 1, -1
	15852, treewall, 0, 406.842664255, -2434.60642006, 8.8890625, 0, 0, 0, 1, -1
	1264, BlackBag1, 0, 467.857756105, -2396.14638917, 9.16632270813, 0, 0, 0, 1, -1
	1264, BlackBag1, 0, 466.948452374, -2396.3748801, 9.16632, 0, 0, 0.878816680049, 0.477159557033, -1
	1372, CJ_Dump2_LOW, 0, 468.881, -2396.39, 8.88906, 0, 0, 0, 1, -1
	1372, CJ_Dump2_LOW, 0, 469.79982222, -2414.85609957, 8.88906, 0, 0, 0.207914113379, -0.978147085799, -1
	1775, CJ_SPRUNK1, 0, 472.195118422, -2386.68153542, 9.98, 0, 0, 0.707108188464, -0.707105373907, -1
	2860, gb_kitchtakeway05, 0, 464.71, -2411.76, 9.707, 0, 0, 0.713251838931, -0.70090785005, -1
	1368, CJ_BLOCKER_BENCH, 0, 472.189693958, -2394.5749375, 9.56, 0, 0, 0.725375725747, -0.688353148098, -1
	1238, trafficcone, 0, 481.700446756, -2385.28342705, 9.18906288147, 0, 0, 0, 1, -1
	1238, trafficcone, 0, 484.257937583, -2384.66459044, 9.18906288147, 0, 0, 0, 1, -1
	1238, trafficcone, 0, 480.358387525, -2386.51519462, 9.18906288147, 0, 0, 0, 1, -1
	1238, trafficcone, 0, 479.090748134, -2384.35356906, 9.18906288147, 0, 0, 0, 1, -1
	1238, trafficcone, 0, 475.152193533, -2416.76998217, 9.18906288147, 0, 0, 0, 1, -1
	1370, CJ_FLAME_Drum_(F), 0, 480.263, -2418.01, 9.43, 0, 0, 0.887010407729, 0.461749430514, -1
	1370, CJ_FLAME_Drum_(F), 0, 463.6042872, -2389.94927036, 9.43, 0, 0, 0.887010407729, 0.461749430514, -1
	1238, trafficcone, 0, 473.166228616, -2417.79570454, 9.18906288147, 0, 0, 0, 1, -1
	1238, trafficcone, 0, 469.128078799, -2417.77206531, 9.18906288147, 0, 0, 0, 1, -1
	```
	
	The first 3 objects are custom, the others are vanilla. Parameters are:
	
	- `ID`: object identifier, IDs are registeres between a range (see ID ranges below)
	- `object name`: name that referres to the used DFF
	- `interior ID`: in which interior the object is used.
	- `XYZ Position`: 3D Vector which represents in game coordinates of map position
	- `XYZW Rotation`:  4D Vector which represents in game coordinates of map rotation
	- `LOD`: Level of detail to start from. -1 is `NO LOD` 1 is `USE LOD`
	  - NOTE: If objects in the IPL have a flag different from -1 but you want to discard the LOD to spare some IDs, you can override the flag to -1
              and then delete the dff of LODs
	

# IMPORT

- If your map is using vanilla objects, you need to add those strings to the `IDE` definitions of the map mod.
  - Use `grepWin` on gta sa directory to recurisvely search for the object name inside the IDE files.
  - Once found, copy the lines into the map's `IDE` file and save it.

- Open 3DS Max, on the `top-Right` you should see a section called `GTA Tools`

- Go to `Map > MAP IO`

- Change the `DFF Path` to the folder that contains your DFFs

- If the IPL contains coordinates in more sections than `INST`, then select the relative sections too.
  - You can check this by opening the IPL file with notepad++

- Select `Import IPL` and open the IPL of the map file to import.


# Editing Map Coordinates

- Select all the meshes with `CTRL+A`
- On far right of the UI, click `Pivot` -> `Affect Pivot Only`
- 

- Click on the move icon, which is a cross composed of 4 arrows

- Click on the main mesh and you will get the current map coords in game.

- When you select all meshes, you can type inside the rectangular squares the coordinates for each axis


# EXPORT

- In `GTA Tools > MAP > Map IO` find the `kam ipl/ide Export` section

- Click on `import IDE`

- Click on `Export IPL`

- go to `Scripting > Scripting Listener` on the top-right

- Click on `Save As` and select as a filter `All Files`

- Manually write the IPL extension

- Now for the `IDE` file, click on `Export IDE` and repeat the process


# CLEANUP

- Delete the vanilla object definitions that you have added in the `.IDE` file.
  you don't need them anymore unless you have to edit the map again.
  
- Delete the vanilla `DFFs` placed in `gta3.img` folder of the map mod



# Usable ID Ranges

- Single Player: `18632 - 20000`, 
- SA-MP: Free IDs range is `15065 - 15999`

NOTE: Fastman limit adjuster can increase the ID limit over 20000, but only for single player, on SA-MP this modifications crashes.


