local DoorModule = require(game:GetService("ServerStorage"):WaitForChild("DoorModule"))
DoorModule.initDoorL(script.Parent) -- for single doors with hinge on the left
DoorModule.initDoorR(script.Parent) -- for single doors with hinge on the right
DoorModule.initDoubleDoor(script.Parent) -- for double doors
DoorModule.initLandingDoor(script.Parent) -- for elevator landing doors
DoorModule.initLabCabinetDoor(script.Parent) -- for lab cabinet doors
