#load "EmergencyShared.fsx"
open EMT.Modding
open EmergencyShared

Def.Emergency.Add {
    ID = "HouseFireSmallHoliday"
    Type = Type.FireDept
    Difficulty = "Special"
    Level = 99
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Urban";"NationalHoliday"]
        Hidden = ["NationalHoliday";"OnLand"]
    }
    TitleKey = "HouseFireHoliday_Title"
    InitialDescriptionKeys = ["HouseFireHoliday_Title_Desc01"]
    AssetRequirements = [
        "BreathingApparatus", 1, 24 //24
        "FireFighter", 4, 14 //56
        "Tank", 1, 20 //20
    ]
    PreparationTime = Gt.hours 1.5
    ResolutionTime = Gt.hours 1.5
    MoneyGainOnSuccess = 2900
    ReputationGainOnDispatch = 0, 80
    ReputationCostToTerminate = Some (40, 40)
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
    ID = "NatHoliday_BusCapture"
    Type = Type.Police
    Difficulty = "Special"
    Level = 100
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"NationalHoliday"]
        Hidden = ["NationalHoliday";"OnLand"]
    }
    TitleKey = "NatHoliday_BusCapture_Title"
    InitialDescriptionKeys = ["NatHoliday_BusCapture_Description"]
    AssetRequirements = [
        "Police", 2, 40 //80
        "Police", 2, 10 //20
        "HighPowerCar", 1, 20 //20
    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 2.5
    MoneyGainOnSuccess = 2300
    ReputationGainOnDispatch = 0, 80
    ReputationCostToTerminate = Some (80, 80)
    Events = [
        //When emergency is done no matter the result - alternative for result-agnostic effects
        When.Emergency.Done [
            AddExhaustion 3.0
        ]
        When.Emergency.Success [
            AddXp 16.0
            AddInjury 0.0 0.1 ["Light"]
            SetMood 1.0
            
        ]
        When.Emergency.Failure [
            AddInjury 0.1 0.2 ["Light"]
            SetMood -2.0
            
        ]
    ]
}


//event single emergencies - use level 99 

Def.Emergency.Add {
    ID = "MafiaBossTrial"
    Type = "MafiaBoss"
    Difficulty = "Special"
    Level = 99
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["MafiaBossTrial"]
        Hidden = ["OnLand"]
    }
    TitleKey = "MafiaBossTrial_Title"
    InitialDescriptionKeys = ["MafiaBossTrial_Desc01"]
    AssetRequirements = [
        "Police" , 8, 10 //80
        "AssaultGear",1,20 //20
    ]
    PreparationTime = Gt.hours 1.00
    ResolutionTime = Gt.hours 4.0
    MoneyGainOnSuccess = 25000
    ReputationGainOnDispatch = 0, 21
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 20.0
            AddExhaustion 3.0
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            Hq.Storage.Create "PaperWork" 15
            AddInjury 0.05 0.1 ["Light"]
            SetMood 1.0
            Hq.Unlocks.Add "MafiaBossTrialDone"
            Hq.Objective.add "SetupMedicalStation_Win"
            Hq.showQuestGiver "SetupMedical_win"
            
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.2 0.4 ["Medium"]
            SetMood -2.0
            Hq.Unlocks.Add "MafiaBossTrialDone"
            Hq.Objective.add "SetupMedicalStation_Fail"
            Hq.showQuestGiver "SetupMedical_fail"
            
        ]

        When.Emergency.Expiration[
            Hq.Unlocks.Add "MafiaBossTrialDone"
            Hq.Objective.add "SetupMedicalStation_Fail"
            Hq.showQuestGiver "SetupMedical_fail"

        ]
    ]
}

Def.Emergency.Add {
    ID = "FoodPoisoning"
    Type = "StreetFoodEvent"
    Difficulty = "Special"
    Level = 99
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["FoodPoisoning";"Biohazard"]
        Hidden = ["Medical";"StreetFoodFair";"OnLand"]
    }
    TitleKey = "FoodPoisoning_Title"
    InitialDescriptionKeys = ["FoodPoisoning_desc"]
    AssetRequirements = [
        "Medic", 2, 50 //100
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 3000
    ReputationGainOnDispatch = 0, 100
    ReputationCostToTerminate = Some (100, 100)
    Events = [
        When.Emergency.Success [
            AddXp 14.0
            AddExhaustion 3.0
            AddInjury 0.05 0.1 ["Light"]
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"
            If.Chance 0.7 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"]
            If.Chance 0.3 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"]
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
    ID = "FoodPoisoning_2"
    Type = "StreetFoodEvent"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["FoodPoisoning";"Biohazard"]
        Hidden = ["Medical";"StreetFoodFair";"OnLand"]
    }
    TitleKey = "FoodPoisoning_Title_2"
    InitialDescriptionKeys = ["FoodPoisoning_desc_2"]
    AssetRequirements = [
        "Medic", 4, 25 //100
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 5000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = Some (150, 150)
    Events = [
        When.Emergency.Success [
            AddXp 14.0
            AddExhaustion 3.0
            AddInjury 0.05 0.1 ["Light"]
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"
            If.Chance 0.7 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"]
            If.Chance 0.3 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"]
            If.Chance 0.3 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"]
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
    ID = "StreetfoodMassPanic"
    Type = "StreetFoodEvent"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical"]
        Hidden = ["Police";"StreetFoodFair";"OnLand"]
    }
    TitleKey = "StreetfoodMassPanic_Title"
    InitialDescriptionKeys = ["StreetfoodMassPanic_Description"]
    AssetRequirements = [
        "Police", 6, 15 //90
        "CrowdControl", 2, 5 //10
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 3.0
    MoneyGainOnSuccess = 5000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = Some (150, 150)
    Events = [
        When.Emergency.Success [
            AddXp 14.0
            AddExhaustion 3.0
            AddInjury 0.05 0.1 ["Light"]
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"
            If.Chance 0.7 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"]
            If.Chance 0.3 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"]
            If.Chance 0.3 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FoodPoisioning"]
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
    ID = "TrainWreck_EndGame"
    Type = "Trainwreck_EndGame"
    Difficulty = "Special"
    Level = 99
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Urban";"Industrial"]
        Hidden = ["Police";"FireDept";"Medical";"TrainWreck";"OnLand"]
    }
    TitleKey = "TrainWreck__EndGame_Title"
    InitialDescriptionKeys = ["TrainWreck_EndGame_Desc01"]
    AssetRequirements = [
        "Police", 12, 1 //12
        "FireFighter", 28, 1 //28
        "Medic", 10, 2 //20
        "BreachingGear", 2, 1 //2
        "FoamExtinguisher", 10, 1 //10
        "BreathingApparatus", 10, 1 //10
        "Tank", 8, 1 //8
        "Drones", 2, 1 //2
        "K9Unit", 2, 2 //4
        "Medikit", 6, 1 //6



    ]
    PreparationTime = Gt.hours 4.5
    ResolutionTime = Gt.hours 9.0
    MoneyGainOnSuccess = 16000
    ReputationGainOnDispatch = 0, 250
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 0.0
            Hq.SetGameIsWon ()

        ]
        When.Emergency.Failure [
           Hq.SetGameIsLost "finalMissionFailed"
        ]
    
        When.Emergency.Expiration[
            Hq.SetGameIsLost "finalMissionFailed"
        ]
    ]    
}

Def.Emergency.Add {
    ID = "TrainWreck_Endless"
    Type = "Trainwreck_EndGame"
    Difficulty = "Special"
    Level = 99
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Urban";"Industrial"]
        Hidden = ["Police";"FireDept";"Medical";"TrainWreck_Endless";"OnLand"]
    }
    TitleKey = "TrainWreck__EndGame_Title"
    InitialDescriptionKeys = ["TrainWreck_EndGame_Desc01"]
    AssetRequirements = [
        "Police", 12, 1 //12
        "FireFighter", 28, 1 //28
        "Medic", 10, 2 //20
        "BreachingGear", 2, 1 //2
        "FoamExtinguisher", 10, 1 //10
        "BreathingApparatus", 10, 1 //10
        "Tank", 8, 1 //8
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
    ID = "Rioting_EcoTerrorism"
    Type = "EcoTerrorism"
    Difficulty = "special"
    Level = 99
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Biohazard"]
        Hidden = ["Police";"FireDept";"Medical";"Rioting_EcoTerrorism";"OnLand"]
    }
    TitleKey = "Rioting_EcoTerrorism_Title"
    InitialDescriptionKeys = ["Rioting_EcoTerrorism_Desc01"]
    AssetRequirements = [
        "Police", 10, 2 //20
        "Drones", 3, 3 //9
        "RiotGear",4, 2 //8
        "FireFighter", 10,2 //20
        "HazmatSuit", 3, 3 //9
        "Medic", 6, 3 //18
        "ContaminationSuit", 4, 4 //16
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 6.0
    MoneyGainOnSuccess = 29000
    ReputationGainOnDispatch = 0, 190
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 40.0
            AddInjury 0.05 0.2 ["Medium"]
            AddExhaustion 6.0
            Hq.Storage.Create "PaperWork" 20
            Hq.Storage.Create "Evidence" 10
            Emergency.AddVisitor "Prisoner"
            Emergency.AddVisitor "Prisoner"
            If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"
            Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"
            If.Chance 0.8 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_FallTrauma"]
            SetMood 1.0
            
            Hq.showQuestGiver "Rioting_EcoTerrorism_win"
            Hq.Unlocks.Add "Rioting_EcoTerrorismDone" 
        ]
        When.Emergency.Failure [
            AddExhaustion 6.0
            AddInjury 0.02 0.04 ["Heavy"]
            SetMood -2.0
            
            Hq.showQuestGiver "Rioting_EcoTerrorism_fail"
            Hq.Unlocks.Add "Rioting_EcoTerrorismDone" 
        ]
        When.Emergency.Expiration[
            Hq.showQuestGiver "Rioting_EcoTerrorism_expire"
            Hq.Unlocks.Add "Rioting_EcoTerrorismDone" 
        ]
    ]
}



Def.Emergency.Add {
    ID = "EcoSummitPreparation"
    Type = "EcoSummitPrep"
    Difficulty = "Special"
    Level = 99
    Weighting = {
        Day = 2.0
        Night = 2.0
    }
    Tags = {
        Visible = ["Urban";"Critical";"Biohazard"]
        Hidden = ["EcoSummitPreparation";"OnLand"]
    }
    TitleKey = "EcoSummitPreparation_Title"
    InitialDescriptionKeys = ["EcoSummitPreparation_Desc01"]
    AssetRequirements = [
        "FireFighter", 8, 5 //40
        "Medic" , 2, 20 //20
        "HazmatSuit", 1,10 //10
        "BreathingApparatus", 4,5 //20 
        "ContaminationSuit",1,10 //10

    ]
    PreparationTime = Gt.hours 2.0
    ResolutionTime = Gt.hours 1.0
    MoneyGainOnSuccess = 28000
    ReputationGainOnDispatch = 0, 80
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 23.0
            AddExhaustion 3.0
            If.Chance 0.2 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
            If.Chance 0.1 [Emergency.AddVisitorWithTrait "Patient" "PatientArchetype_LightBurn"]
            SetMood 1.0
            
            Hq.showQuestGiver "EcoSummitPreparation_win"
            Hq.Unlocks.Add "EcoSummitPreparationDone" 
        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            SetMood -2.0
            
            Hq.showQuestGiver "EcoSummitPreparation_fail"
            Hq.Unlocks.Add "EcoSummitPreparationDone" 
        ]
        When.Emergency.Expiration[
            Hq.showQuestGiver "EcoSummitPreparation_expire"
            Hq.Unlocks.Add "EcoSummitPreparationDone"  
        ]
    ]
}


Def.Emergency.Add {
    ID = "MedicineBust"
    Type = "MedicineBust"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Shootout";"Industrial"]
        Hidden = ["MedicineBust";"OnLand"]
    }
    TitleKey = "MedicineBust_Title"
    InitialDescriptionKeys = ["MedicineBust_Description"]
    AssetRequirements = [
        "Police", 12, 5 //60
        "K9Unit",2,5 //10 
        "AssaultGear", 4, 5 //20
        "SniperKit", 2, 10 //20
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 5000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 24.0
            AddExhaustion 3.0
            AddInjury 0.05 0.1 ["Medium"]

            SetMood 1.0
            Hq.showQuestGiver "MedicineBust_win"
            

        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Heavy"]
            SetMood -2.0
            
            Hq.showQuestGiver "MedicineBust_fail"
        ]
        When.Emergency.Expiration[
            Hq.showQuestGiver "MedicineBust_expire"
        ]
    ]
}


/// USA Story Missions
/// 
/// 

Def.Emergency.Add {
    ID = "SafehouseHit"
    Type = "SafehouseHit"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Shootout";"Urban"]
        Hidden = ["SafehouseHit";"OnLand"]
    }
    TitleKey = "SafehouseHit_Title"
    InitialDescriptionKeys = ["SafehouseHit_Description"]
    AssetRequirements = [
        "Police", 12, 5 //60
        "K9Unit",2,5 //10 
        "AssaultGear", 4, 5 //20
        "SniperKit", 2, 5//10
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 5000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 24.0
            AddExhaustion 3.0
            AddInjury 0.05 0.1 ["Medium"]
            SetMood 1.0
            
            Hq.showQuestGiver "SafehouseHit_win"

        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Heavy"]
            SetMood -2.0
            
            Hq.showQuestGiver "SafehouseHit_fail"
        ]
        When.Emergency.Expiration[
            Hq.showQuestGiver "SafehouseHit_expire"
        ]
    ]
}


Def.Emergency.Add {
    ID = "KidnapKingpin"
    Type = "KidnapKingpin"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Hostage";"Urban"]
        Hidden = ["KidnapKingpin";"OnLand"]
    }
    TitleKey = "KidnapKingpin_Title"
    InitialDescriptionKeys = ["KidnapKingpin_Description"]
    AssetRequirements = [
        "Police", 20, 2 //40
        "AssaultGear", 4, 5 //20
        "SniperKit", 4, 10 //40
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 5000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 24.0
            AddExhaustion 3.0
            AddInjury 0.05 0.1 ["Medium"]

            SetMood 1.0
            
            Hq.showQuestGiver "KidnapKingpin_win"

        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Heavy"]
            SetMood -2.0
            
            Hq.showQuestGiver "KidnapKingpin_fail"
        ]
        When.Emergency.Expiration[
            Hq.showQuestGiver "KidnapKingpin_expire"
        ]
    ]
}


Def.Emergency.Add {
    ID = "HitWarehouse"
    Type = "HitWarehouse"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Industrial";"Shootout"]
        Hidden = ["HitWarehouse";"OnLand"]
    }
    TitleKey = "HitWarehouse_Title"
    InitialDescriptionKeys = ["HitWarehouse_Description"]
    AssetRequirements = [
        "Police", 12, 5 //60
        "K9Unit",2,5 //10 
        "AssaultGear", 4, 5 //20
        "SniperKit", 2, 10 //20
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 5000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 24.0
            AddExhaustion 3.0
            AddInjury 0.05 0.1 ["Medium"]
            Hq.showQuestGiver "HitWarehouse_win"
            SetMood 1.0
            

        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Heavy"]
            SetMood -2.0
            
            Hq.showQuestGiver "HitWarehouse_fail"
        ]
        When.Emergency.Expiration[
            Hq.showQuestGiver "HitWarehouse_expire"
        ]
    ]
}


Def.Emergency.Add {
    ID = "RestoreUtilities"
    Type = "RestoreUtilities"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Urban"]
        Hidden = ["RestoreUtilities";"OnLand"]
    }
    TitleKey = "RestoreUtilities_Title"
    InitialDescriptionKeys = ["RestoreUtilities_Description"]
    AssetRequirements = [
        "Police", 12, 5 //60
        "K9Unit",2,5 //10 
        "AssaultGear", 4, 5 //20
        "SniperKit", 2, 10 //20
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 2.0
    MoneyGainOnSuccess = 5000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 24.0
            AddExhaustion 3.0
            AddInjury 0.05 0.1 ["Medium"]
            Hq.showQuestGiver "RestoreUtilities_win"
            SetMood 1.0
            

        ]
        When.Emergency.Failure [
            AddExhaustion 3.0
            AddInjury 0.1 0.2 ["Heavy"]
            SetMood -2.0
            
            Hq.showQuestGiver "RestoreUtilities_fail"
        ]
        When.Emergency.Expiration[
            Hq.showQuestGiver "RestoreUtilities_expire"
        ]
    ]
}


Def.Emergency.Add {
    ID = "Stronghold"
    Type = "Stronghold"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Shootout"]
        Hidden = ["Stronghold";"OnLand"]
    }
    TitleKey = "Stronghold_Title"
    InitialDescriptionKeys = ["Stronghold_Description"]
    AssetRequirements = [
        "Police", 30, 2 //60
        "K9Unit",5,2 //10 
        "AssaultGear", 10, 2 //20
        "SniperKit", 4, 5 //20
        "DivingKit", 4, 5 //20
    ]
    PreparationTime = Gt.hours 3.5
    ResolutionTime = Gt.hours 5.0
    MoneyGainOnSuccess = 125000
    ReputationGainOnDispatch = 0, 150
    ReputationCostToTerminate = None
    Events = [
        When.Emergency.Success [
            AddXp 0.0
            Hq.SetGameIsWon ()

        ]
        When.Emergency.Failure [
           Hq.SetGameIsLost "finalMissionFailed"
        ]
    ]
}

Def.Emergency.Add {
    ID = "Stronghold_Endless"
    Type = "Stronghold"
    Difficulty = "Special"
    Level = 99
    
    Weighting = {
        Day = 1.0
        Night = 1.0
    }
    Tags = {
        Visible = ["Critical";"Shootout"]
        Hidden = ["Stronghold_Endless";"OnLand"]
    }
    TitleKey = "Stronghold_Title"
    InitialDescriptionKeys = ["Stronghold_Description"]
    AssetRequirements = [
        "Police", 12, 5 //60
        "K9Unit",2,5 //10 
        "AssaultGear", 4, 5 //20
        "SniperKit", 2, 10 //20
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
            
        ]
        When.Emergency.Failure [
            AddExhaustion 8.0
            AddInjury 0.3 0.7 ["Heavy"]
            SetMood -3.0
            
        ]
    ]
}