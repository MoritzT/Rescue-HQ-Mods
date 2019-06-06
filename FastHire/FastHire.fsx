#load "Include.fsx"
open EMT.Modding

// Function to update the processing time of
// a SmartObject of Type "Station"
let SetProcessingTime id time =
    Def.SmartObject.Update id (fun x ->
        {x with
            Type = SmartObjectType.Station
                {(x.Type.Value :?> StationObjectDef) with
                    ProcessingTime = time
                }
        })

// Setting the new processing times per desk/station
// Use SetProcessingTime string time:EMT.Core.TickSpan
SetProcessingTime "HiringDeskFirefighter" (Gt.hours 2.0)
SetProcessingTime "HiringDeskMedic" (Gt.hours 2.0)
SetProcessingTime "HiringDeskPolice" (Gt.hours 2.0)
SetProcessingTime "HiringDeskFirefighter_T2" (Gt.hours 1.0)
SetProcessingTime "HiringDeskMedic_T2" (Gt.hours 1.0)
SetProcessingTime "HiringDeskPolice_T2" (Gt.hours 1.0)