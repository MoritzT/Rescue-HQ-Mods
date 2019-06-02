//IGNORE
#load "Include.fsx"
open EMT.Modding

module Type =
    let Police = "Type_Police"
    let Medical = "Type_Medical"
    let FireDept = "Type_FireDept"
    let MedicalFireDept = "Type_MedicalFireDept"
    let PoliceFireDept = "Type_PoliceFireDept"
    let PoliceMedical = "Type_PoliceMedical"
    let AllThree = "Type_AllThree"

//Traits
(*Urban
Industrial
Chemical
Biohazard
Shootout
Hostage
Critical
Pursuit
ForestFire
*)

let AddXp (amount) =
    ForEach.Actor [Actor.AddXp amount]

let AddExhaustion (amount) =
    ForEach.Actor [
        Actor.Traits.Add "Exhaustion"
        Actor.Traits.Get "Exhaustion" [Trait.AddValue -amount]
    ]

let AddInjury (chance) (exhaustedChance) (tags) =
    let tags = "Injury" :: tags
    ForEach.Actor [
        If.Actor.Traits.Contains "Exhausted" [
            If.Chance exhaustedChance [
                Actor.Traits.AddRandomWithTags tags
            ]
        ]
        |> Else [
            If.Chance chance [
                Actor.Traits.AddRandomWithTags tags
            ]
        ]
    ]

let SetMood (amount) =
    ForEach.Actor [
        Actor.Traits.Get "Mood" [Trait.AddValue amount]
    ]
