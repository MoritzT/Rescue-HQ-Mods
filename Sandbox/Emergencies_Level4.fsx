#load "EmergencyShared.fsx"
open EMT.Modding
open EmergencyShared

///////////////////////////
/// LEVEL IV Emergencies./
/////////////////////////

Def.Emergency.Add {
    ID = "CivilUnrest"
    Type = Type.Police
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"Civil_Movement";"USA";"MassHysteria";"OnLand";"Berlin"]
    }
    TitleKey = "CivilUnrest_Title"
    InitialDescriptionKeys = ["CivilUnrest_Desc01"]
    AssetRequirements = [
        "Police", 16, 3 //48
        "RiotGear", 4, 3 //12
        "CrowdControl", 4, 5 //20
        "Drones",2 , 10 //20

    ]
    PreparationTime = Gt.hours 4.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 7000
    ReputationGainOnDispatch = 0, 280
    ReputationCostToTerminate = Some (160, 160)
    Events = [
        When.Emergency.Success [
            AddXp 36.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 20
            Hq.Storage.Create "Evidence" 3
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
    ID = "RandomVandalism"
    Type = Type.PoliceFireDept
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"Civil_Movement";"USA";"MassHysteria";"OnLand";"Berlin"]
    }
    TitleKey = "AnitAntiVandalism_Title"
    InitialDescriptionKeys = ["AnitAntiVandalism_Description"]
    AssetRequirements = [
        "Police", 8, 4 //32
        "CrowdControl", 4, 5 //20
        "RiotGear", 2, 5 //10
        "FireFighter", 15, 2 //30
        "Tank", 4, 2 //8
    ]
    PreparationTime = Gt.hours 5.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 8000
    ReputationGainOnDispatch = 0, 230
    ReputationCostToTerminate = Some (60, 60)
    Events = [
        When.Emergency.Success [
            AddXp 35.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            If.Chance 0.2 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 20
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
    ID = "GasPumpExplosion"
    Type = Type.Medical
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Industrial";"Critical"]
        Hidden = ["Medical";"USA";"UnderSiege";"OnLand";"Berlin"]
    }
    TitleKey = "GasPumpExplosion_Title"
    InitialDescriptionKeys = ["GasPumpExplosion_Description"]
    AssetRequirements = [
        "Medic", 8, 6 //48
        "Medikit", 4, 13 //52
    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 6000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = Some (60, 60)
    Events = [
        When.Emergency.Success [
            AddXp 26.0
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
    ID = "Building_Collapse"
    Type = Type.AllThree
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"FireDept";"Medical";"USA";"UnderSiege";"OnLand";"Berlin"]
    }
    TitleKey = "Building_Collapse_Title"
    InitialDescriptionKeys = ["Building_Collapse_Desc01"]
    AssetRequirements = [
        "Police", 12, 1 //12
        "Drones", 2, 5 //10
        "K9Unit",2, 10 //20
        "FireFighter", 15, 2 //30
        "BreachingGear", 2, 5 //10
        "Medic", 2, 5 //10
        "Medikit", 4, 2 //8
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 11000
    ReputationGainOnDispatch = 0, 290
    ReputationCostToTerminate = Some (60, 60)
    Events = [
        When.Emergency.Success [
            AddXp 46.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            Hq.Storage.Create "PaperWork" 10
            Hq.Storage.Create "Evidence" 3
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"
            If.Chance 0.8 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.02 0.04 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}


Def.Emergency.Add {
    ID = "DrugPlantation"
    Type = Type.Police
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban";"Shootout"]
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "DrugPlantation_Title"
    InitialDescriptionKeys = ["DrugPlantation_Description"]
    AssetRequirements = [
        "Police", 14, 2 //28
        "Drones", 2, 5 //10
        "K9Unit",2, 10 //20
        "AssaultGear", 8, 3 //24
        "SniperKit", 3, 6 //18
    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 11000
    ReputationGainOnDispatch = 0, 290
    ReputationCostToTerminate = Some (160, 160)
    Events = [
        When.Emergency.Success [
            AddXp 56.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            Hq.Storage.Create "PaperWork" 10
            Hq.Storage.Create "Evidence" 5
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.8 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.2 [Emergency.AddVisitor "Prisoner"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.02 0.04 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}

Def.Emergency.Add {
    ID = "BusAccidentSerious"
    Type = Type.AllThree
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 3.0
        Night = 0.5
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"FireDept";"Medical";"USA";"UnderSiege";"OnLand";"Berlin"]
    }
    TitleKey = "BusAccidentSerious_Title"
    InitialDescriptionKeys = ["BusAccidentSerious_Description"]
    AssetRequirements = [
        "Police", 12, 1 //12
        "Drones", 2, 2 //4
        "CrowdControl",4, 2 //8
        "FireFighter", 20, 1 //20
        "BreachingGear", 6, 2 //12
        "FoamExtinguisher", 10, 1 //11
        "BreathingApparatus", 12, 1 //12
        "Medic", 6, 2 //12
        "Medikit", 4, 2 //8
        "Medicine", 4, 1 //4
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 11000
    ReputationGainOnDispatch = 0, 290
    ReputationCostToTerminate = Some (60, 60)
    Events = [
        When.Emergency.Success [
            AddXp 46.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            Hq.Storage.Create "PaperWork" 10
            Hq.Storage.Create "Evidence" 3
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"
            If.Chance 0.8 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.02 0.04 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}

Def.Emergency.Add {
    ID = "ZooFire"
    Type = Type.AllThree
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.2
        Night = 0.1
    }
    Tags = {
        Visible = ["Urban";"Critical"]
        Hidden = ["Police";"FireDept";"Medical";"USA";"UnderSiege";"OnLand";"Berlin"]
    }
    TitleKey = "ZooFire_Title"
    InitialDescriptionKeys = ["ZooFire_Description"]
    AssetRequirements = [
        "Police", 6, 2 //12
        "Drones", 2, 2 //4
        "K9Unit",4, 2 //8
        "FireFighter", 20, 1 //20
        "BreachingGear", 2, 8 //8
        "Tank", 6, 3 //18
        "BreathingApparatus", 10, 1 //10
        "Medic", 2, 4 //8
        "Medikit", 4, 2 //8
        "Medicine", 4, 1 //4
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 11000
    ReputationGainOnDispatch = 0, 280
    ReputationCostToTerminate = Some (160, 160)
    Events = [
        When.Emergency.Success [
            AddXp 46.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            Hq.Storage.Create "PaperWork" 5
            Hq.Storage.Create "Evidence" 3
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.02 0.04 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}


Def.Emergency.Add {
    ID = "LargeParkFire"
    Type = Type.FireDept
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 2.2
        Night = 2.1
    }
    Tags = {
        Visible = ["ForestFire";"Critical"]
        Hidden = ["FireDept";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "LargeParkFire_Title"
    InitialDescriptionKeys = ["LargeParkFire_Description"]
    AssetRequirements = [
        "FireFighter", 25, 2 //50
        "Tank", 10, 3 //30
        "BreathingApparatus", 20, 1 //20
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 9.0
    MoneyGainOnSuccess = 10500
    ReputationGainOnDispatch = 0, 290
    ReputationCostToTerminate = Some (160, 160)
    Events = [
        When.Emergency.Success [
            AddXp 46.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.02 0.04 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}

Def.Emergency.Add {
    ID = "IndustrialFire"
    Type = Type.FireDept
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 2.2
        Night = 2.1
    }
    Tags = {
        Visible = ["Industrial"]
        Hidden = ["FireDept";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "IndustrialFire_Title"
    InitialDescriptionKeys = ["IndustrialFire_Description"]
    AssetRequirements = [
        "FireFighter", 18, 2 //36
        "FireFighter", 6, 1 //6
        "Tank", 5, 2 //10
        "BreathingApparatus", 13, 1 //13
        "HazmatSuit", 4, 4 //16
        "FoamExtinguisher" , 8, 1 //8
        "HighLadder", 1, 10 //10
        "Ladder", 2, 3 //6
    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 12500
    ReputationGainOnDispatch = 0, 320
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 55.0
            AddInjury 0.02 0.1 ["Medium"]
            AddExhaustion 5.0
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.05 0.2 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}


Def.Emergency.Add {
    ID = "HostageSituationLvl2"
    Type = Type.PoliceMedical
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 2.2
        Night = 2.1
    }
    Tags = {
        Visible = ["Hostage"]
        Hidden = ["Police";"Medic";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HostageSituationLvl2_Title"
    InitialDescriptionKeys = ["HostageSituationLvl2_Description"]
    AssetRequirements = [
        "Police", 12, 2 //24
        "Medic", 6, 2 //12
        "Medikit", 5, 3 //15
        "SniperKit", 4, 4 //16
        "CrowdControl", 2, 4 //8
        "AssaultGear", 8, 2 //16
        "Drones", 3, 3 //9

    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 11500
    ReputationGainOnDispatch = 0, 320
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 55.0
            AddInjury 0.02 0.1 ["Medium"]
            AddExhaustion 5.0
            SetMood 1.0
            Hq.Storage.Create "PaperWork" 5
            Hq.Storage.Create "Evidence" 3
            
            If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_GunshotWound"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_GunshotWound"
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_HeartAttack"]
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.05 0.2 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}



Def.Emergency.Add {
    ID = "CarBatteryExplosion"
    Type = Type.MedicalFireDept
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.2
        Night = 0.3
    }
    Tags = {
        Visible = ["Chemical"]
        Hidden = ["Fire";"Medic";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "CarBatteryExplosion_Title"
    InitialDescriptionKeys = ["CarBatteryExplosion_Description"]
    AssetRequirements = [
        "FireFighter", 12, 2 //24
        "FoamExtinguisher", 8, 1 //8
        "BreathingApparatus", 10, 2 //20
        "BreachingGear", 2, 5 //10
        "HazmatSuit", 2, 5 //10
        "Medic", 6, 3 //18
        "Medikit", 2, 5 //10
       

    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 12100
    ReputationGainOnDispatch = 0, 300
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 65.0
            AddInjury 0.01 0.1 ["Medium"]
            AddExhaustion 5.0
            SetMood 1.0
            
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
            If.Chance 0.1 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.05 0.2 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}

Def.Emergency.Add {
    ID = "Anthrax"
    Type = Type.MedicalFireDept
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.2
        Night = 0.3
    }
    Tags = {
        Visible = ["Biohazard"]
        Hidden = ["Police";"Medic";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "Anthrax_Title"
    InitialDescriptionKeys = ["Anthrax_Description"]
    AssetRequirements = [
        "Police", 13, 2 //26
        "CrowdControl", 4, 3 //12
        "AssaultGear", 6, 2//12
        "Medic", 6, 3 //18
        "ContaminationSuit", 6, 2 //12
        "Medicine", 6, 2 //12
        "Medikit", 4, 2 //8
       

    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 8.0
    MoneyGainOnSuccess = 12100
    ReputationGainOnDispatch = 0, 310
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 65.0
            AddInjury 0.01 0.1 ["Medium"]
            AddExhaustion 5.0
            SetMood 1.0
            
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
            If.Chance 0.1 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.05 0.2 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}

Def.Emergency.Add {
    ID = "BacterialBreakout"
    Type = Type.Medical
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 2.2
        Night = 0.3
    }
    Tags = {
        Visible = ["Biohazard"]
        Hidden = ["Medic";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "BacterialBreakout_Title"
    InitialDescriptionKeys = ["BacterialBreakout_Description"]
    AssetRequirements = [
        "Medic", 10, 3 //30
        "Medic", 2, 5 //10
        "ContaminationSuit", 4, 5 //20
        "Medicine", 12, 2 //24
        "Medikit", 4, 4 //16
       

    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 8.0
    MoneyGainOnSuccess = 12100
    ReputationGainOnDispatch = 0, 310
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 65.0
            AddInjury 0.01 0.1 ["Medium"]
            AddExhaustion 5.0
            SetMood 1.0
            
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
            If.Chance 0.1 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.05 0.2 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}



Def.Emergency.Add {
    ID = "HighwayCarambolage"
    Type = Type.AllThree
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 1.2
        Night = 0.1
    }
    Tags = {
        Visible = ["Critical"]
        Hidden = ["Police";"FireDept";"Medical";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HighwayCarambolage_Title"
    InitialDescriptionKeys = ["HighwayCarambolage_Description"]
    AssetRequirements = [
        "Police", 8, 2 //16
        "Drones", 2, 4 //8
        "FireFighter", 20, 1 //20
        "BreachingGear", 4, 5 //20
        "Tank", 4, 3 //12
        "FoamExtinguisher", 10, 1 //10
        "BreathingApparatus", 10, 1 //10
        "Medic", 4, 4 //16
        "Medikit", 4, 2 //8
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 5.0
    MoneyGainOnSuccess = 12000
    ReputationGainOnDispatch = 0, 230
    ReputationCostToTerminate = Some (160, 160)
    Events = [
        When.Emergency.Success [
            AddXp 56.0
            AddInjury 0.05 0.2 ["Light"]
            AddExhaustion 6.0
            Hq.Storage.Create "PaperWork" 6
            SetMood 1.0
            
            If.Chance 0.9 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.02 0.04 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}

Def.Emergency.Add {
    ID = "SF_ConcertRiot"
    Type = Type.AllThree
    Difficulty = "Hard"
    Level = 4
    Weighting = {
        Day = 0.0
        Night = 1.1
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"FireDept";"Medical";"USA";"OnLand"]
    }
    TitleKey = "SF_ConcertRiot_Title"
    InitialDescriptionKeys = ["SF_ConcertRiot_Description"]
    AssetRequirements = [
        "Police", 20, 2 //20
        "Police", 6, 2 //12
        "Drones", 2, 4 //8
        "CrowdControl", 6, 2 //12
        "RiotGear", 6, 2 //12
        "FireFighter", 10, 1 //10
        "BreathingApparatus", 6, 1 //6
        "Medic", 6, 2 //12
        "Medic", 3, 3 //9
        "Medikit", 4, 2 //8
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 5.0
    MoneyGainOnSuccess = 12000
    ReputationGainOnDispatch = 0, 230
    ReputationCostToTerminate = Some (160, 160)
    Events = [
        When.Emergency.Success [
            AddXp 56.0
            AddInjury 0.05 0.2 ["Light"]
            AddExhaustion 6.0
            Hq.Storage.Create "PaperWork" 6
            SetMood 1.0
            
            If.Chance 0.9 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.02 0.04 ["Heavy"]
            SetMood -2.0
            
           
        ]
    ]
}