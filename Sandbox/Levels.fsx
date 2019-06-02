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
    ID = "Berlin_Sandbox"
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

Def.Level.Add {
    ID = "SanFran_Sandbox"
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
