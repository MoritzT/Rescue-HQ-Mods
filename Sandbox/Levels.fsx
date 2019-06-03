#load "Include.fsx"
open EMT.Modding

let scaleRegions (xSize) (ySize) (regions) =
    let div (a, b) (v) = a / v, b / v
    regions
    |> List.map (fun region ->
        {region with
            X = div region.X xSize
            Y = div region.Y ySize
        })

let posSize (min) (size) = min, min + size

let BerlinEmergencyRegions =
    scaleRegions 4096. 4096. [
        { // everything
            X = posSize 140. 3700.
            Y = posSize 260. 3690.
            RequiredTags = ["OnLand"]
        }
    ]

Def.Level.Add {
    ID = "SandboxBerlin"
    DefaultRoom = "Concrete"
    Lots = [
        {
            ID = "WholeMap"
            RunningCostPerCell = Gt.perDay 0.0
            PricePerCell = 0
            Unlock = []
            Region = [
                Rect (0,0) (60, 60)
            ]
        }
    ]
    
    Cells = [
        for x = 0 to 59 do yield Marker (x, -1, ZNeg) "Street"
        for x = 0 to 59 do yield Marker (x, 60, ZPos) "Street"
        for z = 0 to 59 do yield Marker (-1, z, XNeg) "Street"
        //for z = 0 to 59 do yield Marker (60, z, XPos) "Street"
    ]

    EmergencyRegions = BerlinEmergencyRegions
}


Def.Level.Add {
    ID = "SandboxBerlinLite"
    DefaultRoom = "Concrete"
    Lots = [
        {
            ID = "WholeMap"
            RunningCostPerCell = Gt.perDay 0.0
            PricePerCell = 0
            Unlock = []
            Region = [
                Rect (0,0) (60, 60)
            ]
        }
    ]
    
    Cells = [
        for x = 0 to 59 do yield Marker (x, -1, ZNeg) "Street"
        for x = 0 to 59 do yield Marker (x, 60, ZPos) "Street"
        for z = 0 to 59 do yield Marker (-1, z, XNeg) "Street"
        for z = 0 to 59 do yield Marker (60, z, XPos) "Street"
    ]
        
    EmergencyRegions = BerlinEmergencyRegions
}

let SanFranEmergencyRegions =
    scaleRegions 4096. 4096. [
        { // city bottom
            X = posSize 139. 3704.
            Y = posSize 2706. 1249.
            RequiredTags = ["OnLand"]
        }

        { // city middle right
            X = posSize 1195. 2648.
            Y = posSize 1771. 935.
            RequiredTags = ["OnLand"]
        }

        { // city upper left
            X = posSize 143. 994.
            Y = posSize 164. 402.
            RequiredTags = ["OnLand"]
        }

        { // water left
            X = posSize 118. 803.
            Y = posSize 1028. 1169.
            RequiredTags = ["OnWater"]
        }

        { // water right
            X = posSize 1460. 1807.
            Y = posSize 216. 1235.
            RequiredTags = ["OnWater"]
        }
    ]

Def.Level.Add {
    ID = "SandboxSF"
    DefaultRoom = "Concrete"
    Lots = [
        {
            ID = "WholeMap"
            RunningCostPerCell = Gt.perDay 0.0
            PricePerCell = 0
            Unlock = []
            Region = [
                Rect (0,0) (60, 60)
            ]
        }
    ]
    
    Cells = [
        for x = 0 to 59 do yield Marker (x, -1, ZNeg) "Street"
        //for x = 0 to 59 do yield Marker (x, 60, ZPos) "Street"
        for z = 0 to 59 do yield Marker (-1, z, XNeg) "Street"
        for z = 0 to 59 do yield Marker (60, z, XPos) "Street"
    ]
        
    EmergencyRegions = SanFranEmergencyRegions
}

Def.Level.Add {
    ID = "SandboxSFLite"
    DefaultRoom = "Concrete"
    Lots = [
        {
            ID = "WholeMap"
            RunningCostPerCell = Gt.perDay 0.0
            PricePerCell = 0
            Unlock = []
            Region = [
                Rect (0,0) (60, 60)
            ]
        }
    ]
    
    Cells = [
        for x = 0 to 59 do yield Marker (x, -1, ZNeg) "Street"
        for x = 0 to 59 do yield Marker (x, 60, ZPos) "Street"
        for z = 0 to 59 do yield Marker (-1, z, XNeg) "Street"
        for z = 0 to 59 do yield Marker (60, z, XPos) "Street"
    ]

    EmergencyRegions = SanFranEmergencyRegions
}
