using Godot;

namespace SwinburneSimulator;

public partial class ButtonSettings : Button
{
	public override void _Pressed()
	{
		var transition = GetTree().Root.GetNode<SceneTransition>("SceneTransition");
		transition.TransitionTo("res://Views/Settings.tscn");
	}
}
