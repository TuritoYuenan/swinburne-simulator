local DoorModule = {}

function DoorModule.promptText(state: boolean)
	if state then return "Close Door" else return "Open Door" end
end

function DoorModule.initDoorR(door: Model)
	-- Get door components
	local isOpen: BoolValue = door:WaitForChild("IsOpen")
	local hinge: HingeConstraint = door:WaitForChild("Hinge")
	local prompt: ProximityPrompt = door:WaitForChild("Door"):WaitForChild("Prompt")

	-- Assign door opening/closing functionality
	prompt.Triggered:Connect(function()
		if isOpen.Value then
			hinge.LowerAngle = 0   -- Unlock door
			hinge.TargetAngle = 0  -- Set door to close
			while hinge.CurrentAngle >= 1 do wait(0.1) end -- Wait for door to close
			hinge.UpperAngle = 0   -- Lock in place
		else
			hinge.UpperAngle = 90  -- Unlock door
			hinge.TargetAngle = 90 -- Set door to open
			while hinge.CurrentAngle <= 89 do wait(0.1) end -- Wait for door to open
			hinge.LowerAngle = 90  -- Lock in place
		end

		isOpen.Value = not isOpen.Value
		prompt.ActionText = DoorModule.promptText(isOpen.Value)
	end)

	-- Set prompt to show room name
	local roomName: StringValue = door:WaitForChild("RoomName")
	prompt.ObjectText = roomName.Value
end

function DoorModule.initDoorL(door: Model)
	-- Get door components
	local isOpen: BoolValue = door:WaitForChild("IsOpen")
	local hinge: HingeConstraint = door:WaitForChild("Hinge")
	local prompt: ProximityPrompt = door:WaitForChild("Door"):WaitForChild("Prompt")

	-- Assign door opening/closing functionality
	prompt.Triggered:Connect(function()
		if isOpen.Value then
			hinge.LowerAngle = 0   -- Unlock door
			hinge.TargetAngle = 0  -- Set door to close
			while hinge.CurrentAngle <= -1 do wait(0.1) end -- Wait for door to close
			hinge.UpperAngle = 0   -- Lock in place
		else
			hinge.UpperAngle = -90  -- Unlock door
			hinge.TargetAngle = -90 -- Set door to open
			while hinge.CurrentAngle >= -89 do wait(0.1) end -- Wait for door to open
			hinge.LowerAngle = -90  -- Lock in place
		end

		isOpen.Value = not isOpen.Value
		prompt.ActionText = DoorModule.promptText(isOpen.Value)
	end)

	-- Set prompt to show room name
	local roomName: StringValue = door:WaitForChild("RoomName")
	prompt.ObjectText = roomName.Value
end

return DoorModule
