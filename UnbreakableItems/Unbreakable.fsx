#load "Include.fsx"
open EMT.Modding

// Function to update the ProcessingTime of
// a SmartObject with the given ID and activate it automatically
let AutoRepair id = 
    Def.SmartObject.Update id (fun x ->
        {x with
            Type = SmartObjectType.Station
                {(x.Type.Value :?> StationObjectDef) with
                    ProcessingTime = Gt.hours 0.0
                    AutoActivate = Yes
                }
        })

for scenario in Def.Scenario |> Seq.toArray do
    Def.Scenario.Update scenario.ID (fun x -> 
        {x with 
            Modifications = fun () ->
                x.Modifications ()
                // Setting the new attributes per SmartObject
                // Use AutoRepair string
                AutoRepair "GasBottleRefiller"
                AutoRepair "FoamExtinguisherStation"
                AutoRepair "HazmatSuitMaintenance"
                AutoRepair "SubPumpMaintenance"
                AutoRepair "BreachingGearMaintenance"
                AutoRepair "PoliceArmory"
                AutoRepair "US_PoliceArmory"
                AutoRepair "BombDefusalWorkshop"
                AutoRepair "RiotGearKit"
                AutoRepair "SniperArmory"
                AutoRepair "DroneWorkshop"
                AutoRepair "DivingWorkshop"
                AutoRepair "CrowdControlWorkshop"
                AutoRepair "K9UnitWorkshop"
        })
