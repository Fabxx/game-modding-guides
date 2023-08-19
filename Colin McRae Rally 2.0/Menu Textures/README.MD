# DETAILS FOR THE MENU TEXTURES

Luckily, same steps as the car texture modding, but this time we have to edit two BFL files:

  -Inside `FrontEnd folder` in the main installation directory, take `res1024.bfl` and `res1024C.bfl` 
  (if on low resolution of the game, take the `640` ones)

  -the `res1024` files are in `TGA` format, and once being exported again in `TGA`, we need to apply this:

  TGA EXPORT VALUES = `16 Bit + RLE compression`.

  -the `res1024C` are in `DDS` format, and we apply the same option mentioned above:

      -DDS EXPORT VALUES MUST BE = `BC3 (DTX1) Interpolated alpha with HIGHEST COMPRESSION QUALITY.`

  then again, drag & drop the BWD and create the file to replace.

# TEXTURE HIREARCHY
  
  menu textures are divided like so:

  -livery preview files (the tiny square you see in the menu that shows the livery of the car):

      `livery1.tga`
      `livery2.tga`
      `livery3.tga`

  -Two sided car texture (front/back of the car) have the name of the car but with a single letter suffix that changes:

  example with 6r4:

      `6r4b01.tga` is the texture on the left
      `6r4a01.tga` is the texture on the right


  NOTE: If you edit for example the 6r4b01.tga, you MUST also edit the 6r4b01.dds, or else you won't see any changes.
