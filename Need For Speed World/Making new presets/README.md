# Presets - Part 1: Build your car

- in game get your car and customize it, make sure you only have one car purchased to make things easier

- then go to your server profile and find `carslots.xml`, this contains your owned cars with customization parts

# Presets - Part 2: Define the new preset

- Get aaron and unpack `GlobalC.lcz`
  
  - inside `PresetCar` folder, copy paste one of the available presets and rename your file, example `RX7-PICK`
  - then copy paste the entire section of **</CustomCar>** from `carslots.xml` inside your new xml preset in globalC files
  - save the file, close and reopen aaron, export the new globalC file.
  
- The same thing must be done for the server **baskets** file, copy paste one of the available baskets of the car you need and replace
  the same portion mentioned before, ma convention is **SRV-CARXXX** as usual
  
  - TIP: Use **Grepwin** to recursively search inside the baskets for the car you need.
  
  
- Now open `NFS Hasher` and put the **name of the new xml in presetCars folder from globalC** in uppercase,
  
  -  convert the **BIN MEMORY** value from hex to decimal
  - convert it to signed 32bit integer and copy that value
  - open **productsInCategory_NFSW_NA_EP_PRESET_RIDES_ALL_Category.xml**, copy paste a **<ProductTrans>** entry from the exact car you need
  - paste the hash in the **<Hash>** field and change **<ProductId>** to point to the new SRV-CAR basket file for the preset
  - save the file and test in game
  
  
# Missing spoilers

- go into **Cars** folder of extracted globalC, open the json of your car and to the bottom you find this:

```json
 "Spoiler": {
    "SpoilerType": "None"
  }
```

- type can be **small** | **none** | **large**

- save and rebuild the global file