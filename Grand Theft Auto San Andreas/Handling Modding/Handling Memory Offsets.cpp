struct PLUGIN_API tHandlingData { 
    int           m_nVehicleId; 0x384                           - 0x0
    float         m_fMass; 0x388                                - 0x4
    float         field_8; 0x38C                                - 0x8
    float         m_fTurnMass; 0x390                            - 0xC
    float         m_fDragMult; 0x394                            - 0x10
    CVector       m_vecCentreOfMass; 0x398                      - 0x14 // vector of 3 floats. 4 x 3 = 12 bytes (+ 0xc) to next var.
    unsigned char m_nPercentSubmerged; 0x3A4                    - 0x20
    float         m_fBuoyancyConstant; 0x3A8                    - 0x24
    float         m_fTractionMultiplier; 0x3AC                  - 0x28 // aka Traction/grip
    cTransmission m_transmissionData; 0x3B0                     - 0x2C // total size to jump is 0x68
    float         m_fBrakeDeceleration; 0x41C                   - 0x94
    float         m_fBrakeBias; 0x420                           - 0x98
    char          m_bABS; 0x421                                 - 0x9C
    char          field_9D; 0x422                               - 0x9D
    char          field_9E; 0x423                               - 0x9E
    char          field_9F; 0x424                               - 0x9F
    float         m_fSteeringLock; 0x428                        - 0xA0
    float         m_fTractionLoss; 0x42C                        - 0xA4
    float         m_fTractionBias; 0x430                        - 0xA8
    float         m_fSuspensionForceLevel; 0x434                - 0xAC
    float         m_fSuspensionDampingLevel; 0x438              - 0xB0
    float         m_fSuspensionHighSpdComDamp; 0x43C            - 0xB4
    float         m_fSuspensionUpperLimit; 0x440                - 0xB8
    float         m_fSuspensionLowerLimit; 0x444                - 0xBC
    float         m_fSuspensionBiasBetweenFrontAndRear; 0x448   - 0xC0
    float         m_fSuspensionAntiDiveMultiplier; 0x44C        - 0xC4
    float         m_fCollisionDamageMultiplier; 0x450           - 0xC8

 union {  
        eVehicleHandlingModelFlags m_nModelFlags; 0x454         - 0xCC
        struct {
            unsigned int m_bIsVan : 1;
            unsigned int m_bIsBus : 1;
            unsigned int m_bIsLow : 1;
            unsigned int m_bIsBig : 1;
            unsigned int m_bReverseBonnet : 1;
            unsigned int m_bHangingBoot : 1;
            unsigned int m_bTailgateBoot : 1;
            unsigned int m_bNoswingBoot : 1;
            unsigned int m_bNoDoors : 1;
            unsigned int m_bTandemSeats : 1;
            unsigned int m_bSitInBoat : 1;
            unsigned int m_bConvertible : 1;
            unsigned int m_bNoExhaust : 1;
            unsigned int m_bDoubleExhaust : 1;
            unsigned int m_bNo1fpsLookBehind : 1;
            unsigned int m_bForceDoorCheck : 1;
            unsigned int m_bAxleFNotlit : 1;
            unsigned int m_bAxleFSolid : 1;
            unsigned int m_bAxleFMcpherson : 1;
            unsigned int m_bAxleFReverse : 1;
            unsigned int m_bAxleRNotlit : 1;
            unsigned int m_bAxleRSolid : 1;
            unsigned int m_bAxleRMcpherson : 1;
            unsigned int m_bAxleRReverse : 1;
            unsigned int m_bIsBike : 1;
            unsigned int m_bIsHeli : 1;
            unsigned int m_bIsPlane : 1;
            unsigned int m_bIsBoat : 1;
            unsigned int m_bBouncePanels : 1;
            unsigned int m_bDoubleRwheels : 1;
            unsigned int m_bForceGroundClearance : 1;
            unsigned int m_bIsHatchback : 1;
        };
    };
    union { 
        eVehicleHandlingFlags m_nHandlingFlags; 0x458       - 0xD0
        struct {
            unsigned int m_b1gBoost : 1;
            unsigned int m_b2gBoost : 1;
            unsigned int m_bNpcAntiRoll : 1;
            unsigned int m_bNpcNeutralHandl : 1;
            unsigned int m_bNoHandbrake : 1;
            unsigned int m_bSteerRearwheels : 1;
            unsigned int m_bHbRearwheelSteer : 1;
            unsigned int m_bAltSteerOpt : 1;
            unsigned int m_bWheelFNarrow2 : 1;
            unsigned int m_bWheelFNarrow : 1;
            unsigned int m_bWheelFWide : 1;
            unsigned int m_bWheelFWide2 : 1;
            unsigned int m_bWheelRNarrow2 : 1;
            unsigned int m_bWheelRNarrow : 1;
            unsigned int m_bWheelRWide : 1;
            unsigned int m_bWheelRWide2 : 1;
            unsigned int m_bHydraulicGeom : 1;
            unsigned int m_bHydraulicInst : 1;
            unsigned int m_bHydraulicNone : 1;
            unsigned int m_bNosInst : 1;
            unsigned int m_bOffroadAbility : 1;
            unsigned int m_bOffroadAbility2 : 1;
            unsigned int m_bHalogenLights : 1;
            unsigned int m_bProcRearwheelFirst : 1;
            unsigned int m_bUseMaxspLimit : 1;
            unsigned int m_bLowRider : 1;
            unsigned int m_bStreetRacer : 1;
            unsigned int m_bUnused1 : 1;
            unsigned int m_bSwingingChassis : 1;
        };
    };
    float              m_fSeatOffsetDistance; 0x45C
    unsigned int       m_nMonetaryValue; 0x460
    eVehicleLightsSize m_nFrontLights; 0x464   
    eVehicleLightsSize m_nRearLights; 0x468   
    unsigned char      m_nAnimGroup; 0x46C   
};

VALIDATE_SIZE(tHandlingData, 0xE0);


class PLUGIN_API cTransmission {
public:
    tTransmissionGear m_aGears[6]; 0x3B0               - 0x2C // 6 structs of 3 floats. 1 float = 4 bytes so 4 x 3 = 12. 12 x 6 = 72 -> 0x48
    unsigned char m_nDriveType; 0x3F8                  - 0x74
    unsigned char m_nEngineType; 0x3F9                 - 0x75
    unsigned char m_nNumberOfGears; 0x3FA              - 0x76
    char field_4B; 0x3FB                               - 0x77
    unsigned int  m_nHandlingFlags; 0x400              - 0x78
    float         m_fEngineAcceleration; 0x404         - 0x7C
    float         m_fEngineInertia; 0x408              - 0x80
    float         m_fMaxGearVelocity; 0x40C            - 0x84
    int field_5C; 0x410                                - 0x88
    float         m_fMinGearVelocity; 0x414            - 0x8C
    float         m_fCurrentSpeed; 0x418               - 0x90

    cTransmission();
    void InitGearRatios();
    void CalculateGearForSimpleCar(float velocity, unsigned char& currrentGear);
    // it uses printf, so you won't see it actually...
    void DisplayGearRatios();
    float CalculateDriveAcceleration(float& gasPedal, unsigned char& currrentGear, float& gearChangeCount, float& speed, float& unk1, float& unk2, bool allWheelsOnGround, unsigned char handlingType);
};

VALIDATE_SIZE(cTransmission, 0x68);
