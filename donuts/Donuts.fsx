#load "Include.fsx"
open EMT.Modding

Def.SmartObject.Add {
    ID = "DonutMachine"
    Special = No
    Tags = []
    Profession = "Police"
    Unlock = None
    BuildDuration = Rt.seconds 10.0
    BuildCost = 500
    SellingPrice = 0.5, Gt.weeks 1.0
    MaintenanceCost = Gt.perDay 100.0
    Type = None
    Cells = [
        RequireSpace {
            Tags = ["Kitchen"]
            Block = [Rect (0,0) (1,1)]
            Free = []
        }
        Activity {
            Transform = 0, -1, ZPos
            ID = "eating"
            Enter = ZPos, Rt.seconds 1.0
            Exit = Rt.seconds 1.0
            Effects = []
                ++ Condition.whileTraitBelow "Need_Donuts" 1.0
                ++ Effect.changeTrait "Need_Donuts" (Gt.perHour 1.5)
                ++ Effect.changeTrait "Food" (Gt.perHour 0.5)
                ++ Effect.changeTrait "Bladder" (Gt.perHour -0.5)
            Tags = ["Police";"IncreaseDonuts"]
        }
    ]    
}

Def.Trait.Add {
    ID = "Need_Donuts"
    Tags = ["Police"]
    Display = None
    Value = Gt.perHour -0.15, Between -1.0 1.6
    Events = [
        When.Init [
            Trait.SetRandomValue 1.4 1.6
        ]
        When.ShiftStart [
            Trait.SetRandomValue 0.9 1.2
        ]
        When.Actor.OverrideMode [
            If.Below 0.0 [
                Actor.DoActivity ["IncreaseDonuts"]
                |> Result.Failure [
                    Actor.ShowThoughtBubble "Need_Donuts" "Need_Donuts_Thought"
                    If.Below -0.7 [
                        Trait.SetValue 0.6
                        Tutorial.ShowCrewNeeds ()
                        Actor.Traits.Add "Need_Donuts_Failed"
                        Actor.Traits.Get "Mood" [Trait.AddValue -0.5]
                        Actor.LeaveHQ (Gt.hours 1.0)
                    ]
                ]
            ]
        ]
    ]
}

Def.Trait.Add {
    ID = "Need_Donuts_Failed"
    Tags = ["Temporary"]
    Display = Some {
        Type = TraitType.Temporary, 1
        Styles = []
        Emergency = None
    }
    Value = PerTick.Zero, Range.Zero
    Events = [
        When.EnterHq [Trait.Remove]
        When.ShiftEnd [Trait.Remove]
    ]
}

Def.Tracker.Add {
    ID = "Track_Need_Donuts_Failed"
    Function = Tracker.ActorsWithTraitCurrentShift ["Need_Donuts_Failed"]
}

Def.Profession.Update "Police" (fun x ->
    {x with 
        Events = [
        When.ShiftStart [
            Actor.Traits.Add "Need_Donuts"
        ]
        When.Init [
            Actor.Traits.Add "Need_Donuts"
        ]
    ]
    })