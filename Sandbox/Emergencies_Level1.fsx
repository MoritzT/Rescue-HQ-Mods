#load "EmergencyShared.fsx"
open EMT.Modding
open EmergencyShared

//Level 1 - first day 

Def.Emergency.Add {
    ID = "CatStuckInTreeHigh_1"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 0.0
    }
    Tags = {
        Visible = []
        Hidden = ["FireDept"; "Tier1";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "CatStuck_Title"
    InitialDescriptionKeys = ["CatStuck_Desc02"]
    AssetRequirements = [
        "FireFighter", 4, 25 //100

    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 0.75
    MoneyGainOnSuccess = 500
    ReputationGainOnDispatch = 0, 20
    ReputationCostToTerminate = Some (10, 10)
    Events = [
        When.Emergency.Success [
            AddXp 7.0
            AddExhaustion 1.0
            AddInjury 0.0 0.05 ["Light"]
            SetMood 1.0
        ]
        When.Emergency.Failure [
            AddExhaustion 1.5
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
        ]
    ]
}


Def.Emergency.Add {
    ID = "CatStuckInTreeHigh"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 0.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept"; "Tier1";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "CatStuck_Title"
    InitialDescriptionKeys = ["CatStuck_Desc02"]
    AssetRequirements = [
        "FireFighter", 2, 48 //96
        "FireFighter", 1, 4 //4
        "Ladder", 1, 4 //4
       
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 0.75
    MoneyGainOnSuccess = 500
    ReputationGainOnDispatch = 0, 20
    ReputationCostToTerminate = Some (10, 10)
    Events = [
        When.Emergency.Success [
            AddXp 7.0
            AddExhaustion 1.0
            AddInjury 0.0 0.05 ["Light"]
            SetMood 1.0
        ]
        When.Emergency.Failure [
            AddExhaustion 1.5
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
        ]
    ]
}




Def.Emergency.Add {
    ID = "CommercialBuildingFire"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 5.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept";"Tier1";"SportsFestival";"USA";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "CommercialBuildingFire_Title"
    InitialDescriptionKeys = ["CommercialBuildingFire_Desc01"]
    AssetRequirements = [
        "BreathingApparatus", 4, 2 // 8
        "FireFighter", 4, 21 //84
        "Tank", 1, 8 //8
    ]
    PreparationTime = Gt.hours 1.0
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 1800
    ReputationGainOnDispatch = 0, 60
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [
            AddXp 9.0
            AddExhaustion 1.0
            AddInjury 0.01 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 1.5
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HouseFireSmouldering"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept";"Tier1";"USA";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "HouseFire_Title"
    InitialDescriptionKeys = ["HouseFire_Desc_House01"; "HouseFire_Desc_Apartment01"]
    AssetRequirements = [
        "BreathingApparatus", 1, 6 // 6
        "FireFighter", 4, 21//84
        "Tank", 1, 10 //10
    ]
    PreparationTime = Gt.hours 1.5
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 1700
    ReputationGainOnDispatch = 0, 50
    ReputationCostToTerminate = Some (25, 25)
    Events = [
        When.Emergency.Success [
            AddXp 9.0
            AddExhaustion 1.0
            AddInjury 0.0 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 1.5
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HomeDisturbance"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 2.0
        Night = 4.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HomeDisturbance_Title"
    InitialDescriptionKeys = ["HomeDisturbance_Desc01"]
    AssetRequirements = [
        "Police" , 2, 50 //100
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
    ID = "IllegalWeedSeller"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 3.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"USA";"OnLand";"Berlin";"SmallTimeGangsters"]
    }
    TitleKey = "IllegalWeedSeller_Title"
    InitialDescriptionKeys = ["IllegalWeedSeller_Description"]
    AssetRequirements = [
        "Police" , 2, 45 //90
        "Police" , 1, 10 //10
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 2200
    ReputationGainOnDispatch = 0, 40
    ReputationCostToTerminate = Some (20, 20)
    Events = [
        When.Emergency.Success [
            AddXp 13.0
            AddExhaustion 1.0
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
    ID = "PigeonTrap"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = []
        Hidden = ["FireDept";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "PigeonTrap_Title"
    InitialDescriptionKeys = ["PigeonTrap_Description"]
    AssetRequirements = [
        "Ladder", 1, 10 // 10
        "FireFighter", 3, 30 //90
    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 1800
    ReputationGainOnDispatch = 0, 50
    ReputationCostToTerminate = Some (25, 25)
    Events = [
        When.Emergency.Success [
            AddXp 10.0
            AddExhaustion 1.3
            AddInjury 0.0 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 1.5
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "VideoStoreBurglary"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 3.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"USA";"OnLand";"Berlin";"MassHysteria";"SmallTimeGangsters"]
    }
    TitleKey = "VideoStoreBurglary_Title"
    InitialDescriptionKeys = ["VideoStoreBurglary_Description"]
    AssetRequirements = [
        "Police" , 1, 80 //100
        "Police" , 1, 20 //100
    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 2700
    ReputationGainOnDispatch = 0, 60
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [
            AddXp 18.0
            AddExhaustion 1.5
            Hq.Storage.Create "PaperWork" 3
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.5
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "ElevatorTrap"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 3.0
        Night = 0.3
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["FireDept";"Tier1";"USA";"OnLand";"Berlin";"TerrorAttacks"]
    }
    TitleKey = "ElevatorTrap_Title"
    InitialDescriptionKeys = ["ElevatorTrap_Description"]
    AssetRequirements = [
        "BreachingGear", 1, 10 // 10
        "FireFighter", 3, 30 //90
        "FireFighter", 1, 10 //90
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 2100
    ReputationGainOnDispatch = 0, 50
    ReputationCostToTerminate = Some (25, 25)
    Events = [
        When.Emergency.Success [
            AddXp 9.0
            AddExhaustion 1.0
            AddInjury 0.01 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 1.5
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}



Def.Emergency.Add {
    ID = "AnalyzingTrap"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 2.0
        Night = 2.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"USA";"OnLand";"Berlin";"SmallTimeGangsters"]
    }
    TitleKey = "AnalyzingTrap_Title"
    InitialDescriptionKeys = ["AnalyzingTrap_Description"]
    AssetRequirements = [
        "Police" , 2, 40 //100
        "Police" , 1, 20 //100
    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 3500
    ReputationGainOnDispatch = 0, 70
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [
            AddXp 15.0
            AddExhaustion 2.0
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
    ID = "DrunkenTourists"
    Type = Type.PoliceMedical
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 4.0
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "DrunkenTourists_Title"
    InitialDescriptionKeys = ["DrunkenTourists_Description"]
    AssetRequirements = [
        "Police" , 2, 40 //80
        "Medic", 1, 15 //20
        "Medic", 1, 5 //20
        "Medikit", 1, 5 //5
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 1500
    ReputationGainOnDispatch = 0, 70
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [

            AddXp 11.0
            AddExhaustion 1.0
            Hq.Storage.Create "PaperWork" 1
            SetMood 1.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]]
            If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"]
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}



Def.Emergency.Add {
    ID = "PublicDecency"
    Type = Type.Police
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 0.0
    }
    Tags = {
        Visible = ["Urban"]
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "PublicDecency_Title"
    InitialDescriptionKeys = ["PublicDecency_Description"]
    AssetRequirements = [
        "Police" , 2, 40 //80
        "Police" , 2, 10 //20
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 3500
    ReputationGainOnDispatch = 0, 60
    ReputationCostToTerminate = Some (30, 30)
    Events = [
        When.Emergency.Success [
            AddXp 12.0
            AddExhaustion 3.0
            Hq.Storage.Create "PaperWork" 1
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "NeightborhoodScream"
    Type = Type.PoliceFireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 0.0
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "NeightborhoodScream_Title"
    InitialDescriptionKeys = ["NeightborhoodScream_Description"]
    AssetRequirements = [
        "Police" , 1, 40 //40
        "Police" , 1, 5 //5
        "FireFighter", 3, 15 //45
        "FireFighter", 1, 10 //10
        "BreachingGear", 1, 10 // 5

    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 1800
    ReputationGainOnDispatch = 0, 30
    ReputationCostToTerminate = Some (20, 20)
    Events = [
        When.Emergency.Success [
            AddXp 8.0
            AddExhaustion 1.0
            If.Chance 0.3 [Hq.Storage.Create "PaperWork" 1]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "MonkeyBusiness"
    Type = Type.Medical
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 2.0
        Night = 0.0
    }
    Tags = {
        Visible = []
        Hidden = ["Medical";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "MonkeyBusiness_Title"
    InitialDescriptionKeys = ["MonkeyBusiness_Description"]
    AssetRequirements = [
        "Medic" , 1, 90 //90
        "Medic" , 1, 10 //90
        "Medikit" , 1, 10 //10

    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 1600
    ReputationGainOnDispatch = 0, 40
    ReputationCostToTerminate = Some (20, 20)
    Events = [
        When.Emergency.Success [
            AddXp 12.0
            AddExhaustion 1.0
            SetMood 1.0
            
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "DomesticKnifeFight"
    Type = Type.PoliceMedical
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 2.0
        Night = 0.5
    }
    Tags = {
        Visible = []
        Hidden = ["Police";"Medical";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "DomesticKnifeFight_Title"
    InitialDescriptionKeys = ["DomesticKnifeFight_Description"]
    AssetRequirements = [
        "Police" , 2, 40 //80
        "Medic", 1, 15 //15
        "Medic", 1, 5 //5
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 2100
    ReputationGainOnDispatch = 0, 50
    ReputationCostToTerminate = Some (25, 30)
    Events = [
        When.Emergency.Success [

            AddXp 14.0
            AddExhaustion 1.0
            Hq.Storage.Create "PaperWork" 2
            SetMood 1.0
            If.Hq.Unlocked "Berlin_PoliceStation_Done" [If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]]
            If.Hq.Unlocked "SF_PoliceStage4Done" [If.Chance 0.1 [Emergency.AddVisitor "Prisoner"]]
            If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"]
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HitTheWires"
    Type = Type.AllThree
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 2.0
        Night = 0.0
    }
    Tags = {
        Visible = ["Critical"]
        Hidden = ["Police";"Medical";"Fire";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "HitTheWires_Title"
    InitialDescriptionKeys = ["HitTheWires_Description"]
    AssetRequirements = [
        "Police" , 2, 20 //40
        "Medic", 1, 30 //25
        "Medikit", 1, 5 //5
        "FireFighter", 5, 6//30
        "FoamExtinguisher", 1, 6 //6
    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 3100
    ReputationGainOnDispatch = 0, 80
    ReputationCostToTerminate = Some (40, 50)
    Events = [
        When.Emergency.Success [
            AddXp 14.0
            AddExhaustion 1.0
            Hq.Storage.Create "PaperWork" 3
            SetMood 1.0
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -2.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "Berlin_DucksFIshingWire"
    Type = Type.MedicalFireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 2.0
        Night = 0.0
    }
    Tags = {
        Visible = []
        Hidden = ["Medical";"Fire";"Berlin"]
    }
    TitleKey = "Berlin_DucksFIshingWire_Title"
    InitialDescriptionKeys = ["Berlin_DucksFIshingWire_Description"]
    AssetRequirements = [
        "Medic", 1, 25 //25
        "FireFighter", 3, 25//75
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 1100
    ReputationGainOnDispatch = 0, 50
    ReputationCostToTerminate = Some (20, 30)
    Events = [
        When.Emergency.Success [
            AddXp 6.0
            AddExhaustion 1.5
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -3.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "Berlin_DucksOnRoof"
    Type = Type.FireDept
    Difficulty = "Easy"
    Level = 1
    Weighting = {
        Day = 1.0
        Night = 0.0
    }
    Tags = {
        Visible = []
        Hidden = ["Fire";"OnLand";"Berlin"]
    }
    TitleKey = "Berlin_DucksOnRoof_Title"
    InitialDescriptionKeys = ["Berlin_DucksOnRoof_Description"]
    AssetRequirements = [
        "FireFighter", 3, 25//75
        "Ladder", 1, 25 //25
    ]
    PreparationTime = Gt.hours 3.0
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 1600
    ReputationGainOnDispatch = 0, 60
    ReputationCostToTerminate = Some (20, 30)
    Events = [
        When.Emergency.Success [
            AddXp 8.0
            AddExhaustion 1.0
            SetMood 2.0
            
        ]
        When.Emergency.Failure [
            AddExhaustion 2.0
            SetMood -3.0
            
        ]
    ]
}

