using Godot;
using System;

public partial class player : CharacterBody3D
{    
	public float JumpVelocity { get; private set; } = 15.0f;
	public float Gravity { get; private set; } = -9.8f;
	public bool jumping = false;
	public float Speed { get; private set; } = 5.0f;
	public float MouseSensitivity { get; private set; } = 0.001f;
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
		
		if (Input.IsActionPressed("jump"))
		{
			if(velocity.Y < JumpVelocity)
			{
				jumping = true;
				velocity.Y = Mathf.MoveToward(JumpVelocity, 0, Speed);
			}
			else
			{
				jumping = false;
			}
		}
		if(!IsOnFloor()&&!jumping)
		{
			velocity.Y = Mathf.MoveToward(0, Gravity, Speed);
		}
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
		if (Mathf.IsZeroApprox(velocity.Length())) return;

		//var angle = 0;
		//var transform = _visual.Transform;
		//transform.Basis = new(Vector3.Up, angle);
		//_visual.Transform = transform;
		
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseEvent)
		{
			Godot.Node3D child= this.GetNode<Node3D>("Head");
			child.Rotation= new Vector3(child.Rotation.X, child.Rotation.Y, child.Rotation.Z - mouseEvent.Relative.Y * MouseSensitivity);
			this.Rotation= new Vector3(Rotation.X, Rotation.Y - mouseEvent.Relative.X * MouseSensitivity, Rotation.Z);
		}
	}
}
