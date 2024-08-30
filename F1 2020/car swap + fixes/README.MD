# GETTING THE FILES

first you need to install F1 2017/2018/2019 depending on which car model you want to swap

NOTES: F1 2018 Classic cars have this path name: f1_classic_02_vehicle_package
       F1 2019 Classic cars have this path name: f1_2019_classic_vehicle_package

# 2018 CARS TO 2020 (can also work with 2019 cars)

copy from 2018 asset_groups/f1_2018_vehicle_package into 2020_asset_groups

copy from 2018 f1_2018_vehicle_package from the main game folder into 
the 2020 main game folder (for textures)

then go to the car erp file in 2020_asset_groups/f1_2020_vehicle_package/teams/team_name

modify the assetgroup file by adding two lines like this:

```
<?xml version="1.0" encoding="utf-8"?>
<!--This file was automatically generated-->
<AssetGroup bigERP="true">
  <!--common big erp-->
  <ERP>2020_asset_groups/f1_2020_vehicle_package/teams/common.erp</ERP>
  <ERP>2020_asset_groups/f1_201x_vehicle_package/teams/common.erp</ERP> (added line)
  <!--specific big erp-->
  <ERP>2020_asset_groups/f1_2020_vehicle_package/teams/ferrari/wep/ferrari.erp</ERP>
  <ERP>2020_asset_groups/f1_201x_vehicle_package/teams/ferrari/wep/ferrari.erp</ERP> (added line)
</AssetGroup>

```

where "x" is the number of the year of the game files used (if you want classic cars or other modern cars, just change the path name
 on the two added lines.)

save, then use ERP archiver and go to PKG section

extract `carmodel.layer` and `carshowroom.layer`

edit the `"model"` section in `carmodel.layer`

there are two sections: `mat binding` and `model`

replace the 2020 number in the name into 2018, so it will load the model from the other 
folder directly

do this for both layer files, save them and import them

replace the assetgroup and erp files and enjoy 2018 models


# 2017 models guide (partial, might not work properly)

A bit different, for ferrari, williams and haas it's the same as above

for the others, here are some extra steps:

the mat binding must remain 2020

then from 2017 models you have to export these textures, and import them into 2020 files

`wheel d (or a, depends on the name applied), n, s` 

`Steering wheel decal main file (should be d),` 

`paint n, s,`  

`paint s, d, c, n (check if in the files are available these letters, might differ)`  

`decal s, decal da,`  

and dirt and damage file

when replacing mipmaps will be generated

the generated mipmaps must go into the f1_2020_vehicle_package folder in 
the MAIN game folder, inside the desired texture folder of the team.

test in game and see

NOTE:

As for texture modding, if you use the 2017 mat binding, you'll have to mod the 2017 car ERP files!

if you use 2020 mat binding, you have to replace the textures in the 2020 ERP car file!

just replace the livery file mentioned above (decal s and the main decal file)




# TO FIX TIRES FOR REPLACED CLASSIC CARS FROM 2018/2019 INTO MODERN CARS:


FIRST:
basically extract both 2020 `common.erp` and `classic` (f1_classic_02_vehicle_package, not 2019!) 
common.erp resources, then rename the classic TYRE resource materials with 2020 names, 
replace them in the folder where you exported 2020 resources and do "import all" 
from the ERP archiver in the resources section.

SECOND:

Now we need to assign to each car the set of tyres we want. First, see which classic car has the tyres you want (goodyear, bridgestone etc)

then open that erp file in the tool, and export the carmodel.json file.

Find these sections:

```
"Tyres": {
            "PkgObjectVersion": 0,
            "material": "stri eaid://f1_2019_classic_vehicle_package/shared/tyres/idf/c_05_tyres.emb",
            "tyre model": "stri eaid://f1_2019_classic_vehicle_package/shared/tyres/idf/c_05_tyres.idf?context=render",
            "tyre wet model": "stri eaid://f1_2019_classic_vehicle_package/shared/tyres/idf/c_05_tyres_wet.idf?context=render",
            "tyre_physics_group": "shnm 70",
            "wet material": "stri eaid://f1_2019_classic_vehicle_package/shared/tyres/idf/c_05_tyres_wet.emb?context=wet"
          },
          
          
          "VehicleSpawnData": {
            "PkgObjectVersion": 0,
            "blob_shadow_decal": "stri eaid://f1_2019_classic_vehicle_package/shared/ao/materials/c_ferrari_76_blobshadowdecal.material"
          }
```
        
      
Now export the modern `carmodel.json` car file, and you have to ADD these sections after 
the `"spotlight"` section

then on the modern car you will see this:

`"template": "stri F1CarModern2020"`

change it with the template name you find in the classic car json model, example for 2019 classic car:

`"template": "stri F1CarClassic2019"`


save and you've changed the tyres, but not in menu yet! for that you have to do the same steps 
of copy-pasting, but in the carshowroom.json file! after the `"VehicleShowroomComponent"` section.

THIS TIME YOU DON'T NEED TO EDIT THE CAR TEMPLATE.

NOTE: if you only want to change tyre textures and not the tyre model as well, keep only 
the `"material"` and `"wet_material"` section in "Tyres"


# TO FIX MIRRORS:

again extract both modern and classic car resources (if you haven't already), but this 
ime the replacement is the other way around, example:

find modern ferrari mirrors material files in the resources (in "materials" folder once extracted)

rename them into the classic car that you are using for ferrari

replace the classic mirrors with modern ones

import resources into classic car file and save



# TO SWAP AUDIO:

Export the carmodel.json package from modern car

find this section:


```
"AudioF1Car": {
            "PkgObjectVersion": 0,
            "bundleName": "stri classic_v10.bdl",
            "enable exhaust bundle stream": "bool True",
            "engine_offsetY": "fp32 0.3",
            "engine_offsetZ": "fp32 -0.2",
            "enginedownshiftLoadLag": "fp32 0.15",
            "engineTorqueThrottleMixer": "fp32 0.15",
            "exhaust_offsetY": "fp32 0.26",
            "exhaust_offsetZ": "fp32 -2",
            "exhaustdownshiftLoadLag": "fp32 0.15",
            "exhuastTorqueThrottleMixer": "fp32 0.15",
            "frontwing_offsetY": "fp32 -0.2",
            "frontwing_offsetZ": "fp32 3",
            "rearwing_offsetY": "fp32 0.6",
            "rearwing_offsetZ": "fp32 -2.2",
            "switchName": "stri Sauber"
          },
```
          
          
replace bundleName string with the name of the bdl file located in "audio" folder of 
the game install
          
          
# TO SYNC AUDIO WITH HIGER ENGINE REVS:

Export both calssic and modern car vtf xml files called 
`"car_name!!!temp000.vtf"` inside the main car erp file

open the classic car file, and copy paste these parameters into the modern car:


NOTE: THIS SECTION ALTERS THE ENGINE POWER, IF YOU JUST WANT TO ADJUST THE REVS USE 
THE PARAMETERS BELOW THIS SECTION.

NOTE 2: If you changed the revs only but the engine is too weak still, paste this section of 
the revs power spline as well (not actually this one, this is just an example 
of what it looks in your xml)

To port the performance of classic cars into modern, you need all the parameters from these sections:

```
<RevsPowerSpline numVertices="xx">
</RevsPowerSpline>

<RevsFrictionSpline>

<RevsEngineBrakingSpline>

<RevsTurboLagSpline> (if different from vanilla)

<Mass>

<Inertia>

<MinIdleRateFactor>

<MaxLimiterRateFactor>

<IdleRotationRate>

<LimiterRotationRate>

<TurboMode>

<GearBox>

```

NOTE: Mercedes VTF file is inside `common.erp`

NOTE 2: if on force india file the vtf gives a "premature end of stream" error, use Ego ERP Archiver 8.0.1. 
         for other files 9.0 should work fine

save and import again the modern car xml file edited.
          
          
# TO FIX CAMERAS:

Extract both classic and modern car package file called 
`"camscargame"` json file (NOT camscargame_ss json file!)


scroll down until you find the camera attachments, here is an example of the 
`PodOffset` camera attachment:

each attachment has a `"Offset"` and `"Rotation"` vector coordinates

```
{
        "PkgObjectVersion": 0,
        "name": "stri camscargame$CameraAttachmentPointPodOffset",
        "overrides": {
          "PkgObjectVersion": 0,
          "AttachmentPoint": {
            "PkgObjectVersion": 0,
            "Attachment name": "shnm podoffset",
            "Collection name": "shnm c_ferrari_76",
            "Group name": "shnm vehiclecameras",
            "Offset": "vec3 0.12,0.84,-0.88",
            "Rotation": "vec3 9,0,0"
          },
          "WorldObject": {
            "PkgObjectVersion": 0,
            "transform": "mat4 1,0,0,0;0,0.9961947,0.08715574,0;0,-0.08715574,0.9961947,0;0.14,0.66,0.01,1"
          }
        },
```
        
   what you have to do here, is to obtain the classic car 
   `"Offset"` and `"Rotation"` values, and copy paste them in the modern car values.
   
   same thing for the `"transform"`



# TO FIX ANIMATIONS AND DRIVER POSITION IN CARS (example for 70s and 80s cars replaced with modern):

Copy the classic car animation files from F1 2019 
`(asset_groups/animation_package/scenes/incardriver/1980 folder)` 
into your `"incardriver"` game folder, alongside the "2020" folder.


open the file `incardriver_f1.assetgroup` from 2020 folder and edit it like this:

```
<?xml version="1.0" encoding="utf-8"?>
<!--This file was automatically generated-->
<AssetGroup bigERP="true">
  <ERP>2020_asset_groups/animation_package/scenes/incardriver/2020/incardriver_f1.erp</ERP>
  <ERP>2020_asset_groups/animation_package/scenes/incardriver/1980/incardriver.erp</ERP> (added line)
</AssetGroup>
```


save, then open the `incardriver_f1.erp` file into the EGO tool, 
export the `incardriver.xml` file. Same thing for the `1980` incardriver file.

each car has its animation programmed like this:

```
<scene name="classics_incar_driver_body_c_lotus_78">
    <actor type="InCarDriverActor" id="InCarDriver">
      <part id="InCarDriver" culling="Bip01" cullingradius="3.0" overrideMeshIndex="0" mesh="eaid://character_package/condition_scene/idf/driver_body_male">
        <animset name="animations_driver_in_car/driver_steering_anims/idf/driver_in_car_1978_lotus" />
        <animset name="MACRO animset" />
      </part>
    </actor>
  </scene>
```
  
  
  the scene name is the name of the car you want, we need to change the animset name 
  string with the name of the car with the animation we want.
  
  so:
  `<animset name="animations_driver_in_car/driver_steering_anims/idf/driver_in_car_1978_lotus" />`
  
  becomes:
  
  `<animset name="animations_driver_in_car/driver_steering_anims/idf/driver_in_car_2002_ferrari" />`
  
  we just replace the year and the car name, save and import the xml, save the erp and replace 
  the erp of 2020 "incardriver_f1.erp"
  
  
  
# FIX CAR POSITION IN SHOWROOM:

extract the `carshowroommodel.json` file of the car you need to adjust and find this section:

`"VehicleShowRoomComponent"`, and change the `"vtfAsset"` file to the one of the classic 
car you're using.

  
