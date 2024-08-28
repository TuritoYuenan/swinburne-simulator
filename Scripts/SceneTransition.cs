using Godot;

namespace SwinburneSimulator.Scripts;

public partial class SceneTransition : CanvasLayer
{
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

		GetTree().ChangeSceneToFile(nextScene);

		_animPlayer.PlayBackwards("Fade");
		await ToSignal(_animPlayer, "animation_finished");
	}
}
