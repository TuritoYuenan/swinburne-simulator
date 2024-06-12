using Godot;

namespace SwinburneSimulator;

public partial class ButtonBack : Button
{
	public override void _Pressed()
	{
		var transition = GetTree().Root.GetNode<SceneTransition>("SceneTransition");
		transition.TransitionTo("res://Views/MainMenu.tscn");
	}
}
