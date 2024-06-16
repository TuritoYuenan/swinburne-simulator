using Godot;

namespace SwinburneSimulator;

public partial class ButtonElevator : Button
{
	/// <summary>Floor to go to. Default is floor 5</summary>
	[Export(PropertyHint.Range, "-2, 11")]
	public int FloorNumber = 5;

	public override void _Pressed()
	{
		var transition = GetTree().Root.GetNode<SceneTransition>("SceneTransition");
		var elevatorUI = GetTree().Root.GetNode<CanvasLayer>("ElevatorUI");

		string floorScene = string.Format("res://Campus/Floor{0}.tscn", FloorNumber.ToString());

		GD.Print("Going to Floor ", FloorNumber);
		GetTree().Root.RemoveChild(elevatorUI);
		transition.TransitionTo(floorScene);
	}
}
