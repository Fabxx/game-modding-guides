use the anvil toolkit and unpack the DataPC.forge file, or any other forge where your file is

unpack the.data file you want to edit

the files are divided in this way:

`Entity table`: a file that points to the .Buildtable file hashes

`Build tables`: files that contain the mesh IDs to build

`.Mesh files`: actual 3D model files

`texturesets` and `normal maps`: actual textures and UV mapping

`material files`: they call the texture sets and normal maps

Now, the main file to edit is the build table/s file, which contains the mesh IDs

open Hxd, open one .mesh file, the first bytes are `00 01`, skip them, the other 4 bytes (xx xx xx xx) are the `mesh ID`

search for that ID in the related buildtable, and you'll find the reference.

Copy and paste the model mesh, texture-normals and materials of the mesh you want to use in the unpacked files folder

open with hex editor the mesh you copied, take his ID, then replace the old ID you found with the new one,

save the buildtable and test.


# NOTES TO PORT FROM BROTHERHOOD TO REVELATIONS OR VICEVERSA

Brotherhood and revelation files, the only difference between them is that BH at the end has a `03 00 00 00` header

RV has a `03 00 00 00 03 00 00 00` header, if you want to port the meshes, reduce the header to BH one or viceversa.


NOTE2: Materials have to be ported as well since they're not almost the same. Convert the material in xml with the toolkit

then convert the .material you want to replace, preferrably a similar one to the one being replaced.

Copy the 4th line from one material to the other, then replace everything else below line 6.

repack the xml as material and paste it.

NOTE3: If you have to import another buildtable, hex edit it and find the 4 bytes after `00 01`, then replace the old table ID with the new one in the entitybuilder file, usually this file is the first one with index 0.
