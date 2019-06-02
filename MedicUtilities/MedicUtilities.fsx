#load "Include.fsx"
open EMT.Modding  

Def.Scenario.Update "Berlin_Original" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            Def.SmartObject.Update "EquipmentMediKit" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (2,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "EquipmentContamSuit" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (-1,0) (3,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "EquipmentCrashCart" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (1,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "MedicineCabinet" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (1,1)]
                        Free = []
                    }
                    RequireWall (0, 0, ZPos)
                ]
            })
    })

Def.Scenario.Update "Berlin_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications ()
            Def.SmartObject.Update "EquipmentMediKit" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (2,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "EquipmentContamSuit" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (-1,0) (3,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "EquipmentCrashCart" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (1,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "MedicineCabinet" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (1,1)]
                        Free = []
                    }
                ]
            })
            
    })

Def.Scenario.Update "SanFran_Limited" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            Def.SmartObject.Update "EquipmentMediKit" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (2,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "EquipmentContamSuit" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (-1,0) (3,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "EquipmentCrashCart" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (1,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "MedicineCabinet" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (1,1)]
                        Free = []
                    }
                ]
            })
            
    })

Def.Scenario.Update "SanFran_Hard" (fun x -> 
    {x with 
        Modifications = fun () ->
            x.Modifications () 
            Def.SmartObject.Update "EquipmentMediKit" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (2,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "EquipmentContamSuit" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (-1,0) (3,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "EquipmentCrashCart" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (1,1)]
                        Free = []
                    }
                ]
            })
            Def.SmartObject.Update "MedicineCabinet" (fun x -> 
            {x with
                Cells = [
                    RequireSpace {
                        Tags = ["Utility"]
                        Block = [Rect (0,0) (1,1)]
                        Free = []
                    }
                ]
            })
           
    })
