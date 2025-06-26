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
