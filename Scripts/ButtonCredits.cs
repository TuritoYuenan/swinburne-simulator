using Godot;

namespace SwinburneSimulator;

public partial class ButtonCredits : Button
{
	public override void _Pressed()
	{
		var transition = GetTree().Root.GetNode<SceneTransition>("SceneTransition");
		transition.TransitionTo("res://Views/Credits.tscn");
	}
}
