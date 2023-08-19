# EXTRACTION

`fsbext -M -s dump_files.dat input.fsb`

# REPACK

`fsbext -M -s dump_files.dat -r output.fsb`

To change the ext directory, use `-d nameoffolder`. before make sure to create the folder.

example: `fsbext -M -d output_folder -s dump_files.dat -r output.fsb`

-M is for multiple channel audio files.

# SETUP XBOX ADPCM AND SNDREC32

After extracting audio files and got your custom wav, install the `XBOX ADPCM` inf file by doing 
right click -> install.

Then open `sndrec32.exe`

File -> open... your wav file

then file -> Properties

Click on `convert now`, on format section, select `XBOX ADPCM`, for the sampling, see the original Hz of
the file you want to edit and apply the same Hz as the original. Click convert then save.

After doing so, replace the wav file in the extracted sounds directory, then use the 
repack command given above, and you got your edited FSB file.


NOTE: rename the output.fsb in the name of the fsb you want to replace
