# REQUIREMENTS

- [Need For Speed World Unlimiter](https://github.com/NFSTools/NFSWorldUnlimiter)

- [dinput8.dll ASI loader](https://github.com/ThirteenAG/Ultimate-ASI-Loader/releases/tag/v9.7.4)

- [NFS VLT-Editor](https://nfs-tools.blogspot.com/2019/02/nfs-vlted-v46-released.html)

- [Aaron](https://github.com/NFSTools/Aaron)

- [NFS Hasher](https://github.com/CiPH3R-88/NFS_Hasher_v3.0)

- [NFS LangEd](https://nfs-tools.blogspot.com/2010/01/nfs-langed-v050-released.html)


# CLIENT MODDING

- Open Aaron tool and select your `GlobalC.lcz` file in `CARS` folder of NFS World.

- export its content in a folder

- add a new entry in cars tab, this will generate two parameters:
  - **BaseCarId**
  - **physicsProfileHash**
  
- inside the `PresetCar` folder, copy-paste one of the presets, like **240SX_base_1.xml**
  - Rename it and keep the `_base_1.xml` suffix, for example **BMWM3GTRE46_base_1.xml**
  - open **NFS Hasher** and type the name of the XML file in **UPPERCASE**, without the extension (BMWM3GTRE46_BASE_1)
  - take the BIN MEMORY value and convert it to decimal, that will be your **<BaseCar></BaseCar>** hash field
    - convert the value from unsigned to signed 32bit integer with [this](https://onlinetoolz.net/unsigned-signed), if it goes above 
	  the 32 bit representation you need the negative value.
	- Do the same for **<PhysicsProfileHash></PhysicsProfileHash>** value
  - Now once you have used those two values, change the **<Name></Name>** field how you want example **<Name>bmwm3gtre46</Name>**
  - Make sure the xml does not have any aftermarket parts or else the model will look bugged
  - save the project, close and reopen Aaron tool to refresh the presets
  - save globalC file with the new preset
  
 
# SERVER - BASKET FILE

-  go to your **NFSW Offline server** files in `\www\soapbox\Engine.svc\baskets` (or `data\basket` if using the nodeJS server)

-  copy-paste the preset file made with aaron, rename it into **SRV-CARxxxx** (example: **SRV-CARM3E46GTR.xml**)

-  edit **productsInCategory_NFSW_NA_EP_PRESET_RIDES_ALL_Category.xml**, you need to add the block for your basket. Example:
  
```xml
<ProductTrans>
		<BundleItems i:nil="true"/>
		<CategoryId i:nil="true"/>
		<Currency>CASH</Currency>
		<Description/>
		<DurationMinute>0</DurationMinute>
		<Hash>2101215339</Hash>
		<Icon>Red_64x64</Icon>
		<Level>0</Level>
		<LongDescription/>
		<Price>0</Price>
		<Priority>0</Priority>
		<ProductId>SRV-CARM3GTRE46</ProductId>
		<ProductTitle>RESTORED</ProductTitle>
		<ProductType>PRESETCAR</ProductType>
		<SecondaryIcon/>
		<UseCount>1</UseCount>
		<VisualStyle/>
		<WebIcon/>
		<WebLocation/>
	</ProductTrans>
```

- description of the needed fields:
   - **Currency**: specify if car is purchasable with CASH or SPEEDBOOST
   - **Hash**: This must be the same as your BaseCar value from the basket or the preset
   - **Icon**: pick which icon you want to display on the car dealership
   - **price**: The cost of the car
   - **ProductID**: This must call the new basket file you have added in the baskets folder
   - **ProductTitle**: the title of the car preset in the dealership
   

# CAR LOCALIZATION STRING

- Open the language editor and open the file **English_Global.bin** located in `LANGUAGES` folder

- add a **CAR_MDL_CARFOLDERNAME** string, where CAR_MDL is a fixed prefix, after that, you need to insert the 
  **name of the car folder inside CARS**, example the m3 gtr has **BMWM3GTRE46** folder in the game files, so the string
  becomes **CAR_MDL_BMWM3GTRE46**
  
- define the name of the car as you want, but don't put the manufacturer string inside, that's already defined from the baskets
  - example: instead of typing **BMW M3 GTR E46 (RACE SPEC)**, you type **M3 GTR E46 (RACE SPEC)**
  
- save the file with the new string

# VLT-EDITOR - pvehicle and ecar nodes

- In case your car does not have **pvehicle** and **ecar** nodes, you'll have to recreate them from scratch.
  for instance the 918RSR didn't have them, luckily they were inside the build `1548` from 2013, 
  if not you'll have to remake from scratch the following nodes: 

  - **camerainfo**
  - **pvehicle**
  - **ecar**
  
- each node has inside other node references, so those must be restored too, example:
	- pvehicle -> **car1072** which is the 918 RSR, car1072 inside also references:
	  - **car1072->transmission**, which then also has subnodes like this: 
	    - **car1072->transmission_a** 
		- **car1072->transmission_h** 
		- **car1072->transmission_t**

- what you can do is copy paste an existing note, example **car1060** and rename it in car1072, same thing for the subnodes. 
  Then for each value  in the beta build, click "insert", this  will generate the command to update the field with the original parameter.
  
- Now do this for ALL the required nodes and fields, and copy paste all the commands in a **txt** file.
   rename the **.txt** extension into **.nfsms** and import the modscript with VLT-ED. Done! you have now updated the fields.

   NOTE: if some fields are missing compared to the beta build, right click on the node and do "edit fields", there
         you can add the missing fields, or resize arrays if they have different size.   


# AFTERMARKET PARTS - GENERIC PARTS

- The provided modscript already points to all the nodes for the generic parts.
  The first default index is **207**, second default index is **206**. If you have added one car,
	 replace all 207 with **208**, and **206** with **207**, it basically increments by one. 

- Then you have to replace ((BASE CAR HASH HERE)) with the BaseCarID provided by aaron, this time **no conversion is needed**, just take the ID as it is
	and replace it on all the nodes that require it. Then import with VLT-ED and you're done.
	
- Repeat this for **each single car you have added**, so you have to process the indexes one at the time.