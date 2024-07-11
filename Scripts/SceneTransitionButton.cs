using Godot;

namespace SwinburneSimulator;

public partial class SceneTransitionButton : Button
{
	[Export(PropertyHint.File, "*.tscn")]
	public string ScenePath = "";

	public override void _Pressed()
	{
		var transition = GetTree().Root.GetNode<SceneTransition>("SceneTransition");
		transition.TransitionTo(ScenePath);
	}
}
