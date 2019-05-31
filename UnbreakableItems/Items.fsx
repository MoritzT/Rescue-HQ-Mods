#r "EMT.Core.dll"
#r "EMT.Modding.dll"
open EMT.Modding

//Oxygen Bottles 
Def.Item.Add {
    ID = "BreathingApparatus"
    Type = Normal [
        Contribution.Asset "BreathingApparatus" Condition.Always            
    ]
    Profession = "FireFighter"
    Events = []
}

///////////////////////////////////
/// 
Def.Item.Add {
    ID = "FoamExtinguisher"
    Type = Normal [
        Contribution.Asset "FoamExtinguisher" Condition.Always            
    ]
    Profession = "FireFighter"
    Events = []
}

//Submersible Pump
Def.Item.Add {
    ID = "SubPump"
    Type = Normal [
        Contribution.Asset "SubPump" Condition.Always            
    ]
    Profession = "FireFighter"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "SubPump" 1]
                0, [Hq.Storage.Create "SubPumpBroken" 1]
            ]            
        ]
    ]
}

Def.Item.Add {
    ID = "SubPumpBroken"
    Type = ItemType.Hidden
    Profession = "FireFighter"
    Events = []
}
Def.ItemMaintenanceTracker "SubPumpBroken"

///////////////////////////////////

//Hazmat Suit
Def.Item.Add {
    ID = "HazmatSuit"
    Type = Normal [
        Contribution.Asset "HazmatSuit" Condition.Always            
    ]
    Profession = "FireFighter"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "HazmatSuit" 1]
                0, [Hq.Storage.Create "HazmatSuitBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "HazmatSuitBroken"
    Type = ItemType.Hidden
    Profession = "FireFighter"
    Events = []
}
Def.ItemMaintenanceTracker "HazmatSuitBroken"

///////////////////////////////////

//Breaching Gear
Def.Item.Add {
    ID = "BreachingGear" //lvl 1: Disc Grinder lvl2: Hydraulic Rescue Tools
    Type = Normal [
        Contribution.Asset "BreachingGear" Condition.Always            
    ]
    Profession = "FireFighter"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "BreachingGear" 1]
                0, [Hq.Storage.Create "BreachingGearBroken" 1]
            ]            
        ]
    ]
}

Def.Item.Add {
    ID = "BreachingGearBroken"
    Type = ItemType.Hidden
    Profession = "FireFighter"
    Events = []
}
Def.ItemMaintenanceTracker "BreachingGearBroken"

///////////////////////////////////

//PaperWork 
Def.Item.Add {
    ID = "PaperWork" //the main police thing 
    Type = StorageOnly
    Profession = "Police"
    Events = []
}

Def.Item.Add {
    ID = "File" //the main police thing 
    Type = StorageOnly
    Profession = "Police"
    Events = []
}

Def.Item.Add {
    ID = "Case" //the main police thing 
    Type = StorageOnly
    Profession = "Police"
    Events = []
}

Def.Item.Add {
    ID = "Evidence" //the main police thing 
    Type = StorageOnly
    Profession = "Police"
    Events = []
}
///////////////////////////////////


//Assault gear
Def.Item.Add {
    ID = "AssaultGear" 
    Type = Normal [
        Contribution.Asset "AssaultGear" Condition.Always            
    ]
    Profession = "Police"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "AssaultGear" 1]
                0, [Hq.Storage.Create "AssaultGearBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "AssaultGearBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "AssaultGearBroken"

///////////////////////////////////

//Sniper Kit
Def.Item.Add {
    ID = "SniperKit"
    Type = ItemType.Normal [
        Contribution.Asset "SniperKit" Condition.Always
    ]
    Profession = "Police"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "SniperKit" 1]
                0, [Hq.Storage.Create "SniperKitBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "SniperKitBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "SniperKitBroken"

///////////////////////////////////

//Drones
Def.Item.Add {
    ID = "Drones"
    Type = ItemType.Normal [
        Contribution.Asset "Drones" Condition.Always
    ]
    Profession = "Police"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "Drones" 1]
                0, [Hq.Storage.Create "DronesBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "DronesBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "DronesBroken"

///////////////////////////////////

//Riot Gear
Def.Item.Add {
    ID = "RiotGear"
    Type = ItemType.Normal [
        Contribution.Asset "RiotGear" Condition.Always
    ]
    Profession = "Police"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "RiotGear" 1]
                0, [Hq.Storage.Create "RiotGearBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "RiotGearBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "RiotGearBroken"

///////////////////////////////////

//Diving kit
Def.Item.Add {
    ID = "DivingKit"
    Type = ItemType.Normal [
        Contribution.Asset "DivingKit" Condition.Always
    ]
    Profession = "Police"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "DivingKit" 1]
                0, [Hq.Storage.Create "DivingKitBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "DivingKitBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "DivingKitBroken"

///////////////////////////////////

//Crowd control
Def.Item.Add {
    ID = "CrowdControl"
    Type = ItemType.Normal [
        Contribution.Asset "CrowdControl" Condition.Always
    ]
    Profession = "Police"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "CrowdControl" 1]
                0, [Hq.Storage.Create "CrowdControlBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "CrowdControlBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "CrowdControlBroken"

///////////////////////////////////

//Bomb Kit 
Def.Item.Add {
    ID = "BombDefusalKit"
    Type = ItemType.Normal [
        Contribution.Asset "BombDefusalKit" Condition.Always
    ]
    Profession = "Police"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "BombDefusalKit" 1]
                0, [Hq.Storage.Create "BombDefusalKitBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "BombDefusalKitBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "BombDefusalKitBroken"

///////////////////////////////////

//K9 unit
Def.Item.Add {
    ID = "K9Unit"
    Type = ItemType.Normal [
        Contribution.Asset "K9Unit" Condition.Always
    ]
    Profession = "Police"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "K9Unit" 1]
                0, [Hq.Storage.Create "K9UnitBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "K9UnitBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "K9UnitBroken"

///////////////////////////////////



//Medical Items

//Crash Cart
Def.Item.Add {
    ID = "ChargedCrashCart"
    Type = ItemType.Normal [
        Contribution.Asset "ChargedCrashCart" Condition.Always
    ]
    Profession = "Medic"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "ChargedCrashCart" 1]
                0, [Hq.Storage.Create "ChargedCrashCartBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "ChargedCrashCartBroken"
    Type = ItemType.Hidden
    Profession = "Medic"
    Events = []
}
Def.ItemMaintenanceTracker "ChargedCrashCartBroken"

///////////////////////////////////

Def.Item.Add {
    ID = "XRay" 
    Type = StorageOnly
    Profession = "Medic"
    Events = []
}

//Contamination Suit
Def.Item.Add {
    ID = "ContaminationSuit"
    Type = ItemType.Normal [
        Contribution.Asset "ContaminationSuit" Condition.Always
    ]
    Profession = "Medic"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "ContaminationSuit" 1]
                0, [Hq.Storage.Create "ContaminationSuitBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "ContaminationSuitBroken"
    Type = ItemType.Hidden
    Profession = "Police"
    Events = []
}
Def.ItemMaintenanceTracker "ContaminationSuitBroken"

///////////////////////////////////

//Cast Material (for Orthopedy)
Def.Item.Add {
    ID = "CastMaterial"
    Type = ItemType.Normal [
        Contribution.Asset "CastMaterial" Condition.Always
    ]
    Profession = "Medic"
    Events = []
}
///////////////////////////////////

//Medicine (for most stations)
Def.Item.Add {
    ID = "Medicine"
    Type = ItemType.Normal [
        Contribution.Asset "Medicine" Condition.Always
    ]
    Profession = "Medic"
    Events = []
}
///////////////////////////////////

//Medikit 
Def.Item.Add {
    ID = "Medikit"
    Type = ItemType.Normal [
        Contribution.Asset "Medikit" Condition.Always
    ]
    Profession = "Medic"
    Events = [
        When.Emergency.Done [
            DoRandom [
                1, [Hq.Storage.Create "Medikit" 1]
                0, [Hq.Storage.Create "MedikitBroken" 1]
            ]
        ]
    ]
}

Def.Item.Add {
    ID = "MedikitBroken"
    Type = ItemType.Hidden
    Profession = "Medic"
    Events = []
}
Def.ItemMaintenanceTracker "MedikitBroken"

///////////////////////////////////
