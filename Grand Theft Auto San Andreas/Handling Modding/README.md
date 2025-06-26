# Variables

- `Drag`, the vehicle's aerodynamic drag coefficient (CX Coefficient)

- `Grip`, the overall grip that is recalculated with other values ​​every frame.

- `GripLoss`, the loss of grip when cornering.

- `GripBias`. 0.5 represents 50/50 grip. You can Move the grip to the front wheels to
spin more and make the rear wheels slide.

- `Transmission->SpeedLimit`, Maximum vehicle speed. The value is linked to the
`HANDLING FLAGS`. These flags manipulate the maximum speed value to
adapt it to physics. For example, if the value is 200 but in game it reaches 186, the FLAGS
are applying a sort of limiter. Furthermore, this parameter does not only increase
the maximum speed, but also increases the horsepower of the engine.

- `HFLAG`: Flag that indicates how to handle the maximum speed.
- `0x1000000` means `USE_MAXSP_LIMIT`
- See the `eVehicleHandlingFlags` enum definition for the list of codes.

- `Accel` (m_fEngineAcceleration): Vehicle acceleration value, multiplied by 10 returns the original vehicle horsepower. If you change speedLimit and also tap Accel, make sure Accel x 10 returns the same value as speed. You may not need to tap Accel if the vehicle has enough horsepower.

- `Transmission->R field`: Vehicle drive type, accepts the following values:

- `R`: Rear wheel drive
- `F` Front wheel drive
- `4` All wheel drive.

- `Steer Limit`: Limit the steering angle on the wheels

- `Mass`: Total weight of the vehicle

- `Turn Mass`: Weight while turning
  - If changed, they reduce the engine braking of the vehicle.
  - You don't lose speed when cornering even if you let go of the accelerator

- `m_vecCentreOfMass.xyz`: 3D vector that controls the movement of the vehicle's weight:
  - x = left or right
  - y = forward or backward
  - z = up and down in rotation.


# Handling Data

https://github.com/DK22Pac/plugin-sdk/blob/master/plugin_sa/game_sa/cTransmission.h

tHandlingData structure: `0x384`

Offset of the `m_transmissionData` structure: `0x384 + 0x2C` -> `0x3B0`

NOTE: The pointer is always 32 bits, since the game architecture is 32 bits (4 bytes)

To drift, move the Y mass to the front with positive values. The Z mass to a slightly negative value to point down. The X axis remains unchanged.

the front wheels will be glued to the ground, and the rear ones do not touch the back to angle the vehicle. The decimal value represents 10% of the base. So 0.1 = 10%, 0.2 = 20% and so on.

The percentage is calculated from the `Mass` value, so if I use 01., it moves 10% of the vehicle's Mass to the front


# Project Cerbera Docs

https://projectcerbera.com/gta/sa/tutorials/handling


