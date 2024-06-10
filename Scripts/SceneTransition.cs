using Godot;

namespace SwinburneSimulator;

public partial class SceneTransition : ColorRect
{
	[Export(PropertyHint.File, "*.tscn")]
	public string NextScenePath = "";

	private AnimationPlayer _animPlayer;

	public override void _Ready()
	{
		_animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		_animPlayer.PlayBackwards("Fade");
	}

	public void TransitionTo(string nextScene)
	{
		_animPlayer.Play("Fade");

		if (NextScenePath != "") { GetTree().ChangeSceneToFile(NextScenePath); }
		else { GetTree().ChangeSceneToFile(nextScene); }
	}
}
