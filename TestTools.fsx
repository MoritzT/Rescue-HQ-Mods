//IGNORE
#load "Include.fsx"
open EMT.Core
open EMT.Modding

// prepare a defintion to put stuff in
Definitions.Current <- new Definitions(10.0, new TickSpan(10L * 60L * 10L), 7)

let getEmergencyTotalPercentage (em:EmergencyDef) =
    em.AssetRequirements
    |> List.sumBy (fun (_, count, percentage) -> count * percentage)

let getAllEmergenciesNot100Percent () =
    getAllEmergencies ()
    |> Seq.where (fun em -> getEmergencyTotalPercentage em <> 100)

let showEmergency (em:EmergencyDef) =
    printfn "  %s:" em.ID

    em.AssetRequirements
    |> List.map (fun (asset, count, percentage) -> asset, count * percentage)
    |> List.iter (fun (a, p) -> printfn "    %3i%% %s" p a)

    em
    |> getEmergencyTotalPercentage
    |> printfn "    %3i%%"

    printfn ""
