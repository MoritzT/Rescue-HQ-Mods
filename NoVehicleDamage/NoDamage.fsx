#load "Include.fsx"
open EMT.Modding  

for smartObject in Def.SmartObject |> Seq.toArray do
    match smartObject.Type with
    // is it a vehicle?
    | Some (:? VehicleDef as v) ->
        // update defintion
        Def.SmartObject.Update smartObject.ID (fun x ->
            {x with
                Type = SmartObjectType.Vehicle
                    {v with
                        // update maintenance of vehicle
                        Maintenance =
                            {v.Maintenance with
                                // nullify damage
                                DamageMultiplier = [Above 0, 0.0]
                                // never break down
                                BreakDownChance = [Above  0.0, 0.0]
                            }                                    
                    }
            })
    // no -> ignore
    | _ -> ()