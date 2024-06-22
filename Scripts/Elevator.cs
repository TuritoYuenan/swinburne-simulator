using Godot;

namespace SwinburneSimulator;

public partial class Elevator : Area2D
{
	private Node _ui;
	private CanvasLayer _hud;

	public override void _Ready()
	{
		_ui = GD.Load<PackedScene>("res://Views/ElevatorUI.tscn").Instantiate();
		_hud = GetNode<CanvasLayer>("/root/FloorLevel/HUD");
		BodyEntered += ShowElevatorUI;
		BodyExited += HideElevatorUI;
	}

	private void ShowElevatorUI(Node2D body)
	{
		GD.Print(body.Name, " entered ", Name);
		_hud.Visible = false;
		GetTree().Root.AddChild(_ui);
	}

	private void HideElevatorUI(Node2D body)
	{
		GD.Print(body.Name, " exited ", Name);
		_hud.Visible = true;
		GetTree().Root.RemoveChild(_ui);
	}
}
