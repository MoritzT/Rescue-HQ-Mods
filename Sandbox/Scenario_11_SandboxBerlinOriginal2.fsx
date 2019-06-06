#load "Include.fsx"
open EMT.Modding
 
Def.Scenario.Add {
    ID = "SandboxBerlinOriginal2"
    EnableTutorials = No

    ApplicantTimeout = Gt.days 1.0
    FireProtectionTime = Gt.weeks 1.0

    Level = "Berlin_Endless", ["CentralWing"]

    VehicleRepairRate = Gt.perHour 20.0

    EconomySystem = {
        InitialFunds = 100_000
        AwardedCityGrants = 2
        MoneyPerCityGrant = 150_000
    }

    ReputationSystem = {
        MoneyPerReputation = 100
        Ranks = [
            {MaxReputation = 600; CityHallPayments = 80_000}
            {MaxReputation = 1000; CityHallPayments = 100_000}
            {MaxReputation = 1_300; CityHallPayments = 120_000}
            {MaxReputation = 1_800; CityHallPayments = 180_000}
            {MaxReputation = 2_300; CityHallPayments = 220_000}
        ]
    }

    Events = [
        When.Init [
            // Quest handling
            // Marking all quests as finished
            Hq.Unlocks.Add "SFL_UnlockFD"
            Hq.Unlocks.Add "US_FireDept_Unlock"
            Hq.Unlocks.Add "Berlin_Firestation_Done"
            Hq.Unlocks.Add "UnlockPolice"
            Hq.Unlocks.Add "Berlin_PoliceStation_Done"
            Hq.Unlocks.Add "UnlockMedical"
            Hq.Unlocks.Add "SetupMedicalStation_Done"
            // Adding the objective to reach 800 reputation
            Hq.Objective.add "GetToTheEnd_1"

            // Adding some starting staff since we skip all quests
            //Day Shift
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.Create "Police" [Actor.LevelUp ();Actor.LevelUp ()]
            Hq.Actors.Create "Police" [Actor.LevelUp ()]
            Hq.Actors.Create "Police" [Actor.LevelUp ()]
            Hq.Actors.Create "Medic" [Actor.LevelUp ();Actor.LevelUp ()]
            Hq.Actors.Create "Medic" [Actor.LevelUp ()]
            Hq.Actors.Create "Medic" [Actor.LevelUp ()]
            // Night Shift
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ();Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "Medic" [Actor.LevelUp ();Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "Medic" [Actor.LevelUp ()]
            Hq.Actors.CreateOtherShift "Medic" [Actor.LevelUp ()]
        ]
        When.ShiftStart [
        ]
        When.ShiftEnd [
        ]
    ]

    TimeLine =
        [
        TimeLine.At (gt 4 7 0.0) [Hq.SetGameIsWon () ]

        TimeLine.Wave (gt 0 0 12.0) (gt 0 1 12.0) (gt 0 3 0.0) "Tutorial_1" "w_NationalHoliday01"
        TimeLine.At (gt 0 0 12.0) [Hq.showQuestGiver "NationalHoliday_Announced"]
        TimeLine.At (gt 0 1 8.0) [Hq.showQuestGiver "NationalHoliday_Impending"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 1 12.0, gt 0 3 0.0
            Interval = Gt.hours 5.0
            Tags = ["NationalHoliday"]
            Patterns = [
                {Weight = 4; Levels = [99]}
                {Weight = 1; Levels = [99;99;]}
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
                {Weight = 2; Levels = [2;2]}
                {Weight = 3; Levels = [1;2]}
                {Weight = 1; Levels = [3]}
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

        //BerlinEasy Intro missions
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 0 14., gt 0 2 6.
            Interval = Gt.hours 6.0
            Tags = ["Berlin";"Tier1"]
            Patterns = [
                {Weight = 1; Levels = [1]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 2 6., gt 0 3 0.
            Interval = Gt.hours 4.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 1; Levels = [1]}
            ]            
        }   
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 3 0., gt 0 4 20.
            Interval = Gt.hours 6.0
            Tags = ["Berlin"]
            Patterns = [
                {Weight = 2; Levels = [1;1]}
                {Weight = 5; Levels = [1;2]}
                {Weight = 5; Levels = [1;2;1]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 5 14., gt 1 2 6.
            Interval = Gt.hours 6.0
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
            Interval = Gt.hours 6.0
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
            Interval = Gt.hours 6.0
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
        {
            ID = "MafiaBossTrialToDo"
            Goals = [
                    Goal.HaveUnlocked "MafiaBossTrialDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "MafiaBossTrialToDo"]
                When.Objective.Done []
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
                When.Objective.Done []
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
                When.Objective.Done []
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
                When.Objective.Done []
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
                    Hq.Actors.Create "Police" [Actor.LevelUp ();Actor.LevelUp ()]  
                ]
            ]
        } 
        {
            ID = "GetToTheEnd_1"
            Goals = [
                Goal.Economy.HaveReputation 20
            ]
            Rewards = [Reward.Money 3500]
            Events = [
                When.Init []
                When.Objective.Done [
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
                Reward.Money 35000
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
                    Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ();Actor.LevelUp ()]
                ]

                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.Create "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [Hq.showQuestGiver "ReachRepLevel2"]
                When.Objective.Done [
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
                Reward.Money 35000
                Reward.Profession 1 "GetActor" "Medic" [
                    Hq.Actors.Create "Medic" [Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Medic" [
                    Hq.Actors.CreateOtherShift "Medic" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Police" [
                    Hq.Actors.Create "Police" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Police" [
                    Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.Create "FireFighter" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [Hq.showQuestGiver "ReachRepLevel3"]
                When.Objective.Done [
                ]
            ]
        }     
    ]    

    Modifications = fun () ->
        // Removing all US vehicles and uniforms
        Def.SmartObject.RemoveAllWithTags ["USAVehicle"]
        Def.Uniform.RemoveAllWithTags ["US"]

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

        
        
        Def.Emergency.Update "MafiaBossTrial" (fun x ->
        {x with
            Events = [
                When.Emergency.Success [
                    If.Chance 0.5 [Emergency.AddVisitor "Prisoner"]
                    Hq.Storage.Create "PaperWork" 15
                    Hq.Unlocks.Add "MafiaBossTrialDone"
                ]
                When.Emergency.Failure [
                    Hq.Unlocks.Add "MafiaBossTrialDone"
                ]
                When.Emergency.Expiration[
                    Hq.Unlocks.Add "MafiaBossTrialDone"
                ]
            ]
        })
        
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