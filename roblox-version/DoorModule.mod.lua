local DoorModule = {}

function DoorModule.promptText(state: boolean)
	if state then return "Close Door" else return "Open Door" end
end

function DoorModule.toggleDoorR(hinge: HingeConstraint, isOpen: boolean)
	if isOpen then
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
end

function DoorModule.toggleDoorL(hinge: HingeConstraint, isOpen: boolean)
	if isOpen then
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
end

return DoorModule
