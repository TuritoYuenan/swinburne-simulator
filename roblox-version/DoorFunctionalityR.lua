local DoorModule = require(game:GetService("ServerStorage"):WaitForChild("DoorModule"))

-- False if door is closed
local isDoorOpen: boolean = false

-- Door hinge & Prompt
local door: Model = script.Parent
local doorHinge: HingeConstraint = door:WaitForChild("Hinge")
local doorPrompt: ProximityPrompt = door:WaitForChild("Door"):WaitForChild("Prompt")

-- Opening/Closing functionality
local function onInteraction()
	DoorModule.toggleDoorR(doorHinge, isDoorOpen)

	isDoorOpen = not isDoorOpen
	doorPrompt.ActionText = DoorModule.promptText(isDoorOpen)
end

-- Assign door functionality
doorPrompt.Triggered:Connect(onInteraction)
