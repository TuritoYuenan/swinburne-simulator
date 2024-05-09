using Godot;
using System;

public partial class player : CharacterBody3D
{    
	public float Speed { get; private set; } = 5.0f;
	public float MouseSensitivity { get; private set; } = 0.5f;
	private Vector2 _mouseMotion = new Vector2();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Handle Jump.
		//if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		//    velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();

		velocity.Y = 0;
		if (Mathf.IsZeroApprox(velocity.Length())) return;

		//var angle = 0;
		//var transform = _visual.Transform;
		//transform.Basis = new(Vector3.Up, angle);
		//_visual.Transform = transform;
		
	}
	//Rotate Character view
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseEvent)
		{
			Rotation= new Vector3(Rotation.X, Rotation.Y - mouseEvent.Relative.X * MouseSensitivity, Rotation.Z );
		}
	}
}
