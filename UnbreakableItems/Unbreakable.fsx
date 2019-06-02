#load "Include.fsx"
open EMT.Modding

let autoRepair = 
    for smartObject in Def.SmartObject |> Seq.toArray do
        match smartObject.Type with
        // is it a station?
        | Some (:? StationObjectDef as v) ->
            // update defintion
            if v.InputSlots.Length > 0 then 
                Def.SmartObject.Update smartObject.ID (fun x ->
                    {x with
                        Type = SmartObjectType.Station
                            {v with
                                    ProcessingTime = Gt.hours 0.0
                                    AutoActivate = Yes
                            }
                    })
        // no -> ignore
        | _ -> ()
        //smartObject.ActivatableCondition

Def.Scenario.Update "Berlin_Original" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            autoRepair
    })

Def.Scenario.Update "Berlin_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            autoRepair
    })

Def.Scenario.Update "SanFran_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            autoRepair
    })

Def.Scenario.Update "SanFran_Hard" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            autoRepair
    })
