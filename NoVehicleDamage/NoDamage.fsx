#load "Include.fsx"
open EMT.Modding  

let noDamage = 
    for smartObject in Def.SmartObject |> Seq.toArray do
        match smartObject.Type with
        // is it a vehicle?
        | Some (:? VehicleDef as v) ->
            // update defintion
            let test = smartObject.ToString() 
            Log.Info (test)
            // Log.Info ("SO ID:" + smartObject.ID.ToString )
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

Def.Scenario.Update "Berlin_Original" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            noDamage
    })

Def.Scenario.Update "Berlin_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            noDamage
    })

Def.Scenario.Update "SanFran_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            noDamage
    })

Def.Scenario.Update "SanFran_Hard" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            noDamage
    })
