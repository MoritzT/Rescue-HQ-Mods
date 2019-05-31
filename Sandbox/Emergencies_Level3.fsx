#load "EmergencyShared.fsx"
open EMT.Modding
open EmergencyShared

Def.Emergency.Add {
    ID = "CarChase"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 2.0
    }
    Tags = {
        Visible = ["Pursuit"]
        Hidden = ["Police";"Tier1";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "CarChase_Title"
    InitialDescriptionKeys = ["CarChase_Desc01"]
    AssetRequirements = [
        "Police" , 2, 40 //80
        "Police" , 4, 5 //20
        "HighPowerCar", 1, 20 //20
    ]
    PreparationTime = Gt.hours 0.75
    ResolutionTime = Gt.hours 1.5
    MoneyGainOnSuccess = 3000
    ReputationGainOnDispatch = 0, 60
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [
            AddXp 10.0
            AddExhaustion 3.0
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 5
            AddInjury 0.05 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.2 0.4 ["Medium"]
            SetMood -2.0
            
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HouseFireMedium"
    Type = Type.FireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 5.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Urban";"Critical"]
        Hidden = ["FireDept";"HeatWave";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HouseFire_Title"
    InitialDescriptionKeys = ["HouseFire_Desc_House03"; "HouseFire_Desc_Apartment03"]
    AssetRequirements = [
        "BreathingApparatus", 6, 5 //30
        "FireFighter", 4, 10 //40
        "Ladder", 1, 10 //10
        "HighLadder", 1, 15 //10
        "Tank", 1, 10 //10
        "BreachingGear", 1, 10 //10
    ]
    PreparationTime = Gt.hours 1.5
    ResolutionTime = Gt.hours 1.8
    MoneyGainOnSuccess = 3400
    ReputationGainOnDispatch = 1, 80
    ReputationCostToTerminate = Some (40, 40)
    Events = [
        When.Emergency.Success [
            AddXp 11.0
            AddExhaustion 3.0
            AddInjury 0.02 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HouseFireMediumRescue01"
    Type = Type.MedicalFireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 3.0
        Night = 5.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept";"Medical";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HouseFire_Title"
    InitialDescriptionKeys = ["HouseFire_Desc_House04"; "HouseFire_Desc_Apartment04"]
    AssetRequirements = [
        "BreathingApparatus", 8, 2 //16
        "FireFighter", 6, 10 //60
        "Ladder", 1, 15 //15
        "HighLadder", 1, 20//20
        "Medic" , 1, 4 //4 
        "Tank", 1, 5 //5
    ]
    PreparationTime = Gt.hours 1.0
    ResolutionTime = Gt.hours 1.2
    MoneyGainOnSuccess = 4200
    ReputationGainOnDispatch = 0, 90
    ReputationCostToTerminate = Some (45, 45)
    Events = [
        When.Emergency.Success [
            AddXp 11.0
            AddExhaustion 3.0
            AddInjury 0.02 0.1 ["Light"]
            SetMood 1.0
            If.Chance 0.8 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "FloodedBasement"
    Type = Type.FireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 5.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Industrial"]
        Hidden = ["FireDept";"USA";"OnLand";"UnderSiege";"Berlin"]
    }
    TitleKey = "Flooded_Title"
    InitialDescriptionKeys = ["Flooded_Desc01"]
    AssetRequirements = [
        "SubPump", 1, 40 //40
        "FireFighter", 6, 10 //60
        "FireFighter", 5, 8 //40
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 3200
    ReputationGainOnDispatch = 0, 80
    ReputationCostToTerminate = Some (40, 40)
    Events = [
        When.Emergency.Success [
            AddXp 11.0
            AddExhaustion 3.0
            AddInjury 0.0 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HouseFireMediumRescue02"
    Type = Type.FireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban";"Critical"]
        Hidden = ["Medical";"FireDept";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HouseFire_Title"
    InitialDescriptionKeys = ["HouseFire_Desc_Apartment05"]
    AssetRequirements = [
        "BreathingApparatus", 5, 3 //15
        "FireFighter", 4, 10 //40
        "Ladder", 2, 10 //20
        "HighLadder", 1, 20 //20
        "Medic" , 1, 20 //20
        "BreachingGear", 1, 5 //5
    ]
    PreparationTime = Gt.hours 1.5
    ResolutionTime = Gt.hours 1.5
    MoneyGainOnSuccess = 4500
    ReputationGainOnDispatch = 0, 100
    ReputationCostToTerminate = Some (25, 50)
    Events = [
        When.Emergency.Success [
            AddXp 1.0
            AddExhaustion 3.0
            AddInjury 0.02 0.1 ["Light"]
            SetMood 1.0
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            If.Chance 0.8 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
            If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "OilSpill"
    Type = Type.FireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Industrial"]
        Hidden = ["FireDept";"USA";"OnLand";"UnderSiege";"Berlin"]
    }
    TitleKey = "Hazmat_Title"
    InitialDescriptionKeys = ["Hazmat_Desc01"]
    AssetRequirements = [
        "FireFighter", 10, 9 //90
        "FireFighter", 5, 2 //10
        "HazmatSuit", 2, 5 //10
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 4000
    ReputationGainOnDispatch = 0, 90
    ReputationCostToTerminate = Some (45, 45)
    Events = [
        When.Emergency.Success [
            AddXp 14.0
            AddExhaustion 3.0
            AddInjury 0.0 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "IndustrialAccident"
    Type = Type.Medical
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 5.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Industrial";"Critical"]
        Hidden = ["Medical"; "Industrial";"USA";"OnLand";"UnderSiege";"Berlin"]
    }
    TitleKey = "IndustrialAccident_Title"
    InitialDescriptionKeys = ["IndustrialAccident_Desc01"]
    AssetRequirements = [
        "Medic", 5, 20 //100
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 2000
    ReputationGainOnDispatch = 0, 50
    ReputationCostToTerminate = Some (25, 25)
    Events = [
        When.Emergency.Success [
            AddXp 24.0
            AddExhaustion 3.0
            AddInjury 0.02 0.1 ["Light"]
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"]
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"]
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
            If.Chance 0.1 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}



Def.Emergency.Add {
    ID = "ForestFireSmall"
    Type = Type.FireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["ForestFire"]
        Hidden = ["FireDept";"HeatWave";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "ForestFire_Title"
    InitialDescriptionKeys = ["ForestFire_Desc01"]
    AssetRequirements = [
        "FireFighter", 9, 6 //54
        "Tank", 2, 23 //46

    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 4000
    ReputationGainOnDispatch = 0, 100
    ReputationCostToTerminate = Some (50, 50)
    Events = [
        When.Emergency.Success [
            AddXp 16.0
            AddExhaustion 6.0
            AddInjury 0.02 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "UnkownSubstance"
    Type = Type.FireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 5.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Industrial";"Chemical"]
        Hidden = ["FireDept"; "Industrial";"USA";"OnLand";"UnderSiege";"Berlin"]
    }
    TitleKey = "UnkownSubstance_Title"
    InitialDescriptionKeys = ["UnkownSubstance_Desc01"]
    AssetRequirements = [
        "FireFighter", 10, 4 //40
        "FireFighter", 10, 4 //40
        "HazmatSuit", 2, 30 //60
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 4000
    ReputationGainOnDispatch = 0, 110
    ReputationCostToTerminate = Some (55, 55)
    Events = [
        When.Emergency.Success [
            AddXp 18.0
            AddExhaustion 3.0
            AddInjury 0.03 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Medium"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "ForestFireMedium"
    Type = Type.FireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["ForestFire"]
        Hidden = ["FireDept";"HeatWave";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "ForestFire_Title"
    InitialDescriptionKeys = ["ForestFire_Desc02"]
    AssetRequirements = [
        "FireFighter", 12, 2 //24
        "Tank", 2, 28 //56
        "BreathingApparatus", 5, 4 //20
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 6000
    ReputationGainOnDispatch = 0, 120
    ReputationCostToTerminate = Some (60, 60)
    Events = [
        When.Emergency.Success [
            AddXp 23.0
            AddExhaustion 6.0
            AddInjury 0.03 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.1 0.2 ["Medium"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "AssaultOnDrugs"
    Type = Type.Police
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 5.0
    }
    Tags = {
        Visible = ["Shootout"]
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "AssaultOnDrugs_Title"
    InitialDescriptionKeys = ["AssaultOnDrugs_Desc01"]
    AssetRequirements = [
        "Police", 8, 7 //56
        "Police", 2, 7 //14
        "AssaultGear", 2, 15 //30
        "SniperKit", 1, 14 //14

    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 3000
    ReputationGainOnDispatch = 0, 120
    ReputationCostToTerminate = Some (60, 60)
    Events = [
        When.Emergency.Success [
            AddXp 23.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            If.Chance 0.8 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.8 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.8 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 10
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.2 0.4 ["Heavy"]
            SetMood -2.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "ViolentProtest"
    Type = Type.Police
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical"]
        Hidden = ["Police";"Civil_Movement";"USA";"MassHysteria";"OnLand";"Berlin"]
    }
    TitleKey = "ViolentProtest_Title"
    InitialDescriptionKeys = ["ViolentProtest_Desc01"]
    AssetRequirements = [
        "Police", 20, 5 //100
        "RiotGear", 1, 10 //10
        "CrowdControl", 2, 15 //30


    ]
    PreparationTime = Gt.hours 5.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 8000
    ReputationGainOnDispatch = 0, 180
    ReputationCostToTerminate = Some (90, 110)
    Events = [
        When.Emergency.Success [
            AddXp 26.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.8 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 10
            Hq.Storage.Create "Evidence" 2
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.2 0.4 ["Heavy"]
            SetMood -2.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "Hooligans_Violent"
    Type = Type.PoliceMedical
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept";"SportsFestival";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "Hooligans_Violent_Title"
    InitialDescriptionKeys = ["Hooligans_Violent_Desc"]
    AssetRequirements = [
        "Police", 8, 5 //40
        "RiotGear", 4, 5 //20
        "Medic", 2, 15 //30
        "Medikit", 1, 5 //10
    ]
    PreparationTime = Gt.hours 1.5
    ResolutionTime = Gt.hours 1.5
    MoneyGainOnSuccess = 2100
    ReputationGainOnDispatch = 0, 70
    ReputationCostToTerminate = Some (35, 35)
    Events = [
        //When emergency is done no matter the result - alternative for result-agnostic effects
        When.Emergency.Done [
            AddExhaustion 3.0
        ]
        When.Emergency.Success [
            AddXp 10.0
            AddInjury 0.0 0.1 ["Light"]
            SetMood 1.0
            
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.7 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 8
            SetMood 1.0
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"
            If.Chance 0.7 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
        ]
        When.Emergency.Failure [
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HeartAttackOnStreet"
    Type = Type.Medical
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 4.0
        Night = 0.0
    }
    Tags = {
        Visible = ["Urban";"Critical"]
        Hidden = ["Medical";"HeatWave";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HeartAttackOnStreet_Title"
    InitialDescriptionKeys = ["HeartAttackOnStreet_Desc01"]
    AssetRequirements = [
        "Medic", 2, 43 //86
        "ChargedCrashCart", 1,4 //4
        "Medicine",2 , 5 //10

    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 2800
    ReputationGainOnDispatch = 0, 80
    ReputationCostToTerminate = Some (40, 40)
    Events = [
        When.Emergency.Success [
            AddXp 13.0
            AddExhaustion 3.0
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_HeartAttack" 
            SetMood 1.0
            

        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            

        ]
    ]
}

Def.Emergency.Add {
    ID = "BusAccident"
    Type = Type.MedicalFireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 0.1
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept";"Medical";"USA";"OnLand";"Berlin";"MassHysteria"]
    }
    TitleKey = "BusAccident_Title"
    InitialDescriptionKeys = ["BusAccident_Description"]
    AssetRequirements = [
        "BreachingGear", 2, 5 //10
        "FireFighter", 6, 10 //60
        "Medic" , 2, 10 //20
        "Medikit", 2, 5 //10
    ]
    PreparationTime = Gt.hours 1.0
    ResolutionTime = Gt.hours 1.2
    MoneyGainOnSuccess = 4200
    ReputationGainOnDispatch = 0, 90
    ReputationCostToTerminate = Some (45, 45)
    Events = [
        When.Emergency.Success [
            AddXp 18.0
            AddExhaustion 2.0
            AddInjury 0.01 0.1 ["Light"]
            SetMood 1.0
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"]
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"]
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "CashCarrierRobbed"
    Type = Type.Police
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 3.1
    }
    Tags = {
        Visible = ["Pursuit"]
        Hidden = ["Police";"USA";"OnLand";"Berlin";"TerrorAttacks";"MassHysteria"]
    }
    TitleKey = "CashCarrierRobbed_Title"
    InitialDescriptionKeys = ["CashCarrierRobbed_Description"]
    AssetRequirements = [
        "Police", 6, 10 //60
        "HighPowerCar", 1, 20 //20
        "AssaultGear" , 4, 5 //20
    ]
    PreparationTime = Gt.hours 1.0
    ResolutionTime = Gt.hours 1.2
    MoneyGainOnSuccess = 2500
    ReputationGainOnDispatch = 0, 120
    ReputationCostToTerminate = Some (85, 85)
    Events = [
        When.Emergency.Success [
            AddXp 22.0
            AddExhaustion 2.0
            AddInjury 0.01 0.1 ["Light"]
            SetMood 1.0
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            
            Hq.Storage.Create "PaperWork" 3
            If.Hq.Storage.HaveAtLeastFreeSlots "Evidence" 2 [Hq.Storage.Create "Evidence" 2]
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}
Def.Emergency.Add {
    ID = "SubwayWalkers"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"USA";"OnLand";"Berlin";"MassHysteria"]
    }
    TitleKey = "SubwayWalkers_Title"
    InitialDescriptionKeys = ["SubwayWalkers_Description"]
    AssetRequirements = [
        "Police" , 6, 10 //60
        "Police" , 2, 20 //40
        "K9Unit", 2, 10 //20
        "CrowdControl", 1, 20 //20

    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 3.5
    MoneyGainOnSuccess = 3900
    ReputationGainOnDispatch = 0, 110
    ReputationCostToTerminate = Some (50, 50)
    Events = [
        When.Emergency.Success [
            AddXp 15.0
            AddExhaustion 2.0
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "AutonomousCarAttacks"
    Type = Type.AllThree
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Pursuit"]
        Hidden = ["Police";"Medical";"Fire";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "AutonomousCarAttacks_Title"
    InitialDescriptionKeys = ["AutonomousCarAttacks_Description"]
    AssetRequirements = [
        "Police" , 2, 15 //30
        "Police" , 2, 5 //10
        "HighPowerCar", 1, 10 //12
        "FireFighter" , 5, 4 //20
        "FoamExtinguisher", 4,2 //8
        "Medic", 1, 20 //20
        "Medic", 1, 10 //20
        "ChargedCrashCart", 1, 10//10
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 3500
    ReputationGainOnDispatch = 0, 130
    ReputationCostToTerminate = Some (80, 90)
    Events = [
        When.Emergency.Success [
            AddXp 13.0
            AddExhaustion 2.0
            SetMood 1.0
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
            
            AddInjury 0.01 0.1 ["Light"]
            Hq.Storage.Create "PaperWork" 3
            If.Hq.Storage.HaveAtLeastFreeSlots "Evidence" 1 [Hq.Storage.Create "Evidence" 1]
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            AddInjury 0.02 0.2 ["Light"]
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HostageSituation"
    Type = Type.Police
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Hostage"]
        Hidden = ["Police";"USA";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "HostageSituation_Title"
    InitialDescriptionKeys = ["HostageSituation_Description"]
    AssetRequirements = [
        "Police" , 6, 10 //60
        "Police" , 2, 5 //60
        "CrowdControl" , 2, 15 //30
        "SniperKit", 1, 10 //10
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 4200
    ReputationGainOnDispatch = 0, 135
    ReputationCostToTerminate = Some (80, 90)
    Events = [
        When.Emergency.Success [
            AddXp 18.0
            AddExhaustion 3.0
            SetMood 1.0
            
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_GunshotWound"
            If.Chance 0.3 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_GunshotWound"]
            If.Chance 0.1 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_GunshotWound"]
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            AddInjury 0.02 0.3 ["Medium"]
            Hq.Storage.Create "PaperWork" 4
            If.Hq.Storage.HaveAtLeastFreeSlots "Evidence" 3 [Hq.Storage.Create "Evidence" 3]
        ]
        When.Emergency.Failure [
            AddInjury 0.03 0.4 ["Medium"]
            AddExhaustion 3.0
            SetMood -3.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "PoliceReinforcement"
    Type = Type.PoliceMedical
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Critical"]
        Hidden = ["Police";"USA";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "PoliceReinforcement_Title"
    InitialDescriptionKeys = ["PoliceReinforcement_Description"]
    AssetRequirements = [
        "Police" , 8, 5 //40
        "Police" , 4, 2 //8
        "AssaultGear" , 2, 5 //10
        "SniperKit", 1, 5 //5
        "Medic" , 2, 15 //30
        "Medikit" , 1, 11 //13
        "Medicine", 4, 1 //8
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 3600
    ReputationGainOnDispatch = 0, 135
    ReputationCostToTerminate = Some (80, 90)
    Events = [
        When.Emergency.Success [
            AddXp 18.0
            AddExhaustion 2.0
            SetMood 1.0
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            If.Chance 0.1 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_GunshotWound"]
            
            AddInjury 0.02 0.2 ["Light"]
            If.Chance 0.3 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 3
            If.Hq.Storage.HaveAtLeastFreeSlots "Evidence" 2 [If.Chance 0.5 [Hq.Storage.Create "Evidence" 2]]
        ]
        When.Emergency.Failure [
            AddInjury 0.03 0.5 ["Light"]
            AddExhaustion 3.0
            SetMood -3.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "CamperLittering"
    Type = Type.PoliceFireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 2.0
        Night = 0.5
    }
    Tags = {
        Visible = ["ForestFire"]
        Hidden = ["Police";"Fire";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "CamperLittering_Title"
    InitialDescriptionKeys = ["CamperLittering_Description"]
    AssetRequirements = [
        "Police" , 8, 5 //40
        "Police" , 1, 10 //10
        "FireFighter" , 8, 5 //40
        "Tank", 3, 10 //30
        "BreathingApparatus", 8, 2 //16
        "CrowdControl", 1, 10 //10
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 5.0
    MoneyGainOnSuccess = 4600
    ReputationGainOnDispatch = 0, 145
    ReputationCostToTerminate = Some (80, 90)
    Events = [
        When.Emergency.Success [
            AddXp 24.0
            AddExhaustion 2.0
            SetMood 1.0
            
            Hq.Storage.Create "PaperWork" 2
            If.Chance 0.3 [Emergency.AddVisitor "Prisoner"]
            AddInjury 0.01 0.1 ["Light"]
        ]
        When.Emergency.Failure [
            AddInjury 0.02 0.1 ["Light"]
            AddExhaustion 3.0
            SetMood -3.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "PoliceCarStolen"
    Type = Type.Police
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 0.2
        Night = 1.5
    }
    Tags = {
        Visible = ["Pursuit"]
        Hidden = ["Police";"USA";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "PoliceCarStolen_Title"
    InitialDescriptionKeys = ["PoliceCarStolen_Description"]
    AssetRequirements = [
        "Police" , 9, 8 //72
        "HighPowerCar" , 1, 20 //20
        "HighPowerCar" , 1, 8 //8

    ]
    PreparationTime = Gt.hours 1.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 4600
    ReputationGainOnDispatch = 0, 130
    ReputationCostToTerminate = Some (60, 70)
    
    Events = [
        When.Emergency.Success [
            AddXp 21.0
            AddExhaustion 2.0
            SetMood 1.5
            
            AddInjury 0.01 0.1 ["Light"]
            Hq.Storage.Create "PaperWork" 2
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            If.Hq.Storage.HaveAtLeastFreeSlots "Evidence" 1 [If.Chance 0.5 [Hq.Storage.Create "Evidence" 1]]
        ]
        When.Emergency.Failure [
            AddInjury 0.02 0.2 ["Light"]
            AddExhaustion 3.5
            SetMood -2.5
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "CannonballRun"
    Type = Type.Police
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 2.2
        Night = 0.5
    }
    Tags = {
        Visible = ["Pursuit"]
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "CannonballRun_Title"
    InitialDescriptionKeys = ["CannonballRun_Description"]
    AssetRequirements = [
        "Police" , 6, 10 //60
        "HighPowerCar" , 2, 20 //40
        "Police", 6, 5 //30
        "CrowdControl", 1, 10 //10

    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 2900
    ReputationGainOnDispatch = 0, 120
    ReputationCostToTerminate = Some (60, 70)
    
    Events = [
        When.Emergency.Success [
            AddXp 25.0
            AddExhaustion 2.0
            SetMood 1.5
            
            AddInjury 0.02 0.1 ["Light"]
            Hq.Storage.Create "PaperWork" 2
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            If.Hq.Storage.HaveAtLeastFreeSlots "Evidence" 2 [If.Chance 0.2 [Hq.Storage.Create "Evidence" 2]]
        ]
        When.Emergency.Failure [
            AddInjury 0.04 0.2 ["Light"]
            AddExhaustion 3.5
            SetMood -2.5
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "DeadJogger"
    Type = Type.Police
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 1.2
        Night = 1.5
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"USA";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "DeadJogger_Title"
    InitialDescriptionKeys = ["DeadJogger_Description"]
    AssetRequirements = [
        "Police" , 2, 40 //80
        "CrowdControl", 1, 20 //20
    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 2900
    ReputationGainOnDispatch = 0, 120
    ReputationCostToTerminate = Some (60, 70)
    
    Events = [
        When.Emergency.Success [
            AddXp 25.0
            AddExhaustion 2.0
            SetMood 1.0
            
            Hq.Storage.Create "PaperWork" 8
            Hq.Storage.Create "Evidence" 1
            If.Hq.Storage.HaveAtLeastFreeSlots "Evidence" 3 [If.Chance 0.2 [Hq.Storage.Create "Evidence" 3]]
        ]
        When.Emergency.Failure [
            AddExhaustion 2.5
            SetMood -2.5
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "SF_MotorcycleGangWar"
    Type = Type.Police
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 3.2
        Night = 1.5
    }
    Tags = {
        Visible = ["Pursuit"]
        Hidden = ["Police";"USA";"OnLand"]
    }
    TitleKey = "SF_MotorcycleGangWar_Title"
    InitialDescriptionKeys = ["SF_MotorcycleGangWar_Description"]
    AssetRequirements = [
        "Police" , 5, 10 //50
        "HighPowerCar" , 2, 15 //30
        "AssaultGear", 4, 5 //20
        "Police", 2, 5 //10
        "CrowdControl", 1, 10 //10

    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 2900
    ReputationGainOnDispatch = 0, 120
    ReputationCostToTerminate = Some (60, 70)
    
    Events = [
        When.Emergency.Success [
            AddXp 25.0
            AddExhaustion 2.0
            SetMood 1.5
            
            AddInjury 0.02 0.1 ["Light"]
            Hq.Storage.Create "PaperWork" 2
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "Evidence" 1
        ]
        When.Emergency.Failure [
            AddInjury 0.04 0.2 ["Light"]
            AddExhaustion 3.5
            SetMood -2.5
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "TheMagentaSweaters"
    Type = Type.PoliceFireDept
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 3.0
        Night = 0.5
    }
    Tags = {
        Visible = ["Critical";"Urban"]
        Hidden = ["Police";"Fire";"Civil_Movement";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "TheMagentaSweaters_Title"
    InitialDescriptionKeys = ["TheMagentaSweaters_Description"]
    AssetRequirements = [
        "Police", 8, 5 //40
        "RiotGear", 2, 5 //10
        "CrowdControl", 2, 3 //6
        "FireFighter" , 9, 4 //36
        "Tank", 4, 3 //12
        "FoamExtinguisher", 4, 2 //8

    ]
    PreparationTime = Gt.hours 5.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 7300
    ReputationGainOnDispatch = 0, 170
    ReputationCostToTerminate = Some (90, 90)
    Events = [
        When.Emergency.Success [
            AddXp 26.0
            AddInjury 0.03 0.2 ["Medium"]
            AddExhaustion 6.0
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.8 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 10
            Hq.Storage.Create "Evidence" 2
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.2 0.4 ["Heavy"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "Berlin_BrandenburgBrutality"
    Type = Type.PoliceMedical
    Difficulty = "Medium"
    Level = 3
    Weighting = {
        Day = 3.0
        Night = 0.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"Medic";"Civil_Movement";"OnLand";"Berlin"]
    }
    TitleKey = "Berlin_BrandenburgBrutality_Title"
    InitialDescriptionKeys = ["Berlin_BrandenburgBrutality_Description"]
    AssetRequirements = [
        "Police", 12, 3 //36
        "RiotGear", 4, 2 //8
        "CrowdControl", 4, 3 //12
        "Medic" , 4, 6 //24
        "Medikit", 4, 3 //12
        "ChargedCrashCart", 2, 2 //8

    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 6300
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = Some (90, 90)
    Events = [
        When.Emergency.Success [
            AddXp 26.0
            AddInjury 0.01 0.1 ["Light"]
            AddExhaustion 4.0
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.3 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 4
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_HeartAttack"
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddXp 10.0
            AddExhaustion 4.0
            AddInjury 0.2 0.4 ["Medium"]
            SetMood -2.0
            
        ]
    ]
}