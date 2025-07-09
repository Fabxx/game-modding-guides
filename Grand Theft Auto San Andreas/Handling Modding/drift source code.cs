{$CLEO .cs}
/*
NOTE: 0x384 is a GLOBAL pointer shared between all vehicles, you need to:
- Obtain the car pointer (CVehicle)
- Obtain the vanilla handling struct (CVehicle::tHandlingData)
- Make a copy of the vanilla struct into your new struct to edit
- Edit your struct with your values
- Change the car pointer to your struct instead of the vanilla struct. (CVehile points to my_handling instead of PTR_HANDLING_DATA)
edit your struct copy and then write that into memory.

If vehicle changes or respawns, pointer is restored to vanilla by default.
*/

debug_on

wait 5000
trace "DRIFT SCRIPT BY FABX. ENJOY :)"

int car_handle = -1, prev_car_handle = 0, car_pointer = 0, prev_car_pointer = 0
int vanilla_handling = 0, my_handling = 0, vanilla_drive_type = 0, drift_applied = 0
int reset_enabled = 0

int key_1 = read_int_from_ini_file {path} "cleo\handling.ini" {section} "KEYS" {key} "KB_1"
int drift_pad_1 = read_int_from_ini_file {path} "cleo\handling.ini" {section} "KEYS" {key} "JOYPAD_1"

// Offset Documentation if you want to add more params: https://shorturl.at/7sU8i

const
    m_fMass =                                  0x4
    m_fTurnMass =                              0xC
    m_fDragMult =                              0x10
    m_vecCentreOfMass_x =                      0x14
    m_vecCentreOfMass_y =                      0x18
    m_vecCentreOfMass_z =                      0x1C
    m_fTractionMultiplier =                    0x28
    m_fTractionLoss =                          0xA4
    m_fTractionBias =                          0xA8
    m_transmissionData_m_ndriveType =          0x74
    m_transmissionData_m_nEngineType =         0x75
    m_transmissionData_m_nNumberOfGears =      0x76
    m_transmissionData_m_fEngineAcceleration = 0x7C
    m_transmissionData_m_fEngineInertia =      0x80
    m_transmissionData_m_fMaxGearVelocity =    0x84
    m_fBrakeDeceleration =                     0x94
    m_fBrakeBias =                             0x98
    m_bABS =                                   0x9C
    m_fSteeringLock =                          0xA0

    UCHAR_SIZE =                              1
    PTR_SIZE   =                              4
    HANDLING_STRUCT_SIZE =                    0xE0
    PTR_HANDLING_DATA =                       0x384
end

while true
    wait 0

    if or
        not Player.IsControlOn($player1)
        not Char.IsInAnyCar($scplayer)
    then
        continue
    end

    // obtain car handle to check if vehicle changed, or it has never been obtained.
    Char.StoreCarIsInNoSave($scplayer, car_handle)

    /* If vehicle has changed, apply handling on new struct when key is pressed.
       Restore drive type on global pointer if vehicle changes.
    */
    if and
        car_handle <> prev_car_handle
        car_pointer <> prev_car_pointer
    then
        Memory.WriteWithOffset(vanilla_handling, m_transmissionData_m_ndriveType, UCHAR_SIZE, vanilla_drive_type)
        drift_applied = 0
    end

    if or
        Pad.IsKeyPressed(key_1)
        Pad.IsButtonPressed(0, drift_pad_1)
    then
        if
            drift_applied == 0
        then
            Char.StoreCarIsInNoSave($scplayer, car_handle)
            Memory.GetVehiclePointer(car_handle, car_pointer)
            Memory.Allocate(HANDLING_STRUCT_SIZE, vanilla_handling)
            Memory.Allocate(HANDLING_STRUCT_SIZE, my_handling)
            Memory.ReadWithOffset(car_pointer, PTR_HANDLING_DATA, PTR_SIZE, vanilla_handling)
            Memory.Copy(vanilla_handling, my_handling, HANDLING_STRUCT_SIZE)
        else
            continue
        end

        int val_int
        float val

        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "MASS"
        Memory.WriteWithOffset(my_handling, m_fMass, PTR_SIZE, val)

        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "T_MASS"
        Memory.WriteWithOffset(my_handling, m_fTurnMass, PTR_SIZE, val)

        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "DRAG_MULT"
        Memory.WriteWithOffset(my_handling, m_fDragMult, PTR_SIZE, val)

        // x, y, z  -1.0 to 50000.0
        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "VEC_X"
        Memory.WriteWithOffset(my_handling, m_vecCentreOfMass_x, PTR_SIZE, val)

        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "VEC_Y"
        Memory.WriteWithOffset(my_handling, m_vecCentreOfMass_y, PTR_SIZE, val)

        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "VEC_Z"
        Memory.WriteWithOffset(my_handling, m_vecCentreOfMass_z, PTR_SIZE, val)

        //m_fTractionMultiplier - turn slower/faster
        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "T_MULT"
        Memory.WriteWithOffset(my_handling, m_fTractionMultiplier, PTR_SIZE, val)

        //m_fTractionLoss - the lower, the more grip you lose while steeering
        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "T_LOSS"
        Memory.WriteWithOffset(my_handling, m_fTractionLoss, PTR_SIZE, val)

        //m_fTractionBias - Move the grip towards the front or rear. Higher the value, faster the steering.
        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "T_BIAS"
        Memory.WriteWithOffset(my_handling, m_fTractionBias, PTR_SIZE, val)

        //m_transmissionData->m_ndriveType - values accepted: F: 70, R: 82, 4: 52 - Unsigned char, size 1
        // type 4 gives more grip and turns faster.
        // Takes effect only if edited on the global shared pointer 0x384! Making backup to restore it there too.
        Memory.ReadWithOffset(vanilla_handling, m_transmissionData_m_ndriveType, UCHAR_SIZE, vanilla_drive_type)

        val_int = read_int_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "DRIVE_TYPE"
        Memory.WriteWithOffset(vanilla_handling, m_transmissionData_m_ndriveType, UCHAR_SIZE, val_int)

        //m_transmissionData->m_nEngineType - values accepted: P: 80, D: 68, E: 69
        val_int = read_int_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "ENGINE_TYPE"
        Memory.WriteWithOffset(my_handling, m_transmissionData_m_nengineType, UCHAR_SIZE, val_int)

        //m_transmissionData->m_fEngineAcceleration
        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "ENGINE_ACCEL"
        Memory.WriteWithOffset(my_handling, m_transmissionData_m_fengineAcceleration, PTR_SIZE, val)

        //m_transmissionData->m_nNumberOfGears - unsigned char from 1 to 6
        val_int = read_int_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "N_GEARS"
        Memory.WriteWithOffset(my_handling, m_transmissionData_m_nNumberOfGears, UCHAR_SIZE, val_int)

        //m_fBrakeDeceleration, 0.1 to 10.0
        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "BRAKE_DECEL"
        Memory.WriteWithOffset(my_handling, m_fBrakeDeceleration, PTR_SIZE, val)

        //m_fBrakeBias, 0.0 > x > 1.0 a value between this range
        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "BRAKE_BIAS"
        Memory.WriteWithOffset(my_handling, m_fBrakeBias, PTR_SIZE, val)

        //m_bABS, 0 or 1, unsigned char 1 byte
        val_int = read_int_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "ABS"
        Memory.WriteWithOffset(my_handling, m_bABS, UCHAR_SIZE, val_int)

        //m_fSteeringLock
        val = read_float_from_ini_file {path} "cleo\handling.ini" {section} "HANDLING" {key} "STEER_ANGLE"
        Memory.WriteWithOffset(my_handling, m_fSteeringLock, PTR_SIZE, val)

        // Change default vehicle tHandlingData pointer to your custom pointer.
        Memory.WriteWithOffset(car_pointer, PTR_HANDLING_DATA, PTR_SIZE, my_handling)
        drift_applied = 1
        prev_car_handle = car_handle
    end

    if and
        not Pad.IsKeyPressed(key_1)
        not Pad.IsButtonPressed(0, drift_pad_1)
        drift_applied == 1
    then
        Memory.WriteWithOffset(vanilla_handling, m_transmissionData_m_ndriveType, UCHAR_SIZE, vanilla_drive_type)
        Memory.WriteWithOffset(car_pointer, PTR_HANDLING_DATA, PTR_SIZE, vanilla_handling)
        drift_applied = 0
    end
end

function TRACE_HANDLING(handling: int)
    float val
    int val_int
    debug_on

    trace "-------------------------"
    Memory.ReadWithOffset(handling, m_fMass, PTR_SIZE, val)
    trace "m_nfMass: %f" val

    Memory.ReadWithOffset(handling, m_fTurnMass, PTR_SIZE, val)
    trace "m_fTurnMass: %f" val

    Memory.ReadWithOffset(handling, m_fDragMult, PTR_SIZE, val)
    trace "m_fDragMult: %f" val

    Memory.ReadWithOffset(handling, m_vecCentreOfMass_x, PTR_SIZE, val)
    trace "m_vecCentreOfMass_x: %f" val

    Memory.ReadWithOffset(handling, m_vecCentreOfMass_y, PTR_SIZE, val)
    trace "m_vecCentreOfMass_y: %f" val

    Memory.ReadWithOffset(handling, m_vecCentreOfMass_z, PTR_SIZE, val)
    trace "m_vecCentreOfMass_z: %f" val

    Memory.ReadWithOffset(handling, m_fTractionMultiplier, PTR_SIZE, val)
    trace "m_fTractionMultiplier: %f" val

    Memory.ReadWithOffset(handling, m_fTractionBias, PTR_SIZE, val)
    trace "m_fTractionBias: %f" val

    Memory.ReadWithOffset(handling, m_transmissionData_m_ndriveType, UCHAR_SIZE, val_int)
    trace "m_transmissionData_m_ndriveType: %c" val_int

    Memory.ReadWithOffset(handling, m_transmissionData_m_nEngineType, UCHAR_SIZE, val_int)
    trace "m_transmissionData_m_nEngineType: %c" val_int

    Memory.ReadWithOffset(handling, m_transmissionData_m_fEngineAcceleration, PTR_SIZE, val)
    trace "m_transmissionData_m_nEngineAcceleration: %f" val

    Memory.ReadWithOffset(handling, m_fBrakeDeceleration, PTR_SIZE, val)
    trace "m_fBrakeDeceleration: %f" val

    Memory.ReadWithOffset(handling, m_fBrakeBias, PTR_SIZE, val)
    trace "m_fBrakeBias: %f" val

    Memory.ReadWithOffset(handling, m_bABS, UCHAR_SIZE, val_int)
    trace "m_bABS: %d" val_int

    Memory.ReadWithOffset(handling, m_fSteeringLock, PTR_SIZE, val)
    trace "m_fSteeringLock: %f" val
end
