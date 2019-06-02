#load "Include.fsx"
open EMT.Modding

Def.Scenario.Update "Berlin_Original" (fun x -> 
    {x with 
        EconomySystem = {
            InitialFunds = 999_999_999
            AwardedCityGrants = 3
            MoneyPerCityGrant = 10_000
        }
    })

Def.Scenario.Update "Berlin_Limited" (fun x -> 
    {x with 
        EconomySystem = {
            InitialFunds = 999_999_999
            AwardedCityGrants = 3
            MoneyPerCityGrant = 10_000
        }
    })

Def.Scenario.Update "SanFran_Limited" (fun x -> 
    {x with 
        EconomySystem = {
            InitialFunds = 999_999_999
            AwardedCityGrants = 3
            MoneyPerCityGrant = 10_000
        }
    })

Def.Scenario.Update "SanFran_Hard" (fun x -> 
    {x with 
        EconomySystem = {
            InitialFunds = 999_999_999
            AwardedCityGrants = 3
            MoneyPerCityGrant = 10_000
        }
    })
