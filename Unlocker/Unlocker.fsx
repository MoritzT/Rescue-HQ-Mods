#load "Include.fsx"
open EMT.Modding

for scenario in Def.Scenario |> Seq.toArray do
    Def.Scenario.Update scenario.ID (fun x -> 
        {x with 
            Modifications = fun () ->
                x.Modifications ()
                for smartObject in Def.SmartObject |> Seq.toArray do
                    Def.SmartObject.Update smartObject.ID (fun x -> {x with Unlock = None})
        })