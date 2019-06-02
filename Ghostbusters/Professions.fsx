#load "Include.fsx"
open EMT.Modding

// traits to remember the levels an actor ever reached. only added, never removed.
Def.TagTrait "ReachedLevel1"
Def.TagTrait "ReachedLevel2"
Def.TagTrait "ReachedLevel3"

Def.Profession.Add {
    ID = "GhostBuster"
    Type = Crew {
        EmergencyMoveSpeed = 1.33
        Limit = {
            Base = 0
            SmartObjects = [
                "PersonalLocker_GhostBuster", 2
            ]
        }
        Levels = [
            { // 0
                LevelUpXp = 10.0
                Wage = Gt.perDay 75.0, Gt.perDay 125.0
            }
            { // 1
                LevelUpXp = 200.0
                Wage = Gt.perDay 100.0, Gt.perDay 150.0
            }
            { // 2
                LevelUpXp = 800.0
                Wage = Gt.perDay 135.0, Gt.perDay 185.0
            }
            { // 3
                LevelUpXp = 0.0
                Wage = Gt.perDay 175.0, Gt.perDay 300.0
            }
        ]
    }
    MoveTime = Rt.seconds 0.4
    TurnTime = Rt.seconds 0.3
    IdleMoveSpeed = 0.7
    Events = [
        When.Init [
            Actor.Traits.Add "PersonalLocker"
            Actor.Traits.Add "Food"
            Actor.Traits.Add "Bladder"
            Actor.Traits.Add "Rest"
            Actor.Traits.Add "Relaxation"
            Actor.Traits.Add "Hygiene"
            Actor.Traits.Add "Exhaustion"
            Actor.Traits.Add "Mood"
            Actor.Traits.Add "Trait_rookie"
            
        ]
        When.Actor.ReachesLevel 1 [
            Actor.Traits.Remove "Trait_rookie"
            Actor.Traits.Add "ReachedLevel1"
            Actor.Traits.Add "FireFighterLvl1"
        ]
        When.Actor.ReachesLevel 2 [
            Actor.Traits.Add "ReachedLevel2"
            Actor.Traits.Remove "FireFighterLvl1"
            Actor.Traits.Add "FireFighterLvl2"
            If.Chance 0.7 [Actor.Traits.AddRandomWithTags ["FireFighter2"]]
            Actor.Notifications.Add "LevelUp2"
            Actor.Traits.Get "Mood" [Trait.AddValue 5.0]
        ]
        When.Actor.ReachesLevel 3 [
            Actor.Traits.Add "ReachedLevel3"
            Actor.Traits.Remove "FireFighterLvl2"
            Actor.Traits.Add "FireFighterLvl3"
            If.Chance 0.9 [Actor.Traits.AddRandomWithTags ["FirefighterVeteran"]]
            Actor.Notifications.Add "LevelUp3"
            Actor.Traits.Get "Mood" [Trait.AddValue 10.0]
        ]
    ]
}
