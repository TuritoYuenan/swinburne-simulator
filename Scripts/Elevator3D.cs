using Godot;

namespace SwinburneSimulator.Scripts;

public partial class Elevator3D : Area3D
{
	private Node _ui;
	private CanvasLayer _hud;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_ui = GD.Load<PackedScene>("res://Views/ElevatorUI.tscn").Instantiate();
		_hud = GetNode<CanvasLayer>("/root/Level/HUD");
		BodyEntered += ShowElevatorUI;
		BodyExited += HideElevatorUI;
	}

	private void ShowElevatorUI(Node3D body)
	{
		GD.Print(body.Name, " entered ", Name);
		_hud.Visible = false;
		GetTree().Root.AddChild(_ui);
	}

	private void HideElevatorUI(Node3D body)
	{
		GD.Print(body.Name, " exited ", Name);
		_hud.Visible = true;
		GetTree().Root.RemoveChild(_ui);
	}
}
