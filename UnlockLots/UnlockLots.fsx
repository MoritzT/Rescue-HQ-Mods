#load "Include.fsx"
open EMT.Modding

Def.Scenario.Update "Berlin_Original" (fun x -> 
    {x with 
        Level = "Berlin_Original", [
            "CentralWing"
            "NorthWing"
            "SoutWing"
        ]
    })

Def.Scenario.Update "Berlin_Limited" (fun x -> 
    {x with 
        Level = "Berlin_Limited", [
            "BaseLot"
            "AdditionalLot1"
            "AdditionalLot2"
            "Connect_3"
            "Connect1_2"
        ]
    })

Def.Scenario.Update "SanFran_Limited" (fun x -> 
    {x with 
        Level = "SanFran_Limited", [
            "BaseLot"
            "AdditionalLot1"
            "AdditionalLot2"
        ]
    })

Def.Scenario.Update "SanFran_Hard" (fun x -> 
    {x with 
        Level = "SanFran_Hard", [
            "BaseLot"
            "LeftCompletion"
            "TopLot"
            "CentralLot"
        ]
    })
