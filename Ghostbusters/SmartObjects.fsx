#load "Include.fsx"
open EMT.Modding

// default costs
let NeedObjectBuildCost = 50
let NeedObjectMaintenance = Gt.perDay 100.0

let VanityObjectBuildCost = 5
let VanityObjectMaintenance = Gt.perDay 1.0

let StorageObjectBuildCost = 500
let StorageObjectMaintenance = Gt.perDay 5.0
let defautlTrainingTime = 30.0

let RequireStreetAndHideWall (x, y, dir:Direction) =
    RequireMarker (x + int dir.X, y + int dir.Y, dir) "Street"
    @ HideWall (x, y, dir)

Def.SmartObject.Add {
    ID = "PersonalLocker_GhostBuster"
    Special = No
    Tags = []
    Profession = "GhostBuster"
    Unlock = None
    BuildDuration = Rt.seconds 3.0
    BuildCost = 200
    SellingPrice = 0.5, Gt.weeks 1.0
    MaintenanceCost = Gt.perDay 0.0
    Type = None
    Cells = [
        RequireSpace {
            Tags = ["Utility"]
            Block = [Rect (0,0) (1,1)]
            Free = []
        }
        RequireWall (0, 0, ZPos)        
        Activity {
            Transform = 0, -1, ZPos
            ID = "use1"
            Enter = ZPos, Rt.seconds 1.375
            Exit = Rt.seconds 1.5
            Effects = []
            Tags = ["FireFighter"; "Locker"]
        }
        Activity {
            Transform = 0, -1, ZPos
            ID = "use2"
            Enter = ZPos, Rt.seconds 1.375
            Exit = Rt.seconds 1.5
            Effects = []
            Tags = ["FireFighter"; "Locker"]
        }
        
    ]    
}

Def.SmartObject.Add {
    ID = "HiringDeskGhostBuster"
    Special = No
    Tags = []
    Profession = "GhostBuster"
    Unlock = None
    BuildDuration = Rt.seconds 10.0
    BuildCost = 2000
    SellingPrice = 0.5, Gt.weeks 1.0
    MaintenanceCost = Gt.perDay 200.0
    Type = SmartObjectType.Station {
        ProcessingTime = Gt.hours 8.0 
        AutoActivate = Yes
        ActivatableCondition = Condition.Always
        UseCondition = Condition.Actor.LevelInRange (Above 1)
        InputSlots = []
        OutputSlots = []
        Activities = []
            ++ StationObjectActivity "trainer_browsing" (0, 1, ZNeg) (ZPos, Rt.seconds 1.0) (Rt.seconds 1.0)
        Events = [
            When.Station.CycleDone [
                Hq.Applicants.Create "GhostBuster" [
                    
                    If.Chance 0.2 [
                        Actor.LevelUp ()
                        If.Chance 0.02 [
                            Actor.LevelUp ()
                        ]
                    ]
                ]
            ]
        ]
    }
    Cells = [
        RequireSpace {
            Tags = ["Office"]
            Block = [
                Rect (0,0) (2,1)
                Rect (1,1) (2,1)
            ]
            Free = []
        }
    ]    
}







