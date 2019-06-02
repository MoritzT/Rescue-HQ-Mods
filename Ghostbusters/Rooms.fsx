#load "Include.fsx"
open EMT.Modding

Def.Room.Add {
    ID = "CorridorGreen"
    Category = RoomCategory.General
    Unlock = None
    IsInside = Yes
    Tags = ["Corridor"; "MainEntrance";"NotPrison"]
    BuildCost = 10
    WalkSpeed = 1.5
}

Def.Room.Add {
    ID = "Concrete"
    Category = RoomCategory.ProfessionShared
    Unlock = None
    IsInside = No
    Tags = ["NotPrison"]
    BuildCost = 0
    WalkSpeed = 1.0
}

Def.Room.Add {
    ID = "Office"
    Category = RoomCategory.ProfessionShared
    Unlock = None
    IsInside = Yes
    Tags = ["Furniture"; "MainEntrance";"NotPrison"]
    BuildCost = 20
    WalkSpeed = 0.8
}

Def.Room.Add {
    ID = "Utility"
    Category = RoomCategory.ProfessionShared
    Unlock = None
    IsInside = Yes
    Tags = ["NotPrison"]
    BuildCost = 20
    WalkSpeed = 1.0
}

Def.Room.Add {
    ID = "Garage"
    Category = RoomCategory.ProfessionShared
    Unlock = None
    IsInside = Yes
    Tags = ["NotPrison"]
    BuildCost = 20
    WalkSpeed = 1.0
}

Def.Room.Add {
    ID = "Training"
    Category = RoomCategory.ProfessionShared
    Unlock = None
    IsInside = Yes
    Tags = ["NotPrison"]
    BuildCost = 20
    WalkSpeed = 1.0
}

Def.Room.Add {
    ID = "Bathroom"
    Category = RoomCategory.Needs
    Unlock = None
    IsInside = Yes
    Tags = ["NotPrison"]
    BuildCost = 25
    WalkSpeed = 1.0
}

Def.Room.Add {
    ID = "Kitchen"
    Category = RoomCategory.Needs
    Unlock = None
    IsInside = Yes
    Tags = ["Furniture";"NotPrison"]
    BuildCost = 30
    WalkSpeed = 1.0
}

Def.Room.Add {
    ID = "BedRoom"
    Category = RoomCategory.Needs
    Unlock = None
    IsInside = Yes
    Tags = ["Furniture";"NotPrison"]
    BuildCost = 30
    WalkSpeed = 0.75
}

Def.Room.Add {
    ID = "RelaxationArea"
    Category = RoomCategory.Needs
    Unlock = None
    IsInside = Yes
    Tags = ["Relaxation"; "MainEntrance";"NotPrison"]
    BuildCost = 20
    WalkSpeed = 0.75
}

Def.Room.Add {
    ID = "PrisonCell"
    Category = RoomCategory.ProfessionSingle
    Unlock = None
    IsInside = Yes
    Tags = []
    BuildCost = 20
    WalkSpeed = 1.0
}

Def.Room.Add {
    ID = "Medical"
    Category = RoomCategory.ProfessionSingle
    Unlock = None
    IsInside = Yes
    Tags = ["NotPrison"]
    BuildCost = 30
    WalkSpeed = 1.0
}
