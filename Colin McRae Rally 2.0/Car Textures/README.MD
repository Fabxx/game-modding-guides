# TOOLS
 
 -Get blfworks from here: https://mega.nz/file/hToAiYTB#KoiS-yBflVBP47lmsZbnSau5JBoN7wMuS4O6eN82jRM
 
# EXTRACTING THE TEXTURES FOR CARS

 -Open the interface of the program > set the path to a empty folder where to extract files by clicking the yellow folder icon.

  -After that, go into your game folder where you installed CMR 2.0, here's an index of what folders contain the files you want:

  -Car textures inside `Game > Cars`. Where the name of the main textures with higher quality used by the game 
  are named like this (example with `6r4`):

  `-6r4.cin` - file for dummies, which include lights that turn on and of (red tail lights object, front lights object) and antennas.

  `-6r4a1.bfl` - the main bfl file for higher quality textures, used when the game has the highest graphical settings in the car quality option.

  `-6r4a1L.c3d` - the 3D model of the tarmac tyres.

  `-6r4a1N.c3d` - the bodykit 3D model with the gravel tyres 3D model.

  `-6r4a1S.c3d` - the snow tyres 3D model

  note: all the files with higher quality contain the `a1` suffix in the name.

# EDITING TEXTURES AND IMPORTING

  -What we need for textures is the `bfl` file, drag & drop it to the bflworks interface, and inside your destination folder there will be the
  folder with the car file name, alongside a `BWD` file, that we'll need later.

  -Now to edit the desired texture, we need `Adobe Photoshop` with the `NVIDIA DDS plugin`:

  link to plugin: https://mega.nz/file/sGw1waxT#d_BaVWVD-f1WCMpfFrLK79cu66T3CbetrSTKbxt9SEg

  After installing photoshop and the DDS plugin for it, reboot photoshop.

  Then drag & drop a DDS texture file in the PS interface, leave default settings from plugin window and import.

  Edit your texture and export it as DDS, while choosing the properties be aware of these things:

  `DO NOT CHANGE THE RESOLUTION OF THE FILE OR GAME WILL CRASH.`

   `DDS EXPORT VALUES MUST BE = BC3 (DTX1) Interpolated alpha with HIGHEST COMPRESSION QUALITY.`
   
   Once the texture has been exported inside the folder where it was extracted, drag & drop the BWD file inside the bflworks interface  
   it will re-create the blf by overwriting the previous one 
   (if you want a backup, simply change the name of the previous bfl and then drag & drop to have the new one.)

  -Copy & paste the edited BFL file in the cars folder where we got it, and test it in game.
