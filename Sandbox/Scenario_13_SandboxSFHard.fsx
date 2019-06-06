#load "Include.fsx"
open EMT.Modding

Def.Scenario.Add {
    ID = "SandboxSFHard"
    EnableTutorials = No

    ApplicantTimeout = Gt.days 1.0
    FireProtectionTime = Gt.weeks 1.0

    Level = "Berlin_Endless", ["CentralWing"]

    VehicleRepairRate = Gt.perHour 20.0

    EconomySystem = {
        InitialFunds = 80_000
        AwardedCityGrants = 2
        MoneyPerCityGrant = 90_000
    }
 
    ReputationSystem = {
        MoneyPerReputation = 100
        Ranks = [
            {MaxReputation = 600; CityHallPayments = 60_000}
            {MaxReputation = 1000; CityHallPayments = 70_000}
            {MaxReputation = 1_300; CityHallPayments = 90_000}
            {MaxReputation = 2_000; CityHallPayments = 110_000}
            {MaxReputation = 2_800; CityHallPayments = 130_000}
        ]
    }

    Events = [
        When.Init [
            // Quest handling
            // Marking all quests as finished
            Hq.Unlocks.Add "UnlockPolice"
            Hq.Unlocks.Add "MafiaBossTrialDone"
            Hq.Unlocks.Add "UnlockMedical"
            Hq.Unlocks.Add "SF_OfficeDone"
            Hq.Unlocks.Add "SF_PoliceStage1Done"
            Hq.Unlocks.Add "SF_PoliceStage2Done"
            Hq.Unlocks.Add "SF_PoliceStage3Done"
            Hq.Unlocks.Add "SF_PoliceStage4Done"
            Hq.Unlocks.Add "SFL_UnlockMD"
            Hq.Unlocks.Add "SFL_UnlockFD"
            Hq.Unlocks.Add "SF_PoliceDone"
            Hq.Unlocks.Add "SF_Medical_Stage1_Done"
            Hq.Unlocks.Add "UnlockAmbus"
            Hq.Unlocks.Add "SF_ExpandFirefighterDeptP1_Done"
            Hq.Unlocks.Add "SF_ExpandFirefighterDeptP2_Done"
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
        (*let w1 (hours) = gt 0 2 0. + Gt.hours hours
        let w2 (hours) = gt 0 5 0. + Gt.hours hours
        let w3 (hours) = gt 0 7 0. + Gt.hours hours*)

        
        [
        TimeLine.At (gt 4 7 0.0) [Hq.SetGameIsWon ()]

//Crime syndicate is on the rise. Emergencies are mainly sabotage attacks coupled with armed attacks

//Week 1 - small time gangsters 

        TimeLine.Wave (gt 0 0 8.0) (gt 0 0 22.0) (gt 0 4 0.0) "SmallTimeGangsters" "w_SmallTimeGangsters"
        TimeLine.At (gt 0 0 8.0) [Hq.showQuestGiver "SmallTimeGangsters_Announced"]
        TimeLine.At (gt 0 0 18.0) [Hq.showQuestGiver "SmallTimeGangsters_Impending"]
        TimeLine.At (gt 0 3 12.0) [Hq.showQuestGiver "SmallTimeGangsters_AlmostDone"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 0 22.0, gt 0 4 0.0
            Interval = Gt.hours 4.0
            Tags = ["SmallTimeGangsters"]
            Patterns = [
                {Weight = 2; Levels = [1;2;1]}
                {Weight = 3; Levels = [1;2;1]}
                {Weight = 1; Levels = [2;2;1]}
            ]            
        }
       
        TimeLine.Wave (gt 0 3 1.0) (gt 0 6 1.0) (gt 0 6 2.0) "SafehouseHit" "w_SafehouseHit"
        TimeLine.At (gt 0 5 18.0) [Hq.showQuestGiver "SafehouseHit_Impending"]
        TimeLine.At (gt 0 3 1.0) [Hq.Objective.add "SafehouseHitToDo" ]
        TimeLine.ForceEmergencyAt (gt 0 6 1.5) 99 99 ["SafehouseHit"]
        TimeLine.At (gt 0 6 5.1) [Hq.Unlocks.Add "SafehouseHitDone" ]

//Week 2 - armed attacks and holdouts (req medical) 
        TimeLine.Wave (gt 1 0 1.0) (gt 1 3 12.0) (gt 1 5 12.0) "ArmedAttacks" "w_ArmedAttacks"
        TimeLine.At (gt 1 0 1.0) [Hq.showQuestGiver "ArmedAttacks_Announced"]
        TimeLine.At (gt 1 3 1.0) [Hq.showQuestGiver "ArmedAttacks_Impending"]
        TimeLine.At (gt 1 4 12.0) [Hq.showQuestGiver "ArmedAttacks_AlmostDone"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 1 0 12.0, gt 1 4 20.0
            Interval = Gt.hours 4.0
            Tags = ["ArmedAttacks"]
            Patterns = [
                {Weight = 2; Levels = [1;2;3]}
                {Weight = 3; Levels = [1;2;2]}
                {Weight = 1; Levels = [2;3;2]}
            ]            
        }

        TimeLine.Wave (gt 1 2 1.0) (gt 1 6 2.0) (gt 1 6 3.0) "KidnapKingpin" "w_KidnapKingpin"
        TimeLine.At (gt 1 5 18.0) [Hq.showQuestGiver "KidnapKingpin_Impending"]
        TimeLine.At (gt 1 2 1.0) [Hq.Objective.add "KidnapKingpinToDo" ]
        TimeLine.ForceEmergencyAt (gt 1 6 2.5) 99 99 ["KidnapKingpin"]
        TimeLine.At (gt 1 6 6.1) [Hq.Unlocks.Add "KidnapKingpinDone" ]

//Week 3 - intensified attacks (bombs) (requires firefighting)
        TimeLine.Wave (gt 2 0 1.0) (gt 2 3 12.0) (gt 2 5 22.0) "TerrorAttacks" "w_TerrorAttacks"
        TimeLine.At (gt 2 0 1.0) [Hq.showQuestGiver "TerrorAttacks_Announced"]
        TimeLine.At (gt 2 2 22.0) [Hq.showQuestGiver "TerrorAttacks_Impending"]
        TimeLine.At (gt 2 5 12.0) [Hq.showQuestGiver "TerrorAttacks_AlmostDone"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 2 3 12.0, gt 2 5 20.0
            Interval = Gt.hours 4.0
            Tags = ["TerrorAttacks"]
            Patterns = [
                {Weight = 2; Levels = [1;2;3]}
                {Weight = 3; Levels = [1;2;2;2]}
                {Weight = 1; Levels = [2;3;2]}
            ]            
        }

        TimeLine.Wave (gt 2 1 1.0) (gt 2 6 8.0) (gt 2 6 10.0) "HitWarehouse" "w_HitWarehouse"
        TimeLine.At (gt 2 5 22.0) [Hq.showQuestGiver "HitWarehouse_Impending"]
        TimeLine.At (gt 2 1 1.0) [Hq.Objective.add "HitWarehouseToDo" ]
        TimeLine.ForceEmergencyAt (gt 2 6 9.0) 99 99 ["HitWarehouse"]
        TimeLine.At (gt 2 6 18.1) [Hq.Unlocks.Add "HitWarehouseDone" ]

//Week 4 - police investigation (process prisoners, solve cases) + people take to the streets 
        TimeLine.Wave (gt 2 7 1.0) (gt 3 1 12.0) (gt 3 5 0.0) "MassHysteria" "w_MassHysteria"
        TimeLine.At (gt 2 7 1.0) [Hq.showQuestGiver "MassHysteria_Announced"]
        TimeLine.At (gt 3 1 0.0) [Hq.showQuestGiver "MassHysteria_Impending"]
        TimeLine.At (gt 3 4 8.0) [Hq.showQuestGiver "MassHysteria_AlmostDone"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 3 1 14.0, gt 3 5 0.0
            Interval = Gt.hours 4.0
            Tags = ["MassHysteria"]
            Patterns = [
                {Weight = 4; Levels = [2;2;3]}
                {Weight = 5; Levels = [1;2;3;2]}
                {Weight = 3; Levels = [4;3;3]}
                {Weight = 2; Levels = [2;3;3]}
                {Weight = 1; Levels = [4;4]}
            ]            
        }

        TimeLine.Wave (gt 3 2 1.0) (gt 3 5 8.0) (gt 3 5 9.0) "RestoreUtilities" "w_RestoreUtilities"
        TimeLine.At (gt 3 4 20.0) [Hq.showQuestGiver "RestoreUtilities_Impending"]
        TimeLine.At (gt 3 2 1.0) [Hq.Objective.add "RestoreUtilitiesToDo" ]
        TimeLine.ForceEmergencyAt (gt 3 5 8.5) 99 99 ["RestoreUtilities"]
        TimeLine.At (gt 3 5 12.1) [Hq.Unlocks.Add "RestoreUtilitiesDone" ]

//Week 5 /Ending - contain attacks (all three departments) + final showdown 
        TimeLine.Wave (gt 3 7 1.0) (gt 4 1 12.0) (gt 4 7 0.0) "UnderSiege" "w_UnderSiege"
        TimeLine.At (gt 3 7 1.0) [Hq.showQuestGiver "UnderSiege_Announced"]
        TimeLine.At (gt 4 1 0.0) [Hq.showQuestGiver "UnderSiege_Impending"]
        TimeLine.At (gt 4 3 8.0) [Hq.showQuestGiver "UnderSiege_Halfway"]
        TimeLine.At (gt 4 6 8.0) [Hq.showQuestGiver "UnderSiege_AlmostDone"]
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 4 1 12.0, gt 4 7 20.0
            Interval = Gt.hours 4.0
            Tags = ["UnderSiege"]
            Patterns = [
                {Weight = 2; Levels = [4;2;3]}
                {Weight = 3; Levels = [4;2;2]}
                {Weight = 1; Levels = [2;3;4]}
            ]            
        }

        TimeLine.Wave (gt 4 1 18.0) (gt 4 5 12.0) (gt 4 5 13.0) "Stronghold" "w_Stronghold"
        TimeLine.At (gt 4 4 12.0) [Hq.showQuestGiver "Stronghold_Impending"]
        TimeLine.At (gt 4 1 18.0) [Hq.Objective.add "StrongholdToDo" ]
        TimeLine.ForceEmergencyAt (gt 4 5 12.5) 99 99 ["Stronghold"]
        TimeLine.At (gt 4 5 17.1) [Hq.Unlocks.Add "StrongholdDone" ]

//////Regular waves 
/// 
/// 

//week 1 (0 0 0.  -> 0 7 0.)
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 0 0., gt 0 0 12.
            Interval = Gt.hours 6.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 4; Levels = [1;1]}
                {Weight = 1; Levels = [1;1;1]}
                {Weight = 2; Levels = [1]}
            ]            
        }  
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 0 12., gt 0 3 0.
            Interval = Gt.hours 6.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 4; Levels = [1;2]}
                {Weight = 1; Levels = [1;2;1]}
                {Weight = 2; Levels = [2]}
            ]            
        }  
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 3 0., gt 0 5 20.
            Interval = Gt.hours 6.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 2; Levels = [1;1]}
                {Weight = 5; Levels = [1;2]}
                {Weight = 5; Levels = [1;2;1]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 0 6 0., gt 1 0 0.
            Interval = Gt.hours 6.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 2; Levels = [1;1;2]}
                {Weight = 5; Levels = [2;2]}
                {Weight = 5; Levels = [1;2;1]}
            ]            
        }

 //week 2 (1 0 0. -> 1 7 0.)
 
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 1 0 0., gt 1 3 0.
            Interval = Gt.hours 4.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 1; Levels = [1;1;2]}
                {Weight = 2; Levels = [1;2;1]}
                {Weight = 2; Levels = [2;2]}
                {Weight = 3; Levels = [2;2;1]}
                {Weight = 3; Levels = [2;2;2]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 1 3 0., gt 1 5 20.
            Interval = Gt.hours 6.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 3; Levels = [1;2;1]}
                {Weight = 5; Levels = [2;2;2]}
                {Weight = 3; Levels = [2;2;1]}
            ]            
        }

//week 3 (2 0 0. -> 2 7 0.)
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 2 0 0., gt 2 3 0.
            Interval = Gt.hours 4.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 1; Levels = [1;1;2;2;3]}
                {Weight = 5; Levels = [2;2;2]}
                {Weight = 5; Levels = [2;3;1;1]}
                {Weight = 3; Levels = [2;3;2;1]}
                {Weight = 3; Levels = [2;2;3]}
                {Weight = 1; Levels = [3;3;2]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 2 6 18., gt 3 0 0.
            Interval = Gt.hours 8.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 1; Levels = [1;1;2;2;3]}
                {Weight = 5; Levels = [2;2;2]}
                {Weight = 5; Levels = [2;3;3]}
                {Weight = 3; Levels = [2;2;3]}
                {Weight = 1; Levels = [3;3;2;1]}
            ]            
        }

//week 4  (3 0 0. -> 3 7 0.)
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 3 0 0., gt 3 1 8.
            Interval = Gt.hours 4.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 1; Levels = [2;3;3;3;2]}
                {Weight = 5; Levels = [3;3;2;2;1]}
                {Weight = 5; Levels = [2;3;4;2]}
                {Weight = 3; Levels = [2;3;3;4]}
                {Weight = 1; Levels = [3;3;4;4]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 3 1 12., gt 3 1 8.
            Interval = Gt.hours 8.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 5; Levels = [2;3;4;2]}
                {Weight = 3; Levels = [2;3;3;3]}
                {Weight = 1; Levels = [3;4;5]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 3 5 12., gt 4 0 0.
            Interval = Gt.hours 6.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 1; Levels = [2;3;3;3;3]}
                {Weight = 5; Levels = [3;3;2;2;3]}
                {Weight = 5; Levels = [2;2;3;4]}
                {Weight = 3; Levels = [2;3;3;3]}
                {Weight = 1; Levels = [3;4;5]}
            ]            
        }

//week 5 (4 0 0.  -> 4 7 0.)
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 4 0 0., gt 4 1 0.
            Interval = Gt.hours 6.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 1; Levels = [3;3;3;4]}
                {Weight = 5; Levels = [3;3;4;4]}
                {Weight = 5; Levels = [3;3;5]}
                {Weight = 3; Levels = [3;4;5]}
                {Weight = 1; Levels = [4;4;5]}
            ]            
        }
        TimeLine.Interval.Emergencies {
            TimeSpan = gt 4 1 0., gt 4 4 0.
            Interval = Gt.hours 8.0
            Tags = ["USA"]
            Patterns = [
                {Weight = 3; Levels = [5;5;5]}
                {Weight = 5; Levels = [3;4;4;4]}
                {Weight = 1; Levels = [3;4;5;5]}
            ]            
        }
    ]

/// objectives 
    Objectives = [

/// Story Missions 
/// 
/// 
        {
            ID = "SafehouseHitToDo"
            Goals = [
                    Goal.HaveUnlocked "SafehouseHitDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "SafehouseHitToDo"]
                When.Objective.Done []
            ]
        }  
        {
            ID = "KidnapKingpinToDo"
            Goals = [
                    Goal.HaveUnlocked "KidnapKingpinDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "KidnapKingpinToDo"]
                When.Objective.Done []
            ]
        }
        {
            ID = "HitWarehouseToDo"
            Goals = [
                    Goal.HaveUnlocked "HitWarehouseDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "HitWarehouseToDo"]
                When.Objective.Done []
            ]
        }
        {
            ID = "RestoreUtilitiesToDo"
            Goals = [
                    Goal.HaveUnlocked "RestoreUtilitiesDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "RestoreUtilitiesToDo"]
                When.Objective.Done []
            ]
        }
        {
            ID = "Stronghold"
            Goals = [
                    Goal.HaveUnlocked "StrongholdDone"            
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "StrongholdToDo"]
                When.Objective.Done []
            ]
        }

/// Pacing objectives
/// 
        {
            ID = "SanFran_Limited_Setup_Police"
            Goals = [
                Goal.SmartObject.Build "MainEntrance" 1
                Goal.Room.Build "Office" 36
                Goal.Room.Build "Garage" 40
                Goal.Room.Build "Utility" 30
                Goal.SmartObject.Build "HiringDeskPolice" 1
                Goal.SmartObject.Build "PoliceDesk" 1
                Goal.SmartObject.Build "FileCabinet" 1
                Goal.SmartObject.Build "FileCabinetFiles"  1
            ]
            Rewards = [
                Reward.Money 10000
                Reward.Profession 4 "GetActor" "Police" [
                    Hq.Actors.Create "Police" [Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Police" [
                    Hq.Actors.Create "Police" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 4 "GetActor" "Police" [
                    Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "Police" [
                    Hq.Actors.CreateOtherShift "Police" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [
                    Hq.Unlocks.Add "SF_OfficeDone"
                    Hq.showQuestGiver "SanFran_Limited_Setup_Police_Hard"]
                When.Objective.Done [
                    Hq.Objective.add "SanFran_Limited_BuildUpPolice"
                    Hq.Unlocks.Add "SF_PoliceStage1Done"
                ]
            ]
        }
        {
            ID = "SanFran_Limited_BuildUpPolice"
            Goals = [
                Goal.SmartObject.Build "PoliceCar_Cruiser" 2
                Goal.SmartObject.Build "PersonalLocker_Police" 10
                Goal.SmartObject.Build "US_PoliceArmory" 2
                
            ]
            Rewards = [
                Reward.Money 25000
            ]
            Events = [
                When.Init [Hq.showQuestGiver "SanFran_Limited_BuildUpPolice"]
                When.Objective.Done [
                    Hq.Objective.add "SanFran_Limited_BuildCommonArea"
                    Hq.Unlocks.Add "SF_PoliceStage2Done"
                ]
            ]
        }
        {
            ID = "SanFran_Limited_BuildCommonArea"
            Goals = [
                Goal.SmartObject.Build "Toilet_01" 1
                Goal.SmartObject.Build "Shower" 1
                Goal.SmartObject.Build "BathroomSink" 1
                Goal.SmartObject.Build "Fridge" 1
                Goal.SmartObject.Build "Bed" 1     
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "SanFran_Limited_BuildCommonArea"]
                When.Objective.Done [
                    Hq.Objective.add "SanFran_Limited_TrainingAreaSetup"
                    Hq.Unlocks.Add "SF_PoliceStage3Done"
                ]
            ]
        }  
        {
            ID = "SanFran_Limited_TrainingAreaSetup"
            Goals = [
                Goal.SmartObject.Build "WoodenDoor_01" 1
                Goal.SmartObject.Build "Benchpress" 1
                Goal.Economy.HaveReputation 200 
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "SanFran_Limited_TrainingAreaSetup"]
                When.Objective.Done [
                    Hq.Objective.add "SanFran_Limited_SetupPrison"
                    Hq.Unlocks.Add "SF_PoliceStage4Done"
                ]
            ]
        }  
        {
            ID = "SanFran_Limited_SetupPrison"
            Goals = [
                Goal.Room.Build "PrisonCell" 10
                Goal.SmartObject.Build "CellBench" 1  
                Goal.SmartObject.Build "PrisonCellDoor" 1
            ]
            Rewards = []
            Events = [
                When.Init [Hq.showQuestGiver "SanFran_Limited_SetupPrison"]
                When.Objective.Done [
                    Hq.Objective.add "SanFran_Limited_ExpandMedical"
                    Hq.Objective.add "SanFran_Limited_ExpandFireDept"
                    Hq.Unlocks.Add "SFL_UnlockMD"
                    Hq.Unlocks.Add "SFL_UnlockFD"
                    Hq.Unlocks.Add "SF_PoliceDone"
                ]
            ]
        } 
        {
            ID = "SanFran_Limited_ExpandMedical"
            Goals = [
                Goal.SmartObject.Build "PersonalLocker_Medical" 6
                
                Goal.SmartObject.Build "RoomTriageStation" 1
                Goal.SmartObject.Build "MedicineLab" 1
                Goal.SmartObject.Build "MedicineCabinet" 1
                Goal.SmartObject.Build "RoomBurnTreatment" 1
                Goal.SmartObject.Build "HiringDeskMedic" 1
            ]
            Rewards = [
                Reward.Money 25000
                Reward.Profession 3 "GetActor" "Medic" [
                    Hq.Actors.Create "Medic" []
                ]
                Reward.Profession 3 "GetActor" "Medic" [
                    Hq.Actors.CreateOtherShift "Medic" []
                ]
            ]
            Events = [
                When.Init [
                    Hq.showQuestGiver "SanFran_Limited_ExpandMedical" //used to launch the fire dept too
                ]
                When.Objective.Done [
                    Hq.Objective.add "SanFran_Limited_HireMedical"
                    Hq.Unlocks.Add "SF_Medical_Stage1_Done"
                ]
            ]
        } 
        {
            ID = "SanFran_Limited_HireMedical"
            Goals = [
                Goal.SmartObject.Build "Ambulance_Standard" 1
                Goal.Profession.CrewLimitAtLeast "Medic" 12
                Goal.Profession.Hire "Medic" 12
            ]
            Rewards = [
                Reward.Money 10000
                Reward.Profession 1 "GetActor" "Medic" [
                    Hq.Actors.Create "Medic" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [
                    Hq.showQuestGiver "SanFran_Limited_HireMedical"
                ]
                When.Objective.Done [
                    Hq.Unlocks.Add "UnlockAmbus"
                ]
            ]
        } 
        {
            ID = "SanFran_Limited_ExpandFireDept"
            Goals = [
                Goal.SmartObject.Build "PersonalLocker_Fire" 8
                
                Goal.SmartObject.Build "HiringDeskFirefighter" 1
                Goal.SmartObject.Build "GasBottleRefiller" 1
                Goal.SmartObject.Build "BreathingApparatusStorage" 1     
            ]
            Rewards = [
                Reward.Money 15000
                Reward.Profession 4 "GetActor" "FireFighter" [
                    Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.Create "FireFighter" [Actor.LevelUp ();Actor.LevelUp ();Actor.LevelUp ()]
                ]
                Reward.Profession 4 "GetActor" "FireFighter" [
                    Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
                ]
                Reward.Profession 1 "GetActor" "FireFighter" [
                    Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ();Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [
                   // Hq.showQuestGiver "SanFran_Limited_ExpandFireDept"
                ]
                When.Objective.Done [
                    Hq.Objective.add "SanFran_Limited_HireFirefighter"
                    Hq.Unlocks.Add "SF_ExpandFirefighterDeptP1_Done"
                ]
            ]
        } 
        {
            ID = "SanFran_Limited_HireFirefighter"
            Goals = [
                Goal.SmartObject.Build "FireTruck_US" 1
                Goal.Profession.CrewLimitAtLeast "FireFighter" 25
                Goal.Profession.Hire "FireFighter" 5
                Goal.SmartObject.Build "WaterBuckets_01" 2
                  
            ]
            Rewards = [
                Reward.Profession 5 "GetActor" "FireFighter" [
                    Hq.Actors.Create "FireFighter" [Actor.LevelUp ()]
                ]
                Reward.Profession 5 "GetActor" "FireFighter" [
                    Hq.Actors.CreateOtherShift "FireFighter" [Actor.LevelUp ()]
                ]
            ]
            Events = [
                When.Init [
                    Hq.showQuestGiver "SanFran_Limited_HireFirefighter"
                ]
                When.Objective.Done [
                    Hq.Unlocks.Add "SF_ExpandFirefighterDeptP2_Done"
                ]
            ]
        } 
    ]    

    Modifications = fun () ->
        // Removing all EU vehicles and uniforms
        Def.SmartObject.RemoveAllWithTags ["EuropeVehicle"]
        Def.Uniform.RemoveAllWithTags ["EU"]
//////////////////////
/// 
/// 
/// 
/// COMMON OBJECTS
/// 
/// 
        Def.SmartObject.Update "Shower" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage2Done"
                ]
            }
        })
        Def.SmartObject.Update "Toilet_01" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage2Done"
                ]
            }
        })
        Def.SmartObject.Update "BathroomSink" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage2Done"
                ]
            }
        })
        Def.SmartObject.Update "Bed" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage2Done"
                ]
            }
        })
        Def.SmartObject.Update "Fridge" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage2Done"
                ]
            }
        })
        Def.SmartObject.Update "Benchpress" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 100
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })    


        //Advanced common objects
        Def.SmartObject.Update "SofaChair" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 200
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })  
        Def.SmartObject.Update "Sofa3" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })  
        Def.SmartObject.Update "Sofa2" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 300
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })  
        Def.SmartObject.Update "DiningTable" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 250
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })  
        Def.SmartObject.Update "KitchenSmall" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 800
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })  
        Def.SmartObject.Update "Chair" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 50
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })  
        Def.SmartObject.Update "BunkBed" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 250
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })  




        /// MEDICAL DEPARTMENT
        Def.SmartObject.Update "RoomTriageStation" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockMD"
                ]
            }
        })
        Def.SmartObject.Update "RoomBurnTreatment" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockMD"
                    Goal.SmartObject.Build "MedicineCabinet" 1
                ]
            }
        })
        Def.SmartObject.Update "RoomIntensiveCare" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                    Goal.SmartObject.Build "MedicineCabinet" 1
                ]
            }
        })
        Def.SmartObject.Update "RoomOrthopedy" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                    Goal.SmartObject.Build "RoomRadiology_New" 1
                    Goal.SmartObject.Build "CastMachine" 1
                ]
            }
        })
        Def.SmartObject.Update "RoomRadiology_New" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 200
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                ]
            }
        })
        Def.SmartObject.Update "RoomResuscitation" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                    Goal.SmartObject.Build "EquipmentCrashCart" 1
                ]
            }
        })
        Def.SmartObject.Update "RoomHeartAttackTreatment" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                    Goal.SmartObject.Build "MedicineCabinet" 1
                    Goal.SmartObject.Build "EquipmentCrashCart" 1
                    
                ]
            }
        })
        Def.SmartObject.Update "RoomTraumaTreatment" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                    Goal.SmartObject.Build "RoomRadiology_New" 1
                    Goal.SmartObject.Build "MedicineCabinet" 1
                ]
            }
        })
        Def.SmartObject.Update "EquipmentCrashCart" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                ]
            }
        })
        Def.SmartObject.Update "EquipmentMediKit" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                ]
            }
        })
        Def.SmartObject.Update "EquipmentContamSuit" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 900
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                ]
            }
        })
        Def.SmartObject.Update "CastMachine" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 200
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                ]
            }
        })
        Def.SmartObject.Update "MedicineCabinet" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockMD"
                    Goal.SmartObject.Build "MedicineLab" 1
                ]
            }
        })
        Def.SmartObject.Update "MedicineLab" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 300
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockMD"
                ]
            }
        })
        Def.SmartObject.Update "Ambulance_Standard" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockMD"
                ]
            }
        })
        Def.SmartObject.Update "Ambulance_Fast" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                ]
            }
        })
        Def.SmartObject.Update "Ambulance_AmBus" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1200
                Goals = [
                    Goal.HaveUnlocked "UnlockAmbus"
                ]
            }
        })
        Def.SmartObject.Update "MedicalHelicopter" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1300
                Goals = [
                    Goal.HaveUnlocked "UnlockAmbus"
                ]
            }
        })
        Def.SmartObject.Update "PersonalLocker_Medical" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockMD"
                ]
            }
        })
        Def.SmartObject.Update "HiringDeskMedic" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockMD"
                ]
            }
        })
        Def.SmartObject.Update "HiringDeskMedic_T2" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1000
                Goals = [
                    Goal.HaveUnlocked "SF_Medical_Stage1_Done"
                    
                ]
            }
        })
////////////////////////////////////////////////
        /// FIRE DEPARTMENT 
        /// 
        /// 
        /// 
        /// 
        Def.SmartObject.Update "PersonalLocker_Fire" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockFD"
                ]
            }
        })
        Def.SmartObject.Update "HiringDeskFirefighter" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockFD"
                ]
            }
        })
        Def.SmartObject.Update "HiringDeskFirefighter_T2" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1000
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "BreathingApparatusStorage" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockFD"
                ]
            }
        })
        Def.SmartObject.Update "GasBottleRefiller" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SFL_UnlockFD"
                ]
            }
        })
        Def.SmartObject.Update "FoamExtinguisherStation" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 600
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "FoamExtinguisherStorage" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                    Goal.SmartObject.Build "FoamExtinguisherStation" 1
                ]
            }
        })
        Def.SmartObject.Update "HazmatSuitMaintenance" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 550
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "SubPumpMaintenance" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 550
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "BreachingGearMaintenance" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "WaterBuckets_01" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 200
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP1_Done"
                ]
            }
        })
        Def.SmartObject.Update "BurningBarrel_01" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 600
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "Ladder_01" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 800
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "Jerrycan_01" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 800
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "FireEngine_KDOW" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1200
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })
        Def.SmartObject.Update "FireEngine_US" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP1_Done"
                ]
            }
        })
        Def.SmartObject.Update "US_FireDept_TillerTruck" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP1_Done"
                ]
            }
        })

        Def.SmartObject.Update "FireFighterHelicopter" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1200
                Goals = [
                    Goal.HaveUnlocked "SF_ExpandFirefighterDeptP2_Done"
                ]
            }
        })

        /////////////////////
        /// 
        /// 
        /// 
        /// POLICE UNLOCKS
        /// 
        /// 
        Def.SmartObject.Update "HiringDeskPolice" (fun x -> 
        {x with 
            Unlock = None
        })
        Def.SmartObject.Update "HiringDeskPolice_T2" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1000
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "PrisonCellDoor" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage4Done"
                ]
            }
        })
        Def.SmartObject.Update "CellBench" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage4Done"
                    Goal.SmartObject.Build "PrisonCellDoor" 1
                ]
            }
        })
        Def.SmartObject.Update "FileCabinet" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_OfficeDone"
                    
                ]
            }
        })
        Def.SmartObject.Update "FileCabinetFiles" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_OfficeDone"
                    Goal.SmartObject.Build "PoliceDesk" 1
                ]
            }
        })
        Def.SmartObject.Update "FileCabinetCase" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                    Goal.SmartObject.Build "PoliceDetectiveDesk" 1
                ]
            }
        })
        Def.SmartObject.Update "EvidenceStorage" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 800
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                    
                ]
            }
        })
        Def.SmartObject.Update "PoliceDesk" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_OfficeDone"
                ]
            }
        })
        Def.SmartObject.Update "PoliceDetectiveDesk" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 400
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "PoliceInvestigationBoard" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1000
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "US_PoliceArmory" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage1Done"
                ]
            }
        })
        Def.SmartObject.Update "PersonalLocker_Police" (fun x -> 
        {x with 
            Unlock = None
        })
        Def.SmartObject.Update "BombDefusalWorkshop" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1000
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "RiotGearKit" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 600
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "SniperArmory" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 600
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "DroneWorkshop" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 900
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "DivingWorkshop" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1200
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "CrowdControlWorkshop" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 500
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "K9UnitWorkshop" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 550
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "WoodenDoor_01" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 0
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceStage3Done"
                ]
            }
        })
        Def.SmartObject.Update "ShootingRange" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 800
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "PoliceCar_Cruiser" (fun x -> 
        {x with 
            Unlock = None
        })
        Def.SmartObject.Update "PoliceCar_SportVehicle" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 600
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "PoliceCar_TransportVan" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 150
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "PoliceCar_RiotTruck" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 700
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "PoliceCar_Command" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1200
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })
        Def.SmartObject.Update "PoliceHelicopter" (fun x -> 
        {x with 
            Unlock = Some {
                RequiredReputation = 1300
                Goals = [
                    Goal.HaveUnlocked "SF_PoliceDone"
                ]
            }
        })

        
        
    EndlessMode = []
}
