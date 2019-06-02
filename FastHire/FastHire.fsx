#load "Include.fsx"
open EMT.Modding

Def.Scenario.Update "Berlin_Original" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            // Faster Hiring
            let SetProcessingTime id time =
                Def.SmartObject.Update id (fun x ->
                    {x with
                        Type = SmartObjectType.Station
                            {(x.Type.Value :?> StationObjectDef) with
                                ProcessingTime = time
                            }
                    })

            SetProcessingTime "HiringDeskFirefighter" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskMedic" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskPolice" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskFirefighter_T2" (Gt.hours 1.0)
            SetProcessingTime "HiringDeskMedic_T2" (Gt.hours 1.0)
            SetProcessingTime "HiringDeskPolice_T2" (Gt.hours 1.0)
    })

Def.Scenario.Update "Berlin_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            // Faster Hiring
            let SetProcessingTime id time =
                Def.SmartObject.Update id (fun x ->
                    {x with
                        Type = SmartObjectType.Station
                            {(x.Type.Value :?> StationObjectDef) with
                                ProcessingTime = time
                            }
                    })

            SetProcessingTime "HiringDeskFirefighter" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskMedic" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskPolice" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskFirefighter_T2" (Gt.hours 1.0)
            SetProcessingTime "HiringDeskMedic_T2" (Gt.hours 1.0)
            SetProcessingTime "HiringDeskPolice_T2" (Gt.hours 1.0)
    })

Def.Scenario.Update "SanFran_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            // Faster Hiring
            let SetProcessingTime id time =
                Def.SmartObject.Update id (fun x ->
                    {x with
                        Type = SmartObjectType.Station
                            {(x.Type.Value :?> StationObjectDef) with
                                ProcessingTime = time
                            }
                    })

            SetProcessingTime "HiringDeskFirefighter" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskMedic" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskPolice" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskFirefighter_T2" (Gt.hours 1.0)
            SetProcessingTime "HiringDeskMedic_T2" (Gt.hours 1.0)
            SetProcessingTime "HiringDeskPolice_T2" (Gt.hours 1.0)
    })

Def.Scenario.Update "SanFran_Hard" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            // Faster Hiring
            let SetProcessingTime id time =
                Def.SmartObject.Update id (fun x ->
                    {x with
                        Type = SmartObjectType.Station
                            {(x.Type.Value :?> StationObjectDef) with
                                ProcessingTime = time
                            }
                    })

            SetProcessingTime "HiringDeskFirefighter" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskMedic" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskPolice" (Gt.hours 2.0)
            SetProcessingTime "HiringDeskFirefighter_T2" (Gt.hours 1.0)
            SetProcessingTime "HiringDeskMedic_T2" (Gt.hours 1.0)
            SetProcessingTime "HiringDeskPolice_T2" (Gt.hours 1.0)
    })
