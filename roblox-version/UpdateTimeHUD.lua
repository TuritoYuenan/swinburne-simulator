local Lighting = game:GetService("Lighting")
local timeHUD: TextLabel = script.Parent:WaitForChild("TimeHUD")

while true do
	timeHUD.Text = table.concat({"Current Time is ", string.sub(Lighting.TimeOfDay, 0, 5)})
	task.wait(1)
end
