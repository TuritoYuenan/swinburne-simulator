using Godot;

namespace SwinburneSimulator;

public partial class ButtonStart : Button
{
	public override void _Pressed()
	{
		var transition = GetTree().Root.GetNode<SceneTransition>("SceneTransition");
		transition.TransitionTo("res://Campus/Floor5.tscn");
	}
}
