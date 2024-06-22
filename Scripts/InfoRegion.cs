using Godot;

namespace SwinburneSimulator;

public partial class InfoRegion : Area2D
{
	private Node _ui;

	public override void _Ready()
	{
		_ui = GD.Load<PackedScene>("res://Views/InfoBubble.tscn").Instantiate();
		_ui.EditorDescription = EditorDescription;
		BodyEntered += ShowInfoBubble;
		BodyExited += HideInfoBubble;
	}

	private void ShowInfoBubble(Node2D body)
	{
		GD.Print(body.Name, " entered ", Name);
		GetTree().Root.AddChild(_ui);
	}

	private void HideInfoBubble(Node2D body)
	{
		GD.Print(body.Name, " exited ", Name);
		GetTree().Root.RemoveChild(_ui);
	}
}
