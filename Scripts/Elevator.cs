using Godot;

public partial class Elevator : Area2D
{
	private Node _ui = GD.Load<PackedScene>("res://Views/Elevator.tscn").Instantiate();

	public override void _Ready()
	{
		BodyEntered += ShowElevatorUI;
		BodyExited += HideElevatorUI;
	}

	public void ShowElevatorUI(Node2D body)
	{
		GD.Print(body.Name, " entered elevator");

		// Hide HUD
		GetTree().Root.GetNode<CanvasLayer>("HUD").Visible = false;

		// Show UI
		GetTree().Root.AddChild(_ui);
	}

	public void HideElevatorUI(Node2D body)
	{
		GD.Print(body.Name, " exited elevator");

		// Show HUD
		GetTree().Root.GetNode<CanvasLayer>("HUD").Visible = true;

		// Hide UI
		GetTree().Root.RemoveChild(_ui);
	}
}
