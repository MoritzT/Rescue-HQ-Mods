#load "EmergencyShared.fsx"
open EMT.Modding
open EmergencyShared

Def.Emergency.Add {
    ID = "Hooligans_Ruffle"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 2.3
        Night = 3.5
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"SportsFestival";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "Hooligans_Ruffle_Title"
    InitialDescriptionKeys = ["Hooligans_Ruffle_Desc01"]
    AssetRequirements = [
        "Police" , 4, 25 //100
        "RiotGear",1 ,25 //25
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 1200
    ReputationGainOnDispatch = 0, 40
    ReputationCostToTerminate = Some (20, 20)
    Events = [
        When.Emergency.Success [
            AddXp 13.0
            AddExhaustion 1.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.2 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.2 [Emergency.AddVisitor "Prisoner"]]
            
            Hq.Storage.Create "PaperWork" 2
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "FootballPubRiot"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 0.3
        Night = 2.5
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"SportsFestival";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "FootballPubRiot_Title"
    InitialDescriptionKeys = ["FootballPubRiot_Description"]
    AssetRequirements = [
        "Police" , 4, 20 //80
        "Police" , 4, 5 //20
        "RiotGear",2 ,10 //20
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 2200
    ReputationGainOnDispatch = 0, 80
    ReputationCostToTerminate = Some (40, 40)
    Events = [
        When.Emergency.Success [
            AddXp 15.0
            AddExhaustion 1.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.9 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.9 [Emergency.AddVisitor "Prisoner"]]
            
            Hq.Storage.Create "PaperWork" 4
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "StoreRobbery"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 1.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Urban";"Shootout"]
        Hidden = ["Police"; "Tier1";"USA";"SmallTimeGangsters";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "StoreRobbery_Title"
    InitialDescriptionKeys = ["StoreRobbery_Desc01"]
    AssetRequirements = [
        "Police" , 2, 45 //90
        "Police" , 1, 10 //10
        "AssaultGear", 1, 10 //10
     ]
    PreparationTime = Gt.hours 1.5
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 2700
    ReputationGainOnDispatch = 0, 60
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [
            AddXp 8.0
            AddExhaustion 3.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]]
            Hq.Storage.Create "PaperWork" 2
            AddInjury 0.01 0.1 ["Light"]
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
    ID = "SF_StolenPhonePrototype"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 3.0
        Night = 0.0
    }
    Tags = {
        Visible = []
        Hidden = ["Police"; "Tier1";"USA";"OnLand";"SmallTimeGangsters"]
    }
    TitleKey = "SF_StolenPhonePrototype_Title"
    InitialDescriptionKeys = ["SF_StolenPhonePrototype_Description"]
    AssetRequirements = [
        "Police" , 2, 45 //90
        "Police" , 1, 10 //10
     ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 8.0
    MoneyGainOnSuccess = 3700
    ReputationGainOnDispatch = 0, 60
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [
            AddXp 8.0
            AddExhaustion 3.0
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]]
            Hq.Storage.Create "PaperWork" 5
            AddInjury 0.01 0.1 ["Light"]
            SetMood 1.0
            

        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.2 0.4 ["Light"]
            SetMood -2.0
            

        ]
    ]
}

Def.Emergency.Add {
    ID = "ElectricalIndustrialFire"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 5.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Industrial"]
        Hidden = ["FireDept";"Tier1";"USA";"OnLand";"UnderSiege";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "ElectricalIndustrialFire_Title"
    InitialDescriptionKeys = ["ElectricalIndustrialFire_Desc01"]
    AssetRequirements = [
           "FireFighter", 8, 10 //80
           "FireFighter", 2, 10 //20
           "FoamExtinguisher", 2, 10 //20
    ]
    PreparationTime = Gt.hours 1.0
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 1800
    ReputationGainOnDispatch = 0, 50
    ReputationCostToTerminate = Some (25, 25)
    Events = [
        When.Emergency.Success [
            AddXp 9.0
            AddExhaustion 3.0
            AddInjury 0.01 0.1 ["Light"]
            
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
    ID = "HouseFireSmall"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HouseFire_Title"
    InitialDescriptionKeys = ["HouseFire_Desc_House02"; "HouseFire_Desc_Apartment02"]
    AssetRequirements = [
        "BreathingApparatus", 4, 6 //24
        "FireFighter", 4, 14 //56
        "Ladder", 1, 10 //20
        "Tank", 1, 10 //10
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
            
        ]
        When.Emergency.Failure [
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "Hooligans"
    Type = Type.PoliceMedical
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept";"SportsFestival";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "Hooligans_Title"
    InitialDescriptionKeys = ["Hooligans_Desc"]
    AssetRequirements = [
        "Police", 4, 15 //60
        "RiotGear", 1, 15 //15
        "Medic", 2, 20 //30
        "Medikit", 1, 20 //15
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
            
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.7 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.7 [Emergency.AddVisitor "Prisoner"]]
            Hq.Storage.Create "PaperWork" 3
            SetMood 1.0
            If.Hq.Unlocked "SetupMedicalStation_Done" [If.Chance 0.7 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]]
            If.Hq.Unlocked "SF_Medical_Stage1_Done" [If.Chance 0.7 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]]

        ]
        When.Emergency.Failure [
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            

        ]
    ]
}

Def.Emergency.Add {
    ID = "CarCrashInnerCity"
    Type = Type.PoliceFireDept
    Difficulty = "Medium"
    Level = 2
    Weighting = {
        Day = 2.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban";"Critical"]
        Hidden = ["Police";"FireDept";"USA";"OnLand";"Berlin";"MassHysteria"]
    }
    TitleKey = "CarCrashInnerCity_Title"
    InitialDescriptionKeys = ["CarCrashInnerCity_Desc01"]
    AssetRequirements = [
        "FireFighter", 5, 12 //60
        "Police" , 2, 20 //40
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 2000
    ReputationGainOnDispatch = 0, 70
    ReputationCostToTerminate = Some (35, 35)
    Events = [
        When.Emergency.Success [
            AddXp 13.0
            AddExhaustion 3.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [Emergency.AddVisitor "Prisoner"]
            If.Hq.Unlocked "SF_PoliceStage4Done" [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 3
            SetMood 1.0
            If.Hq.Unlocked "SetupMedicalStation_Done" [If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]]
            If.Hq.Unlocked "SF_Medical_Stage1_Done" [If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]]
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "CarCrashLight"
    Type = Type.AllThree
    Difficulty = "Medium"
    Level = 2
    Weighting = {
        Day = 2.0
        Night = 2.0
    }
    Tags = {
        Visible = ["Urban";"Critical"]
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "CarCrashLight_Title"
    InitialDescriptionKeys = ["CarCrashLight_Desc01"]
    AssetRequirements = [
        "FireFighter", 2, 20 //40
        "Police" , 2, 20 //40
        "Medic" , 1, 20 //20
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
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]]
            Hq.Storage.Create "PaperWork" 3
            If.Hq.Unlocked "SetupMedicalStation_Done" [If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]]
            If.Hq.Unlocked "SF_Medical_Stage1_Done" [If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            
        ]
    ]
}





Def.Emergency.Add {
    ID = "PeacefulProtest"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 1.0
        Night = 0.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"Civil_Movement";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "PeacefulProtest_Title"
    InitialDescriptionKeys = ["PeacefulProtest_Desc01"]
    AssetRequirements = [
        "Police", 6, 15 //90
        "Police", 2, 5 //10
        "CrowdControl", 2, 5 //10


    ]
    PreparationTime = Gt.hours 5.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 8000
    ReputationGainOnDispatch = 0, 180
    ReputationCostToTerminate = Some (90, 90)
    Events = [
        When.Emergency.Success [
            AddXp 26.0
            AddExhaustion 6.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]]
            Hq.Storage.Create "PaperWork" 2
            SetMood 1.0
            

        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.2 0.4 ["Medium"]
            SetMood -2.0
            

        ]
    ]
}

Def.Emergency.Add {
    ID = "WildAnimalAttack"
    Type = Type.Medical
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 2.0
        Night = 0.0
    }
    Tags = {
        Visible = []
        Hidden = ["Medical";"OnLand";"USA";"Berlin"]
    }
    TitleKey = "WildAnimalAttack_Title"
    InitialDescriptionKeys = ["WildAnimalAttack_Description"]
    AssetRequirements = [
        "Medic", 1, 80//80
        "Medic", 1, 20//20
        "Medikit", 1, 20 //20
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 2500
    ReputationGainOnDispatch = 0, 40
    ReputationCostToTerminate = Some (20, 20)
    Events = [
        When.Emergency.Success [
            AddXp 14.0
            AddExhaustion 1.0
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -3.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "FireDepartmentFire"
    Type = Type.MedicalFireDept
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 2.0
        Night = 2.0
    }
    Tags = {
        Visible = ["Critical"]
        Hidden = ["Medical";"Fire";"USA";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "FireDepartmentFire_Title"
    InitialDescriptionKeys = ["FireDepartmentFire_Description"]
    AssetRequirements = [
        "FireFighter", 8, 5 //40
        "Medic" , 1, 20 //20
        "Tank", 2, 10 // 20
        "Medikit", 2, 5 //10
        "BreathingApparatus", 10, 2 //20
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 5.0
    MoneyGainOnSuccess = 3800
    ReputationGainOnDispatch = 0, 90
    ReputationCostToTerminate = Some (50, 50)
    Events = [
        When.Emergency.Success [
            AddXp 18.0
            AddExhaustion 4.0
            If.Hq.Unlocked "SetupMedicalStation_Done" [
                If.Chance 0.8 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
                If.Chance 0.6 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
                ]
            
            If.Hq.Unlocked "SF_Medical_Stage1_Done" [
                If.Chance 0.8 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
                If.Chance 0.6 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
                ]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "TouristAlcoholPoisoning"
    Type = Type.PoliceMedical
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 0.0
        Night = 2.0
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"Medical";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "TouristAlcoholPoisoning_Title"
    InitialDescriptionKeys = ["TouristAlcoholPoisoning_Description"]
    AssetRequirements = [
        "Police" , 2, 25 //50
        "Police" , 2, 5 //10
        "CrowdControl", 1, 10 //10
        "Medic" , 1, 40 //40
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 3800
    ReputationGainOnDispatch = 0, 90
    ReputationCostToTerminate = Some (40, 40)
    Events = [
        When.Emergency.Success [
            AddXp 15.0
            AddExhaustion 1.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SetupMedicalStation_Done" [If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"]]
            If.Hq.Unlocked "SF_Medical_Stage1_Done" [If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"]]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "HighHippies"
    Type = Type.PoliceFireDept
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 3.0
        Night = 0.0
    }
    Tags = {
        Visible = ["ForestFire"]
        Hidden = ["Police";"Fire";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HighHippies_Title"
    InitialDescriptionKeys = ["HighHippies_Description"]
    AssetRequirements = [
        "Police" , 2, 15 //30
        "Police" , 2, 5 //10
        "FireFighter" , 6, 5 //30
        "CrowdControl", 1, 6 //6
        "Tank", 2, 10 //20
        "BreathingApparatus" , 6, 4 //24
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 3600
    ReputationGainOnDispatch = 0, 70
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [
            AddXp 15.0
            AddExhaustion 2.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [
                If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
                If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
                ]
            If.Hq.Unlocked "SF_PoliceStage4Done" [
                If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
                If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
                ]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            
        ]
    ]
}



Def.Emergency.Add {
    ID = "DecomposingNeighbour"
    Type = Type.PoliceMedical
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 3.0
        Night = 0.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"Medical";"USA";"OnLand";"Berlin";"MassHysteria"]
    }
    TitleKey = "DecomposingNeighbour_Title"
    InitialDescriptionKeys = ["DecomposingNeighbour_Description"]
    AssetRequirements = [
        "Police" , 2, 35 //70
        "Medic" , 2, 10 //20
        "Medic" , 1, 10 //10
        "ContaminationSuit" ,1, 10 //10
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 3700
    ReputationGainOnDispatch = 0, 90
    ReputationCostToTerminate = Some (50, 50)
    Events = [
        When.Emergency.Success [
            AddXp 15.0
            AddExhaustion 1.0
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 1.0
            SetMood -3.0
            
        ]
    ]
}




Def.Emergency.Add {
    ID = "AnimalEscapedZoo"
    Type = Type.AllThree
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"Medical";"Fire";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "AnimalEscapedZoo_Title"
    InitialDescriptionKeys = ["AnimalEscapedZoo_Description"]
    AssetRequirements = [
        "Police" , 5, 6 //30
        "Police" , 2, 5 //10
        "FireFighter" , 8, 4 //32
        "Medic", 1, 10 //18
        "K9Unit", 2, 10 //20

    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 5.5
    MoneyGainOnSuccess = 4900
    ReputationGainOnDispatch = 0, 130
    ReputationCostToTerminate = Some (80, 90)
    Events = [
        When.Emergency.Success [
            AddXp 17.0
            AddExhaustion 3.0
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 5.0
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "SF_BeachParty"
    Type = Type.PoliceFireDept
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 0.5
        Night = 0.5
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"Medical";"Fire";"USA";]
    }
    TitleKey = "SF_BeachParty_Title"
    InitialDescriptionKeys = ["SF_BeachParty_Description"]
    AssetRequirements = [
        "Police" , 5, 6 //30
        "Police" , 2, 10 //20
        "FireFighter" , 8, 4 //32
        "CrowdControl", 2, 10 //20
        "Tank", 2, 10 //20
        "FoamExtinguisher" ,2,1 //2
    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 5.5
    MoneyGainOnSuccess = 4900
    ReputationGainOnDispatch = 0, 130
    ReputationCostToTerminate = Some (80, 90)
    Events = [
        When.Emergency.Success [
            AddXp 17.0
            AddExhaustion 3.0
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 5.0
            SetMood -2.0

            
        ]
    ]
}


Def.Emergency.Add {
    ID = "Berlin_BeerTruck"
    Type = Type.PoliceFireDept
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 1.0
        Night = 2.0
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"Medical";"Fire";"OnLand";"Berlin"]
    }
    TitleKey = "Berlin_BeerTruck_Title"
    InitialDescriptionKeys = ["Berlin_BeerTruck_Description"]
    AssetRequirements = [
        "Police" , 2, 15 //30
        "FireFighter" , 6, 5 //30
        "FireFighter" , 1, 10 //10
        "Tank", 2, 15 //30
        "BreachingGear", 1, 10 //10
    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 5900
    ReputationGainOnDispatch = 0, 120
    ReputationCostToTerminate = Some (80, 90)
    Events = [
        When.Emergency.Success [
            AddXp 13.0
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
    ID = "SF_PBJTruck"
    Type = Type.PoliceFireDept
    Difficulty = "Easy"
    Level = 2
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"Medical";"Fire";"USA";"OnLand"]
    }
    TitleKey = "SF_PBJTruck_Title"
    InitialDescriptionKeys = ["SF_PBJTruck_Description"]
    AssetRequirements = [
        "Police" , 2, 15 //30
        "FireFighter" , 6, 5 //30
        "FireFighter" , 1, 10 //10
        "Tank", 3, 10 //30
        "BreachingGear", 1, 10 //10
    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 5500
    ReputationGainOnDispatch = 0, 110
    ReputationCostToTerminate = Some (80, 90)
    Events = [
        When.Emergency.Success [
            AddXp 13.0
            AddExhaustion 2.0
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            
        ]
    ]
}

