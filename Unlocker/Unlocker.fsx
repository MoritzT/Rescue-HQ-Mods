#load "Include.fsx"
open EMT.Modding

let unlockAll = 
    for smartObject in Def.SmartObject |> Seq.toArray do
        Def.SmartObject.Update smartObject.ID (fun x -> {x with Unlock = None})

Def.Scenario.Update "Berlin_Original" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications ()
            unlockAll
    })

Def.Scenario.Update "Berlin_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications ()
            unlockAll
    })

Def.Scenario.Update "SanFran_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            Def.SmartObject.RemoveAllWithTags ["EuropeVehicle"]
            unlockAll
            Def.Uniform.RemoveAllWithTags ["EU"]
            // x.Modifications ()
    })

Def.Scenario.Update "SanFran_Hard" (fun x -> 
    {x with 
        Modifications = fun () ->
            Def.SmartObject.RemoveAllWithTags ["EuropeVehicle"]
            unlockAll
            Def.Uniform.RemoveAllWithTags ["EU"]
            // x.Modifications ()
    })
