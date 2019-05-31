#load "EmergencyShared.fsx"
open EMT.Modding
open EmergencyShared

///////////////////////////
/// LEVEL V Emergencies./
/////////////////////////

Def.Emergency.Add {
    ID = "TheFugitive"
    Type = Type.Police
    Difficulty = "Hard"
    Level = 5
    Weighting = {
        Day = 1.0
        Night = 5.0
    }
    Tags = {
        Visible = ["Critical";"Pursuit"]
        Hidden = ["Police";"USA";"OnLand";"Berlin"]
    }
    TitleKey = "TheFugitive_Title"
    InitialDescriptionKeys = ["TheFugitive_Desc01"]
    AssetRequirements = [
        "Police", 12, 5 //60
        "Drones",4 , 10 //10
        "K9Unit",6 , 10 //20
        "DivingKit", 2, 5 //10
        "HighPowerCar" , 2, 10 //10


    ]
    PreparationTime = Gt.hours 5.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 21000
    ReputationGainOnDispatch = 0, 380
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 76.0
            AddInjury 0.01 0.02 ["Light"]
            AddExhaustion 6.0
            Emergency.AddVisitor "Prisoner"
            Hq.Storage.Create "PaperWork" 10
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
    ID = "TrainWreck"
    Type = Type.AllThree
    Difficulty = "Hard"
    Level = 5
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Urban";"Industrial"]
        Hidden = ["Police";"FireDept";"Medical";"OnLand";"Berlin";"USA"]
    }
    TitleKey = "TrainWreck_Title"
    InitialDescriptionKeys = ["TrainWreck_Desc01"]
    AssetRequirements = [
        "Police", 12, 1 //12
        "FireFighter", 30, 1 //30
        "Medic", 6, 1 //6
        "BreachingGear", 2, 5 //10
        "FoamExtinguisher", 10, 1 //10
        "BreathingApparatus", 10, 1 //10
        "Tank", 10, 1 //10
        "Drones", 2, 1 //2
        "K9Unit", 2, 2 //4
        "Medikit", 6, 1 //6



    ]
    PreparationTime = Gt.hours 4.5
    ResolutionTime = Gt.hours 9.0
    MoneyGainOnSuccess = 26000
    ReputationGainOnDispatch = 0, 350
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 86.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            Hq.Storage.Create "PaperWork" 20
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_HeartAttack"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"
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
    ID = "Flashfires"
    Type = Type.FireDept
    Difficulty = "Hard"
    Level = 5
    Weighting = {
        Day = 2.0
        Night = 0.5
    }
    Tags = {
        Visible = ["Critical"]
        Hidden = ["FireDept";"OnLand";"Berlin";"USA"]
    }
    TitleKey = "Flashfires_Title"
    InitialDescriptionKeys = ["Flashfires_Description"]
    AssetRequirements = [
        "FireFighter", 40, 1 //40
        "Tank", 10, 3 //30
        "BreathingApparatus", 25, 2 //50
    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 7.0
    MoneyGainOnSuccess = 23000
    ReputationGainOnDispatch = 0, 350
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 86.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
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
    ID = "ForestFireHuge"
    Type = Type.FireDept
    Difficulty = "Hard"
    Level = 5
    Weighting = {
        Day = 2.0
        Night = 2.5
    }
    Tags = {
        Visible = ["Critical";"ForestFire"]
        Hidden = ["FireDept";"OnLand";"Berlin";"USA"]
    }
    TitleKey = "ForestFireHuge_Title"
    InitialDescriptionKeys = ["ForestFireHuge_Description"]
    AssetRequirements = [
        "FireFighter", 40, 1 //40
        "Tank", 12, 2 //24
        "BreathingApparatus", 20, 1 //20
        "Tank", 2, 8 //16
    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 8.0
    MoneyGainOnSuccess = 21000
    ReputationGainOnDispatch = 0, 360
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 90.0
            AddInjury 0.1 0.4 ["Medium"]
            AddExhaustion 6.0
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
    ID = "BankRobberyHostages"
    Type = Type.PoliceMedical
    Difficulty = "Hard"
    Level = 5
    Weighting = {
        Day = 2.0
        Night = 0.0
    }
    Tags = {
        Visible = ["Critical";"Urban";"Shootout";"Hostage"]
        Hidden = ["Police";"Medical";"OnLand";"Berlin";"USA"]
    }
    TitleKey = "BankRobberyHostages_Title"
    InitialDescriptionKeys = ["BankRobberyHostages_Description"]
    AssetRequirements = [
        "Police", 20, 2 //40
        "AssaultGear", 12, 1 //12
        "SniperKit", 4, 2 //8
        "Drones", 2,2 //4
        "HighPowerCar" , 2, 8 //16
        "Medic", 4, 2 //8
        "Medikit", 6, 2 //12

    ]
    PreparationTime = Gt.hours 2.5
    ResolutionTime = Gt.hours 8.0
    MoneyGainOnSuccess = 21000
    ReputationGainOnDispatch = 0, 360
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 120.0
            AddInjury 0.1 0.4 ["Medium"]
            AddExhaustion 6.0
            SetMood 1.0
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            
        ]
        When.Emergency.Failure [
            AddExhaustion 8.0
            AddInjury 0.3 0.7 ["Heavy"]
            SetMood -3.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "Contagion"
    Type = Type.Medical
    Difficulty = "Hard"
    Level = 5
    Weighting = {
        Day = 2.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Urban";"Biohazard"]
        Hidden = ["Medical";"OnLand";"Berlin";"USA"]
    }
    TitleKey = "Contagion_Title"
    InitialDescriptionKeys = ["Contagion_Description"]
    AssetRequirements = [
        "Medic", 15, 2 //30
        "ContaminationSuit", 6 , 3 //18
        "Medikit", 8, 4 //32
        "Medicine",20 ,1 //20
    ]
    PreparationTime = Gt.hours 4.0
    ResolutionTime = Gt.hours 7.0
    MoneyGainOnSuccess = 26000
    ReputationGainOnDispatch = 0, 360
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 120.0
            AddInjury 0.05 0.4 ["Medium"]
            AddExhaustion 6.0
            SetMood 1.0
            
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_Triage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"
            If.Chance 0.5 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
            If.Chance 0.1 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_InternalDamage"]
        ]
        When.Emergency.Failure [
            AddExhaustion 8.0
            AddInjury 0.3 0.7 ["Heavy"]
            SetMood -3.0
            
        ]
    ]
}


Def.Emergency.Add {
    ID = "MassEscape"
    Type = Type.Police
    Difficulty = "Hard"
    Level = 5
    Weighting = {
        Day = 0.5
        Night = 2.0
    }
    Tags = {
        Visible = ["Critical";"Pursuit"]
        Hidden = ["Police";"OnLand";"USA";"MassEscape_Endless"]
    }
    TitleKey = "MassEscape_Title"
    InitialDescriptionKeys = ["MassEscape_Description"]
    AssetRequirements = [
        "Police", 20, 2 //40
        "Police", 5 , 2 //10
        "HighPowerCar", 4, 4 //16
        "AssaultGear", 10 ,1 //10
        "K9Unit", 6, 2 //12
        "Drones", 6, 2 //12
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 24000
    ReputationGainOnDispatch = 0, 330
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 120.0
            AddInjury 0.1 0.2 ["Medium"]
            AddExhaustion 6.0
            SetMood 1.0
            
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.2 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.2 [Emergency.AddVisitor "Prisoner"]
        ]
        When.Emergency.Failure [
            AddExhaustion 8.0
            AddInjury 0.3 0.7 ["Heavy"]
            SetMood -3.0
            
        ]
    ]
}

Def.Emergency.Add {
    ID = "HitWarehouse_Endless"
    Type = "HitWarehouse"
    Difficulty = "Special"
    Level = 99
    Weighting = {
        Day = 0.5
        Night = 2.0
    }
    Tags = {
        Visible = ["Critical";"Pursuit"]
        Hidden = ["Police";"OnLand";"USA";"HitWarehouse_Endless"]
    }
    TitleKey = "HitWarehouse_Title"
    InitialDescriptionKeys = ["HitWarehouse_Description"]
    AssetRequirements = [
        "Police", 40, 1 //40
        "Police", 5 , 2 //10
        "BombDefusalKit", 4, 5 //20
        "AssaultGear", 14 ,1 //14
        "K9Unit", 5, 3 //15
        "Drones", 5, 3 //15
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 24000
    ReputationGainOnDispatch = 0, 330
    ReputationCostToTerminate = Some (260, 260)
    Events = [
        When.Emergency.Success [
            AddXp 120.0
            AddInjury 0.1 0.2 ["Medium"]
            AddExhaustion 6.0
            SetMood 1.0
            
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.2 [Emergency.AddVisitor "Prisoner"]
            If.Chance 0.2 [Emergency.AddVisitor "Prisoner"]
        ]
        When.Emergency.Failure [
            AddExhaustion 8.0
            AddInjury 0.3 0.7 ["Heavy"]
            SetMood -3.0
            
        ]
    ]
}