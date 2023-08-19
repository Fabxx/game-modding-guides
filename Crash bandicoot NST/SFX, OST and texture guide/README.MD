# Initial setup

Get the alchemist tool from here:

https://www.mediafire.com/file/qhtu9qrumnop1gx/Alchemist_BETA_v1.10.zip/file

open the tool and in the settings, setup the tool with the path to your game directory of the specific plaform (in our case PC)


# Creating your update.pak

  -get the smallest file.pak in size since it will have very few file trees, `bumper_atvi.pak`
  
  -rename it into `update.pak`
  
  -now, to replace a vanilla file with this method we override it, so you need to open the pak file
  that contains the file you want to replace, then once detected do this:
  
  -open again your update.pak
  
  -press `import from pak`
  
  -select the tree you want to import or expand the tree and select only the single file you need.
  
  -apply the changes and save the pak, now you have the vanilla file to repalce.
  
  
 # REPLACING SFX 
 
  NOTE: you need to import the SFX from the pak file you need first.
  
  generic path for the SFX shared in between the paks:
  
  path for bonus drum intros: `sound_samples > wavs > Music`

  path for bonus main loop and OSTs: `sound_streams > wavs > Music`
  
  path for SFX: `sound_samples > wavs > your_tree_of_sfx_imported`
  
  the OST has in the file name the level name and level number, example with crash 1 
  and n.sanity beach:
  
  `CB101_NSanityBeach` in the name
  
  `1` is the title number
  
  `01` is the number of the level
  
  NOTE: you can also play the audio file while clicking on it to get a preview.
  once you found your imported wav file you can export it  
  
# OST notes
``

    exported music file must be:
    
    -less than `2:52` minutes
    
    -codec at `48000Hz 128kbps mp3`
    
    after this, you can import your file by clicking on a file and use the `replace` option
    
    save the pak and test.
    
    
# FIX SFX LOW VOLUME

	with alchemist, find the sound bank you need and extract it from `sounds > banks`

	open that bank file in alchemist

	dig up in the content sections, the sounds that can be changed are labeled as `"CSubSound"`

	then click on a audio reference, it will display hex values. Default volume for hex is `00 00 80 3F`

	you have a float value of that hex value, which is `1`. So change that number 1 into something higher.

	Save the bank, import the vanilla bank in your pak file, then do "Replace" on the bank with your modded one

	save and test!
	
	
	
# ADDITIONAL NOTES ON MP3 FORMAT

	for OSTs and SFX, the mp3 encoder adds an empty second at the beggining, to get rid of that you need to use FMOD.
	
	-get the mp3, remove the blank part at the beginning and export as ogg
	
	-throw it in the FMOD Sound Generator and convert it to mp3 again
	
	-rename the exported file extension from `.mp3` to `.snd`
	
	-import the snd file in the pak file.
 
 
# REPLACING TEXTURES

	same thing as above, find the original texture in the pak and import it into your update.pak
	
	then export the texture, edit it and import it back.
