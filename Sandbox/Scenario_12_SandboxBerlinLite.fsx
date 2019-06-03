#load "Include.fsx"
open EMT.Modding
 
Def.Scenario.Add {
    ID = "SandboxBerlinLite"
    EnableTutorials = No

    ApplicantTimeout = Gt.days 1.0
    FireProtectionTime = Gt.weeks 1.0

    Level = "SandboxBerlinLite", ["WholeMap"]

    VehicleRepairRate = Gt.perHour 20.0

    EconomySystem = {
        InitialFunds = 100_000
        AwardedCityGrants = 2
        MoneyPerCityGrant = 120_000
    }

    ReputationSystem = {
        MoneyPerReputation = 100
        Ranks = [
            {MaxReputation = 600; CityHallPayments = 50_000}
            {MaxReputation = 1000; CityHallPayments = 70_000}
            {MaxReputation = 1_300; CityHallPayments = 100_000}
            {MaxReputation = 1_800; CityHallPayments = 120_000}
            {MaxReputation = 2_300; CityHallPayments = 130_000}
        ]
    }

    Events = [
        When.Init [
            Hq.Objective.add "SetupFireStation"
            //Day Shift
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
            // Night Shift
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
        ]
        When.ShiftStart [
        ]
        When.ShiftEnd [
        ]
    ]

    TimeLine =
        (*let w1 (hours) = gt 0 2 0. + Gt.hours hours
        let w2 (hours) = gt 0 5 0. + Gt.hours hours
        let w3 (hours) = gt 0 7 0. + Gt.hours hours*)

        
        [
        TimeLine.At (gt 4 7 0.0) [Hq.SetGameIsWon () ]

        TimeLine.Wave (gt 0 0 12.0) (gt 0 1 12.0) (gt 0 3 0.0) "Tutorial_1" "w_NationalHoliday01"
        TimeLine.At (gt 0 0 12.0) [Hq.showQuestGiver "NationalHoliday_Announced"]
        TimeLine.At (gt 0 1 8.0) [Hq.showQuestGiver "NationalHoliday_Impending"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 1 12.0, gt 0 3 0.0
            Interval = Gt.hours 6.0
            Tags = ["NationalHoliday"]
            Patterns = [
                {Weight = 3; Levels = [99;100]}
                {Weight = 5; Levels = [99]}
                {Weight = 1; Levels = [99;99;100]}
            ]            
        }
        TimeLine.At (gt 0 2 10.0) [Hq.showQuestGiver "NationalHoliday_AlmostDone"]
       
        TimeLine.Wave (gt 0 1 1.0) (gt 0 5 8.0) (gt 0 5 9.0) "MafiaBossTrial" "w_MafiaBossTrial"
        TimeLine.ForceEmergencyAt (gt 0 5 8.0) 99 99 ["MafiaBossTrial"]
        TimeLine.At (gt 0 4 22.0) [Hq.showQuestGiver "MafiaBossTrial_Impending"]
        TimeLine.At (gt 0 1 1.0) [Hq.Objective.add "MafiaBossTrialToDo" ]
        TimeLine.At (gt 0 5 12.1) [Hq.Unlocks.Add "MafiaBossTrialDone" ]


        TimeLine.Wave (gt 0 4 1.0) (gt 1 2 12.0) (gt 1 4 20.0) "SportsFestival" "w_SportsFestival"
        TimeLine.At (gt 0 4 1.0) [Hq.showQuestGiver "SportsFestival_Announced"]
        TimeLine.At (gt 1 2 6.0) [Hq.showQuestGiver "SportsFestivalToDo"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 1 2 12.0, gt 1 4 20.0
            Interval = Gt.hours 4.0
            Tags = ["SportsFestival"]
            Patterns = [
                {Weight = 2; Levels = [1;2;3]}
                {Weight = 3; Levels = [1;2;2]}
                {Weight = 1; Levels = [2;3]}
            ]            
        }
        TimeLine.At (gt 1 4 10.0) [Hq.showQuestGiver "SportsFestival_AlmostDone"]

        TimeLine.Wave (gt 0 6 8.0) (gt 1 6 8.0) (gt 1 6 9.0) "EcoSummitPreparation" "w_EcoSummitPreparation"
        TimeLine.ForceEmergencyAt (gt 1 6 8.0) 99 99 ["EcoSummitPreparation"]
        TimeLine.At (gt 1 6 0.0) [Hq.showQuestGiver "EcoSummitPreparation_Impending"]
        TimeLine.At (gt 0 6 8.0) [Hq.Objective.add "EcoSummitPreparationToDo" ]
        TimeLine.At (gt 1 6 9.0) [Hq.Unlocks.Add "EcoSummitPreparationDone" ]

        TimeLine.Wave (gt 1 4 1.0) (gt 2 2 16.0) (gt 2 2 20.0) "MedicineBust" "w_MedicineBust"
        TimeLine.ForceEmergencyAt (gt 2 2 16.0) 99 99 ["MedicineBust"]
        TimeLine.At (gt 2 2 8.0) [Hq.showQuestGiver "MedicineBust_Impending"]
        TimeLine.At (gt 1 4 1.0) [Hq.Objective.add "MedicineBustToDo" ]
        TimeLine.At (gt 2 2 20.0) [Hq.Unlocks.Add "MedicineBustDone" ]       

        TimeLine.Wave (gt 2 0 1.0) (gt 2 6 8.0) (gt 2 7 20.0) "StreetFoodFair" "w_StreetFoodFair"
        TimeLine.At (gt 2 0 1.0) [Hq.showQuestGiver "StreetFoodFair_Announced"]
        TimeLine.At (gt 2 5 18.0) [Hq.showQuestGiver "StreetFoodFairToDo"]
        TimeLine.ForceEmergencyAt (gt 2 6 12.0) 99 99 ["StreetFoodFair"]
        TimeLine.ForceEmergencyAt (gt 2 6 18.0) 99 99 ["StreetFoodFair"]
        TimeLine.ForceEmergencyAt (gt 2 7 8.0) 99 99 ["StreetFoodFair"]
        TimeLine.ForceEmergencyAt (gt 2 7 12.0) 99 99 ["StreetFoodFair"]
        TimeLine.ForceEmergencyAt (gt 2 7 12.0) 99 99 ["StreetFoodFair"]
        TimeLine.ForceEmergencyAt (gt 2 7 18.0) 99 99 ["StreetFoodFair"]
        TimeLine.ForceEmergencyAt (gt 2 7 18.0) 99 99 ["StreetFoodFair"]
        TimeLine.At (gt 2 7 8.0) [Hq.showQuestGiver "StreetFoodFair_AlmostDone"]

        TimeLine.Wave (gt 2 3 1.0) (gt 3 2 12.0) (gt 3 2 20.0) "Rioting_EcoTerrorism" "w_Rioting_EcoTerrorism"
        TimeLine.ForceEmergencyAt (gt 3 2 12.0) 99 99 ["Rioting_EcoTerrorism"]
        TimeLine.At (gt 3 2 8.0) [Hq.showQuestGiver "Rioting_EcoTerrorism_Impending"]
        TimeLine.At (gt 2 3 1.0) [Hq.Objective.add "Rioting_EcoTerrorismToDo" ]
        TimeLine.At (gt 3 2 20.0) [Hq.Unlocks.Add "Rioting_EcoTerrorismDone" ] 

        TimeLine.Wave (gt 3 0 1.0) (gt 3 6 12.0) (gt 4 1 20.0) "Civil_Movement" "w_Civil_Movement"
        TimeLine.At (gt 3 0 1.0) [Hq.showQuestGiver "Civil_Movement_Announced"]
        TimeLine.At (gt 3 6 1.0) [Hq.showQuestGiver "Civil_MovementToDo"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 3 6 12.0, gt 4 1 20.0
            Interval = Gt.hours 4.0
            Tags = ["Civil_Movement"]
            Patterns = [
                {Weight = 2; Levels = [2;3;4]}
                {Weight = 3; Levels = [2;3;3]}
                {Weight = 1; Levels = [3;4]}
            ]            
        }
        TimeLine.At (gt 4 1 8.0) [Hq.showQuestGiver "Civil_Movement_AlmostDone"]

        TimeLine.Wave (gt 3 4 1.0) (gt 4 3 12.0) (gt 4 4 20.0) "HeatWave" "w_HeatWave"
        TimeLine.At (gt 3 4 1.0) [Hq.showQuestGiver "HeatWave_Announced"]
        TimeLine.At (gt 4 3 6.0) [Hq.showQuestGiver "HeatWaveToDo"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 4 3 12.0, gt 4 4 20.0
            Interval = Gt.hours 4.0
            Tags = ["HeatWave"]
            Patterns = [
                {Weight = 2; Levels = [3;4]}
                {Weight = 3; Levels = [2;3;3]}
                {Weight = 1; Levels = [5]}
            ]            
        }
        TimeLine.At (gt 4 4 8.0) [Hq.showQuestGiver "HeatWave_AlmostDone"]

        TimeLine.Wave (gt 4 0 1.0) (gt 4 6 12.0) (gt 4 6 14.0) "TrainWreck" "w_TrainWreck"
        TimeLine.ForceEmergencyAt (gt 4 6 12.0) 99 99 ["TrainWreck"]
        TimeLine.At (gt 4 6 8.0) [Hq.showQuestGiver "TrainWreck_Impending"]
        TimeLine.At (gt 4 0 1.0) [Hq.Objective.add "TrainWreckToDo" ]
        //TimeLine.At (gt 4 7 20.0) [Hq.SetGameIsLost () ]


(* //One way of spawning emergency waves - but not synched
        TimeLine.RandomSpacing.Emergencies {
            TimeSpan = gt 0 0 6.0, gt 0 2 0.
            Spacing = Gt.hours 3.0, Gt.hours 5.0
            Level = 1, 1
            Tags = []
        }

//The method to spawn synched emergencies
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 0 0., gt 0 1 0.
            Interval = Gt.hours 4.0
            Tags = []
            Patterns = [
                {Weight = 1; Levels = [1]}
            ]            
        }   
        *)



        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 0 0., gt 0 1 12.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [1]}
            ]            
        }   
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 0 0., gt 0 1 12.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [1]}
            ]            
        }  
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 0 0., gt 0 1 12.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [1]}
                {Weight = 1; Levels = []}
            ]            
        }  


        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 1 20., gt 0 4 20.
            Interval = Gt.hours 8.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 2; Levels = [1;1]}
                {Weight = 5; Levels = [1;2]}
                {Weight = 5; Levels = [1;2;1]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 5 12., gt 1 2 6.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [2;2]}
                {Weight = 5; Levels = [2;2]}
                {Weight = 3; Levels = [2;3]}
                {Weight = 1; Levels = [2;2;2]}
            ]            
        }

        TimeLine.Interval.Emergencies {
            TimeSpan = gt 1 4 12., gt 2 0 0.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [2;2]}
                {Weight = 5; Levels = [2;2]}
                {Weight = 3; Levels = [2;3]}
                {Weight = 1; Levels = [2;2;2]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 2 0 0., gt 2 5 0.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [2;2]}
                {Weight = 5; Levels = [2;2;2]}
                {Weight = 5; Levels = [2;3]}
                {Weight = 3; Levels = [2;3;2]}
                {Weight = 3; Levels = [2;2;3]}
                {Weight = 1; Levels = [3;3]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 2 6 0., gt 3 2 0.
            Interval = Gt.hours 6.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [3;3;3]}
                {Weight = 5; Levels = [3;3;2]}
                {Weight = 5; Levels = [2;3;4]}
                {Weight = 3; Levels = [2;3;3]}
                {Weight = 1; Levels = [3;3;4]}
            ]            
        }

        TimeLine.Interval.Emergencies {
            TimeSpan = gt 3 3 0., gt 3 5 12.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [3;3;4;4]}
                {Weight = 5; Levels = [3;3;3;4]}
                {Weight = 5; Levels = [3;3;4]}
                {Weight = 3; Levels = [3;3;5]}
                {Weight = 1; Levels = [3;3;5]}
            ]            
        }

        TimeLine.Interval.Emergencies {
            TimeSpan = gt 3 6 0., gt 4 1 0.
            Interval = Gt.hours 6.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [3;4;4]}
                {Weight = 5; Levels = [3;3;4]}
                {Weight = 5; Levels = [3;3;4]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 4 1 12., gt 4 3 0.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [3;3;4;4]}
                {Weight = 5; Levels = [3;3;3;4]}
                {Weight = 5; Levels = [3;3;4]}
                {Weight = 3; Levels = [3;3;5]}
                {Weight = 1; Levels = [3;3;5]}
            ]            
        }
        


    ]


    Objectives = [
        (*{
            ID = "BuildToilets"
            Goals = [
                Goal.SmartObject.Build "Toilet_01" 10
                Goal.RequireMoney 1000
                Goal.Economy.HaveReputation 100
                Goal.Economy.HaveReputationCap 200
              
            ]
            Events = [
                When.Objective.Done [
                    Hq.Money.Add 1000
                ]
            ]
        }*)
        /// story missions 
        
        {
            ID = "MafiaBossTrialToDo"
            Goals = [
                    Goal.HaveUnlocked "MafiaBossTrialDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "MafiaBossTrialToDo"]
                When.Objective.Done [
                    
                ]
            ]
        }
        {
            ID = "EcoSummitPreparationToDo"
            Goals = [
                    Goal.HaveUnlocked "EcoSummitPreparationDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "EcoSummitPreparationToDo"]
                When.Objective.Done [
                    
                ]
            ]
        }
        {
            ID = "MedicineBustToDo"
            Goals = [
                    Goal.HaveUnlocked "MedicineBustDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "MedicineBustToDo"]
                When.Objective.Done [
                    
                ]
            ]
        }
        {
            ID = "Rioting_EcoTerrorismToDo"
            Goals = [
                    Goal.HaveUnlocked "Rioting_EcoTerrorismDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "Rioting_EcoTerrorismToDo"]
                When.Objective.Done [
                    
                ]
            ]
        }
        {
            ID = "TrainWreckToDo"
            Goals = [
                    Goal.HaveUnlocked "TrainWreckDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "TrainWreckToDo"]
                When.Objective.Done [
                    
                ]
            ]
        }




        //Set up fire station basics 

        {
            ID = "SetupFireStation"
            Goals = [
                
                Goal.SmartObject.Build "FireEngine_LF10" 2
                Goal.SmartObject.Build "HiringDeskFirefighter" 1
                Goal.SmartObject.Build "GasBottleRefiller" 1
                Goal.SmartObject.Build "BreathingApparatusStorage" 2
                Goal.SmartObject.Build "WaterBuckets_01" 2
                
            ]
            Rewards = [
                Reward.Profession 3 "GetActor" "FireFighter" [
                    Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
                ]
                Reward.Profession 3 "GetApplicant" "FireFighter" [
                    Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
                ]
                Reward.Money 10000
            ]
            Events = [
                When.Init [Hq.showQuestGiver "SetupFireStation_Hard"]
                When.Objective.Done [
                    //Hq.showQuestGiver "SetupFireStation_done"
                    Hq.Objective.add "CommonAreaSetup"
                    Hq.Unlocks.Add "SFL_UnlockFD"
                    Hq.Unlocks.Add "US_FireDept_Unlock"
                    Hq.Unlocks.Add "Berlin_Firestation_Done"
                    
                ]
            ]
        }

        



        {
            ID = "CommonAreaSetup"
            Goals = [
                
                Goal.SmartObject.Build "Toilet_01" 1
                Goal.SmartObject.Build "Shower" 1
                Goal.SmartObject.Build "BathroomSink" 1
                Goal.SmartObject.Build "Fridge" 1
                Goal.SmartObject.Build "Bed" 1
                Goal.Economy.HaveReputation 200
            ]
            Rewards = [
                Reward.Money 20000
                Reward.Profession 4 "GetActor" "Police" [
                    Hq.Actors.Create "Police" [Actor.LevelUp ()]
                ]
                Reward.Profession 4 "GetApplicant" "Police" [
                    Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [Hq.showQuestGiver "SetupCommonArea"]
                When.Objective.Done [
                    Hq.Unlocks.Add "UnlockPolice"
                    //Hq.showQuestGiver "SetupCommonArea_done"

                    Hq.Objective.add "SetupPoliceStation"
                ]
            ]
        }  

        {
            ID = "SetupPoliceStation"
            Goals = [
                Goal.SmartObject.Build "PersonalLocker_Police" 8
                Goal.SmartObject.Build "PoliceCar_Cruiser" 2
                Goal.SmartObject.Build "PoliceDesk" 1
                Goal.SmartObject.Build "FileCabinet" 1
                Goal.SmartObject.Build "HiringDeskPolice" 1
                Goal.Economy.HaveReputation 300
            ]
            Rewards = [
                Reward.Money 25000
                Reward.Profession 2 "GetActor" "Police" [
                    Hq.Actors.Create "Police" [Actor.LevelUp ()]
                ]
                Reward.Profession 2 "GetApplicant" "FireFighter" [
                    Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [Hq.showQuestGiver "SetupPolice"]
                When.Objective.Done [
                    
                    Hq.showQuestGiver "SetupPolice_done"
                    Hq.Unlocks.Add "Berlin_PoliceStation_Done"
                    //Hq.Objective.add "MafiaBossTrialQuest"
                ]
            ]
        } 

        {
            ID = "MafiaBossTrialQuest"
            Goals = [
                Goal.HaveUnlocked "MafiaBossTrialDone"
            ]
            Rewards = []
            Events = [
                When.Init []
                When.Objective.Done [
                    Hq.Actors.Create "Police" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
            ]
        } 

        {
            ID = "SetupMedicalStation_Fail"
            Goals = [
                Goal.SmartObject.Build "PersonalLocker_Medical" 4
                Goal.SmartObject.Build "Ambulance_Standard" 1
                Goal.SmartObject.Build "RoomTriageStation" 1
                Goal.SmartObject.Build "MedicineLab" 1
                Goal.SmartObject.Build "RoomBurnTreatment" 1
                Goal.SmartObject.Build "HiringDeskMedic" 1
                Goal.Economy.HaveReputation 300
            ]
            Rewards = [
                Reward.Money 25000
                Reward.Profession 3 "GetActor" "Medic" [
                    Hq.Actors.Create "Medic" [Actor.LevelUp ()]
                ]
                Reward.Profession 3 "GetActor" "Medic" [
                    Hq.Actors.CreateOtherShift "Medic" [Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [
                    Hq.Unlocks.Add "UnlockMedical"
                    Hq.Actors.CreateOtherShift "Medic" []
                    Hq.Actors.Create "Medic" []
                    Hq.Actors.CreateOtherShift "Medic" []
                    Hq.Actors.Create "Medic" []
                    Hq.Money.Income 20000
                ]
                When.Objective.Done [
                    //Hq.showQuestGiver "SetupMedical_done"
                    Hq.Unlocks.Add "SetupMedicalStation_Done"
                    Hq.Objective.add "GetNextRepLevel"
                    
                ]
            ]
        }

        {
            ID = "SetupMedicalStation_Win"
            Goals = [
                Goal.SmartObject.Build "PersonalLocker_Medical" 4
                Goal.SmartObject.Build "Ambulance_Standard" 1
                Goal.SmartObject.Build "RoomTriageStation" 1
                Goal.SmartObject.Build "MedicineLab" 1
                Goal.SmartObject.Build "RoomBurnTreatment" 1
                Goal.SmartObject.Build "HiringDeskMedic" 1
                Goal.Economy.HaveReputation 300
            ]
            Rewards = [
                Reward.Money 15000
                Reward.Profession 3 "GetActor" "Medic" [
                    Hq.Actors.Create "Medic" []
                ]
                Reward.Profession 3 "GetActor" "Medic" [
                    Hq.Actors.CreateOtherShift "Medic" []
                ]
            ]
            Events = [
                When.Init [
                    Hq.Unlocks.Add "UnlockMedical"
                    Hq.Actors.CreateOtherShift "Medic" []
                    Hq.Actors.Create "Medic" []
                    Hq.Actors.CreateOtherShift "Medic" []
                    Hq.Actors.Create "Medic" []
                    Hq.Money.Income 80000
                ]
                When.Objective.Done [
                    //Hq.showQuestGiver "SetupMedical_done"
                    Hq.Unlocks.Add "SetupMedicalStation_Done"
                    Hq.Objective.add "GetNextRepLevel"
                    
                ]
            ]
        }  

        {
            ID = "GetNextRepLevel"
            Goals = [
                Goal.Economy.HaveReputation 800
            ]
            Rewards = [
                Reward.Money 15000
                Reward.Profession 1 "GetActor" "Medic" [
                    Hq.Actors.Create "Medic" [Actor.LevelUp ();  Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Medic" [
                    Hq.Actors.CreateOtherShift "Medic" [Actor.LevelUp ()]
                ]

                Reward.Profession 1 "GetActor" "Police" [
                    Hq.Actors.Create "Police" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Police" [
                    Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]

                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.Create "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [Hq.showQuestGiver "ReachRepLevel2"]
                When.Objective.Done [
                    //Hq.showQuestGiver "ReachRepLevel2_done"

                    Hq.Objective.add "GetToTheEnd"
                ]
            ]
        }

        {
            ID = "GetToTheEnd"
            Goals = [
                Goal.Economy.HaveReputation 1200
            ]
            Rewards = [
                Reward.Money 25000
                Reward.Profession 1 "GetActor" "Medic" [
                    Hq.Actors.Create "Medic" [Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Medic" [
                    Hq.Actors.CreateOtherShift "Medic" [Actor.LevelUp ();Actor.LevelUp ()]
                ]

                Reward.Profession 1 "GetActor" "Police" [
                    Hq.Actors.Create "Police" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Police" [
                    Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ();Actor.LevelUp ()]
                ]

                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.Create "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [Hq.showQuestGiver "ReachRepLevel3"]
                When.Objective.Done [
                   // Hq.showQuestGiver "ReachRepLevel3_done"
                ]
            ]
        }     

    ]    

    Modifications = fun () ->
        Def.SmartObject.RemoveAllWithTags ["USAVehicle"]
        Def.SmartObject.Update "PersonalLocker_Fire" (fun x -> {x with Unlock = None})

        Def.SmartObject.Update "FireEngine_DLK18" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "Berlin_Firestation_Done"
                ]
            }
        })


        Def.SmartObject.Update "FireEngine_TLF3000" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "Berlin_Firestation_Done"
                ]
            }
        })

        Def.SmartObject.Update "WaterBuckets_01" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    
                ]
            }
        })

        Def.Emergency.Update "MafiaBossTrial" (fun x ->
        {x with
            Events = [
                When.Emergency.Success [
                    If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
                    Hq.Storage.Create "PaperWork" 15
                    Hq.Unlocks.Add "MafiaBossTrialDone"
                    // Hq.Objective.add "SetupMedicalStation_Win"
                    // Hq.showQuestGiver "SetupMedical_win"
                    // ForEach.Emergency.Vehicle [Vehicle.Damage 10.0]
                ]
                When.Emergency.Failure [
                    Hq.Unlocks.Add "MafiaBossTrialDone"
                    // Hq.Objective.add "SetupMedicalStation_Fail"
                    // Hq.showQuestGiver "SetupMedical_fail"
                    // ForEach.Emergency.Vehicle [Vehicle.Damage 10.0]
                ]

                When.Emergency.Expiration[
                    Hq.Unlocks.Add "MafiaBossTrialDone"
                    // Hq.Objective.add "SetupMedicalStation_Fail"
                    // Hq.showQuestGiver "SetupMedical_fail"
                ]
            ]
        })

        Def.Uniform.RemoveAllWithTags ["US"]
        
    EndlessMode = [
        {
            ID = "0"
            TimeLine = [
                TimeLine.Interval.Emergencies {
                    TimeSpan = gt 0 0 8., gt 0 6 0.
                    Interval = Gt.hours 4.0
                    Tags = ["Berlin"]
                    Patterns = [
                        {Weight = 1; Levels = [3;3;4;4]}
                        {Weight = 5; Levels = [3;3;3;4]}
                        {Weight = 5; Levels = [3;3;4]}
                        {Weight = 3; Levels = [3;3;5]}
                        {Weight = 1; Levels = [3;3;5]}
                    ]               
                }

                TimeLine.Wave (gt 0 1 1.0) (gt 0 2 12.0) (gt 0 5 20.0) "Civil_Movement" "w_Civil_Movement"
                TimeLine.At (gt 0 1 1.0) [Hq.showQuestGiver "Civil_Movement_Announced"]
                TimeLine.At (gt 0 2 10.0) [Hq.showQuestGiver "Civil_MovementToDo"]
                
                TimeLine.Interval.Emergencies {
                    TimeSpan = gt 0 2 12.0, gt 0 5 20.0
                    Interval = Gt.hours 4.0
                    Tags = ["Civil_Movement"]
                    Patterns = [
                        {Weight = 2; Levels = [2;3;4]}
                        {Weight = 3; Levels = [2;3;3]}
                        {Weight = 1; Levels = [3;4]}
                    ]               
                }
                TimeLine.At (gt 0 5 8.0) [Hq.showQuestGiver "Civil_Movement_AlmostDone"]

                TimeLine.Wave (gt 0 1 1.0) (gt 0 6 12.0) (gt 0 6 14.0) "Rioting_EcoTerrorism" "w_Rioting_EcoTerrorism"
                TimeLine.ForceEmergencyAt (gt 0 6 12.0) 99 99 ["Rioting_EcoTerrorism"]
                TimeLine.At (gt 0 6 8.0) [Hq.showQuestGiver "Rioting_EcoTerrorism_Impending"]
            ]
        }

        {
            ID = "1"
            TimeLine = [
                TimeLine.Interval.Emergencies {
                    TimeSpan = gt 0 0 8., gt 0 6 0.
                    Interval = Gt.hours 4.0
                    Tags = ["Berlin"]
                    Patterns = [
                        {Weight = 1; Levels = [3;3;4;4]}
                        {Weight = 5; Levels = [3;3;3;4]}
                        {Weight = 5; Levels = [3;3;4]}
                        {Weight = 3; Levels = [3;3;5]}
                        {Weight = 1; Levels = [3;3;5]}
                    ]               
                }

                TimeLine.Wave (gt 0 1 1.0) (gt 0 2 12.0) (gt 0 5 20.0) "SportsFestival" "w_SportsFestival"
                TimeLine.At (gt 0 1 1.0) [Hq.showQuestGiver "SportsFestival_Announced"]
                TimeLine.At (gt 0 2 10.0) [Hq.showQuestGiver "SportsFestivalToDo"]
                
                TimeLine.Interval.Emergencies {
                    TimeSpan = gt 0 2 12.0, gt 0 5 20.0
                    Interval = Gt.hours 4.0
                    Tags = ["SportsFestival"]
                    Patterns = [
                        {Weight = 2; Levels = [1;2;3]}
                        {Weight = 3; Levels = [1;2;2]}
                        {Weight = 1; Levels = [2;3]}
                    ]               
                }
                TimeLine.At (gt 0 5 8.0) [Hq.showQuestGiver "SportsFestival_AlmostDone"]

                TimeLine.Wave (gt 0 1 1.0) (gt 0 6 12.0) (gt 0 6 14.0) "TrainWreck" "w_TrainWreck"
                TimeLine.ForceEmergencyAt (gt 0 6 12.0) 99 99 ["TrainWreck_Endless"]
                TimeLine.At (gt 0 6 8.0) [Hq.showQuestGiver "TrainWreck_Impending"]
            ]
        }            

        {
            ID = "2"
            TimeLine = [
                TimeLine.Interval.Emergencies {
                    TimeSpan = gt 0 0 8., gt 0 6 0.
                    Interval = Gt.hours 4.0
                    Tags = ["Berlin"]
                    Patterns = [
                        {Weight = 1; Levels = [3;3;4;4]}
                        {Weight = 5; Levels = [3;3;3;4]}
                        {Weight = 5; Levels = [3;3;4]}
                        {Weight = 3; Levels = [3;3;5]}
                        {Weight = 1; Levels = [3;3;5]}
                    ]               
                }

                TimeLine.Wave (gt 0 1 1.0) (gt 0 2 12.0) (gt 0 5 20.0) "HeatWave" "w_HeatWave"
                TimeLine.At (gt 0 1 1.0) [Hq.showQuestGiver "HeatWave_Announced"]
                TimeLine.At (gt 0 2 10.0) [Hq.showQuestGiver "HeatWaveToDo"]
                
                TimeLine.Interval.Emergencies {
                    TimeSpan = gt 0 2 12.0, gt 0 5 20.0
                    Interval = Gt.hours 4.0
                    Tags = ["HeatWave"]
                    Patterns = [
                        {Weight = 2; Levels = [3;4]}
                        {Weight = 3; Levels = [2;3;3]}
                        {Weight = 1; Levels = [5]}
                    ]             
                }
                TimeLine.At (gt 0 5 8.0) [Hq.showQuestGiver "HeatWave_AlmostDone"]

                TimeLine.Wave (gt 0 1 1.0) (gt 0 6 12.0) (gt 0 6 14.0) "TrainWreck" "w_TrainWreck"
                TimeLine.ForceEmergencyAt (gt 0 6 12.0) 99 99 ["TrainWreck_Endless"]
                TimeLine.At (gt 0 6 8.0) [Hq.showQuestGiver "TrainWreck_Impending"]
            ]
        }

        {
            ID = "3"
            TimeLine = [
                TimeLine.Interval.Emergencies {
                    TimeSpan = gt 0 0 8., gt 0 6 0.
                    Interval = Gt.hours 4.0
                    Tags = ["Berlin"]
                    Patterns = [
                        {Weight = 1; Levels = [3;3;4;4]}
                        {Weight = 5; Levels = [3;3;3;4]}
                        {Weight = 5; Levels = [3;3;4]}
                        {Weight = 3; Levels = [3;3;5]}
                        {Weight = 2; Levels = [3;3;5]}
                    ]               
                }

                TimeLine.Wave (gt 0 1 1.0) (gt 0 2 12.0) (gt 0 5 20.0) "HeatWave" "w_HeatWave"
                TimeLine.At (gt 0 1 1.0) [Hq.showQuestGiver "HeatWave_Announced"]
                TimeLine.At (gt 0 2 10.0) [Hq.showQuestGiver "HeatWaveToDo"]
                
                TimeLine.Interval.Emergencies {
                    TimeSpan = gt 0 2 12.0, gt 0 5 20.0
                    Interval = Gt.hours 4.0
                    Tags = ["HeatWave"]
                    Patterns = [
                        {Weight = 2; Levels = [3;4]}
                        {Weight = 3; Levels = [2;3;3]}
                        {Weight = 1; Levels = [5]}
                    ]             
                }
                TimeLine.At (gt 0 5 8.0) [Hq.showQuestGiver "HeatWave_AlmostDone"]

                TimeLine.Wave (gt 0 1 1.0) (gt 0 6 12.0) (gt 0 6 14.0) "Rioting_EcoTerrorism" "w_Rioting_EcoTerrorism"
                TimeLine.ForceEmergencyAt (gt 0 6 12.0) 99 99 ["Rioting_EcoTerrorism"]
                TimeLine.At (gt 0 6 8.0) [Hq.showQuestGiver "Rioting_EcoTerrorism_Impending"]
            ]
        }

    ]
}