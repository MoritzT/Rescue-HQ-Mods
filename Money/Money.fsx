#load "Include.fsx"
open EMT.Modding

for scenario in Def.Scenario |> Seq.toArray do
    Def.Scenario.Update scenario.ID (fun x -> 
        {x with 
            EconomySystem = {
                InitialFunds = 999_999_999
                AwardedCityGrants = 3
                MoneyPerCityGrant = 10_000
            }
        }
    )





