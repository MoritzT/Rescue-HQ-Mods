#load "Include.fsx"
open EMT.Modding

for scenario in Def.Scenario |> Seq.toArray do
    Def.Scenario.Update scenario.ID (fun x -> 
        {x with 
            EconomySystem = {
                    InitialFunds = 100_000_000
                    AwardedCityGrants = 99
                    MoneyPerCityGrant = 1_000_000
            }
            ReputationSystem = {
                MoneyPerReputation = 1000
                Ranks = [
                    {MaxReputation = 60000; CityHallPayments = 80_000}

                ]
            }
            EndlessMode = x.EndlessMode @ [
                {
                    ID = "99"
                    TimeLine = [
                        TimeLine.At (gt 0 6 23.) [
                            Hq.Reputation.Income 60000
                            Hq.Money.Income 1000000 
                            ]
                    ]
                }
            ]
        }
    )





