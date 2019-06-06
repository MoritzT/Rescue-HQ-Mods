#load "Include.fsx"
open EMT.Modding  

// Function to update the Required Space of
// a SmartObject with the given ID
let UpdateRequiredRoom id room = 
    Def.SmartObject.Update id (fun x ->
    {x with
        Cells = [
            RequireSpace {
                Tags = [room]
                Block = [Rect (0,0) (2,1)]
                Free = []
            }
        ]
    })

// Setting the new room per SmartObject
// Use UpdateRequiredRoom string string
UpdateRequiredRoom "EquipmentMediKit" "Utility"
UpdateRequiredRoom "EquipmentContamSuit" "Utility"
UpdateRequiredRoom "EquipmentCrashCart" "Utility"
UpdateRequiredRoom "MedicineCabinet" "Utility"