# INITIAL SETUP

 get iripper 1.8 and the BIG decompressor:
 
 https://cdn.discordapp.com/attachments/1093195186202476614/1125361298792796250/BIG_DECOMPRESSER__IRIPPER_1.8.TAR
 
 
# CAR TEXTURE PATH
 
 Get your BIG file from the `Cars` folder of the game, note that the big file must have only the car name in it

for CMR 2005: `Cars\Focus\FOCUS.BIG`

For CMR 3/04:  `Cars\FocWRC\FocWRC.BIG`

 

# TEXTURES HIREARCHY 

  example of content of FOCUS.BIG:
  
```
(Foc is the suffix of the car name, in this case Focus):

FocBod.dds - main bodykit texture

FocGla.dds - main window texture

FocGlaD.dds - main broken window texture

FocInt.dds - main interior parts texture

FocLitoff.dds - main lights "off" texture

FocLiton.dds - main lights "on" texture

FocGlove.dds - main driver glove texture

FocDrive.dds - main driveer suit texture

FocFaceBL.dds - main face with eyes closed texture

FocFaceDF.dds - main face with eyes open texture 
```


Select the texture that you want and go to `Actions > extract` to extract the single texture, or you can also extract all if you want. 

Once extracted you can edit the texture in photoshop (with the same nvidia DDS plugin provided for CMR 2.0), then extract it with the same compression. I recommend using infraview to open the dds texture and check its details regarding the compression. 

After saving the edited texture you can import it again in iripper by right clicking the texture you want > click replace, select your texture and save the new BIG file, replace it and see the changes.


# TROUBLESHOOTING

-if iripper fails with a "overflow" error, decompress the file with the big decompressor, then open the decompressed file. 
 
 
-For some reason the texture state it's saved in the savegame data, so to see the changes effectively you must have a clean savegame!

-main texture files (aside from the lights textures) are cross compatible between each other, so the texture of cmr3 can go into the same car of 04 and so on 


