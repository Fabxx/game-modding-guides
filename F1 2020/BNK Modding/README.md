NOTE: This method has been tested only from 2017 bnk files and upwards until 2020.

# Initial Setup

get this tool: https://github.com/hpxro7/wwiseutil


# File List

```
music_frontend.bnk - contains music for menus

music_persistent.bnk - contains loading screen music and others

```


# Working on files


with the tool open the music_frontend.bnk, this will give in the UI a list of wem files, plus the ID of those.

here is a list i've doucmented so far for the WEM files:

```
2018 music_frontend.bnk:

01 is multiplayer menu music

02 is driver career menu music

03 is main menu music

04 is title screen music

05 is championship menu music

06 is events menu music

07 is a song

08 is options menu music

09 is grand prix mode menu music

10 is (presumably) character customization

11 is time trial menu music


from 2020 it does not contain my team music, carreer musics, showrooms.



2020 files music_frontend.bnk:

01: my team menu/driver career music

02: main menu music

05: time trial menu music

08: customization menu music

10: grand prix menu music

14: championship menu music

17: title screen menu music

20.wem: game options menu music


2020 music_persistent.bnk

03: loading music

```



What you can do with the tool is to replace the WEMs, and test them in game.



# BNK Extraction

either use the tool mentioned before, or this:

https://github.com/eXpl0it3r/bnkextr

with both you can extract the WEM files


# WEM to WAV conversion (and viceversa) PENDING

# WEM to OGG conversion

use this tool: https://github.com/WolvenKit/wwise-audio-tools 



# Notes

the bnks can be edited with the first tool, no need to necessarily convert the files to WAV or OGG, though it can be helpful to understand which audio file it is before replacing.
