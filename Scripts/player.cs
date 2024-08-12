using Godot;

namespace SwinburneSimulator;

public partial class Player : CharacterBody2D
{
	[Export(PropertyHint.Range, "0,600,10")]
	public int Speed { get; set; } = 400;

	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("move_left", "move_right", "move_forward", "move_backward");
		Velocity = inputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
