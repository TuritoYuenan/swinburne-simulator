using Godot;

namespace SwinburneSimulator;

public partial class SceneTransition : CanvasLayer
{
	[Export(PropertyHint.File, "*.tscn")]
	public string NextScenePath = "";

	private AnimationPlayer _animPlayer;

	public override void _Ready()
	{
		_animPlayer = GetNode<AnimationPlayer>("Solid/AnimationPlayer");
		_animPlayer.PlayBackwards("Fade");
	}

	/// <summary>
	/// Transition to another scene
	/// </summary>
	public async void TransitionTo(string nextScene)
	{
		_animPlayer.Play("Fade");
		await ToSignal(_animPlayer, "animation_finished");

		if (NextScenePath != "") { GetTree().ChangeSceneToFile(NextScenePath); }
		else { GetTree().ChangeSceneToFile(nextScene); }

		_animPlayer.PlayBackwards("Fade");
		await ToSignal(_animPlayer, "animation_finished");
	}
}
