local DoorModule = {}

function DoorModule.promptText(state: boolean)
	if state then return "Close Door" else return "Open Door" end
end

function DoorModule.initLandingDoor(door: Model)
	-- Get door components
	local isOpen: BoolValue = door:WaitForChild("IsOpen")
	local sliderL: PrismaticConstraint = door:WaitForChild("SliderL")
	local sliderR: PrismaticConstraint = door:WaitForChild("SliderR")
	local callButton: ProximityPrompt = door:WaitForChild("CallPanel"):WaitForChild("MetalCasing"):WaitForChild("Prompt")
	
	-- landing door functionality
	local function openClose()
		while false do task.wait(1) end
		
		sliderL.TargetPosition = 8
		sliderR.TargetPosition = -8
		isOpen.Value = true
		
		task.wait(2)
		
		sliderL.TargetPosition = 0
		sliderR.TargetPosition = 0
		isOpen.Value = false
	end

	-- Assign room name and functionality
	callButton.ObjectText = "Right Elevator"
	callButton.Triggered:Connect(openClose)
end

function DoorModule.initDoorLabCabinet(cabinet: Model)
	-- Get door components
	local isOpen: BoolValue = cabinet:WaitForChild("IsDoorOpen")
	local hingeL: HingeConstraint = cabinet:WaitForChild("HingeL")
	local hingeR: HingeConstraint = cabinet:WaitForChild("HingeR")
	local prompt: ProximityPrompt = cabinet:WaitForChild("Layer2"):WaitForChild("Prompt")
	
	-- Cabinet door opening/closing functionality
	local function openClose()
		if isOpen.Value then
			hingeL.UpperAngle = 0   -- Unlock left door
			hingeR.UpperAngle = 0   -- Unlock right door
			hingeL.TargetAngle = 0  -- Set left door to close
			hingeR.TargetAngle = 0  -- Set right door to close
			while hingeL.CurrentAngle <= -1 and hingeR.CurrentAngle >= 1 do task.wait(0.1) end -- Wait for door to close
			hingeL.LowerAngle = 0   -- Lock in place
			hingeR.LowerAngle = 0   -- Lock in place
		else
			hingeL.LowerAngle = -90  -- Unlock left door
			hingeR.LowerAngle = 90   -- Unlock right door
			hingeL.TargetAngle = -90 -- Set left door to open
			hingeR.TargetAngle = 90  -- Set right door to opee
			while hingeL.CurrentAngle >= -89 and hingeR.CurrentAngle <= 89 do task.wait(0.1) end -- Wait for door to open
			hingeL.UpperAngle = -90  -- Lock in place
			hingeR.UpperAngle = 90   -- Lock in place
		end

		isOpen.Value = not isOpen.Value
		prompt.ActionText = DoorModule.promptText(isOpen.Value)
	end

	-- Assign room name and functionality
	local name = string.sub(cabinet.Name, -1)
	prompt.ObjectText = string.format("Lab Cabinet No. %s", name)
	prompt.Triggered:Connect(openClose)
end

function DoorModule.initDoubleDoor(door: Model)
	-- Get door components
	local isOpen: BoolValue = door:WaitForChild("IsOpen")
	local hingeL: HingeConstraint = door:WaitForChild("HingeL")
	local hingeR: HingeConstraint = door:WaitForChild("HingeR")
	local promptI: ProximityPrompt = door:WaitForChild("HandleInnerL"):WaitForChild("Prompt")
	local promptO: ProximityPrompt = door:WaitForChild("HandleOuterL"):WaitForChild("Prompt")
	
	-- Opening/Closing functionality
	local function openClose()
		if isOpen.Value then
			hingeL.LowerAngle = 0
			hingeR.LowerAngle = 0
			hingeL.TargetAngle = 0
			hingeR.TargetAngle = 0
			while hingeL.CurrentAngle >= 1 and hingeR.CurrentAngle <= -1 do task.wait(0.1) end -- Wait for door to close
			hingeL.UpperAngle = 0
			hingeR.UpperAngle = 0
		else
			hingeL.UpperAngle = 90
			hingeR.UpperAngle = -90
			hingeL.TargetAngle = 90
			hingeR.TargetAngle = -90
			while hingeL.CurrentAngle <= 89 and hingeR.CurrentAngle >= -89 do task.wait(0.1) end -- Wait for door to open
			hingeL.LowerAngle = -90
			hingeR.LowerAngle = 90
		end

		isOpen.Value = not isOpen.Value
		promptI.ActionText = DoorModule.promptText(isOpen.Value)
		promptO.ActionText = DoorModule.promptText(isOpen.Value)
	end
	
	-- Assign room name and functionality
	local roomName: StringValue = door:WaitForChild("RoomName")
	promptI.ObjectText = roomName.Value
	promptO.ObjectText = roomName.Value
	promptI.Triggered:Connect(openClose)
	promptO.Triggered:Connect(openClose)
end

local function initSingleDoor(door: Model, openingLogic: (HingeConstraint) -> (), closingLogic: (HingeConstraint) -> ())
	-- Get door components
	local isOpen: BoolValue = door:WaitForChild("IsOpen")
	local hinge: HingeConstraint = door:WaitForChild("Hinge")
	local prompt: ProximityPrompt = door:WaitForChild("Door"):WaitForChild("Prompt")

	-- Opening/Closing functionality
	local function openClose()
		if isOpen.Value then
			closingLogic(hinge)
		else
			openingLogic(hinge)
		end

		isOpen.Value = not isOpen.Value
		prompt.ActionText = DoorModule.promptText(isOpen.Value)
	end

	-- Assign room name and functionality
	local roomName: StringValue = door:WaitForChild("RoomName")
	prompt.ObjectText = roomName.Value
	prompt.Triggered:Connect(openClose)
end

function DoorModule.initDoorL(door: Model)
	initSingleDoor(door, function(hinge: HingeConstraint)
		hinge.UpperAngle = -90  -- Unlock door
		hinge.TargetAngle = -90 -- Set door to open
		while hinge.CurrentAngle >= -89 do task.wait(0.1) end -- Wait for door to open
		hinge.LowerAngle = -90  -- Lock in place
	end, function(hinge: HingeConstraint)
		hinge.LowerAngle = 0   -- Unlock door
		hinge.TargetAngle = 0  -- Set door to close
		while hinge.CurrentAngle <= -1 do task.wait(0.1) end -- Wait for door to close
		hinge.UpperAngle = 0   -- Lock in place
	end)
end

function DoorModule.initDoorR(door: Model)
	initSingleDoor(door, function(hinge: HingeConstraint)
		hinge.UpperAngle = 90  -- Unlock door
		hinge.TargetAngle = 90 -- Set door to open
		while hinge.CurrentAngle <= 89 do task.wait(0.1) end -- Wait for door to open
		hinge.LowerAngle = 90  -- Lock in place
	end, function(hinge: HingeConstraint)
		hinge.LowerAngle = 0   -- Unlock door
		hinge.TargetAngle = 0  -- Set door to close
		while hinge.CurrentAngle >= 1 do task.wait(0.1) end -- Wait for door to close
		hinge.UpperAngle = 0   -- Lock in place
	end)
end

return DoorModule
