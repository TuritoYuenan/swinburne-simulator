using Godot;

namespace SwinburneSimulator;

public partial class Player3D : CharacterBody3D
{
	[ExportCategory("Player")]
	[Export(PropertyHint.Range, "1,35,1")] public float Speed { get; set; } = 10;
	[Export(PropertyHint.Range, "10,400,1")] public float Acceleration { get; set; } = 100;
	[Export(PropertyHint.Range, "0.1,3.0,0.1")] public float JumpHeight { get; set; } = 1;
	[Export(PropertyHint.Range, "0.1,3.0,0.1,or_greater")] public float CameraSensitivity { get; set; } = 1;

	private float _gravity = (float)ProjectSettings.GetSetting("physics/3d/default_gravity");
	private bool _jumping;
	private bool _mouseCaptured;

	private Camera3D _camera;

	private Vector2 _moveDir;
	private Vector2 _lookDir;

	private Vector3 _walkVel;
	private Vector3 _gravVel;
	private Vector3 _jumpVel;

	public override void _Ready()
	{
		_camera = GetNode<Camera3D>("Camera3D");
		CaptureMouse();
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion)
		{
			_lookDir = mouseMotion.Relative * new Vector2(0.001f, 0.001f);
			if (_mouseCaptured) RotateCamera();
		}

		_jumping = Input.IsActionJustPressed("jump");
		if (Input.IsKeyPressed(Key.Escape)) ReleaseMouse();
		if (Input.IsKeyPressed(Key.Enter)) CaptureMouse();
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_mouseCaptured) RotateCameraJoypad(delta);
		Velocity = Walk((float)delta) + Gravity((float)delta) + Jump((float)delta);
		MoveAndSlide();
	}

	private void CaptureMouse()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		_mouseCaptured = true;
	}

	private void ReleaseMouse()
	{
		Input.MouseMode = Input.MouseModeEnum.Visible;
		_mouseCaptured = false;
	}

	private void RotateCamera(float sensitivityMod = 1.0f)
	{
		float sensitivity = CameraSensitivity * sensitivityMod;

		_camera.RotateY(-_lookDir.X * sensitivity);
		_camera.RotateX((float)Mathf.Clamp(_camera.Rotation.X - _lookDir.Y * sensitivity, -1.5, 1.5));
	}

	private void RotateCameraJoypad(double delta, float sensitivityMod = 1.0f)
	{
		Vector2 joypadDir = Input.GetVector("look_left", "look_right", "look_up", "look_down");
		if (joypadDir.Length() > 0)
		{
			_lookDir += joypadDir * new Vector2((float)delta, (float)delta);
			RotateCamera(sensitivityMod);
			_lookDir = Vector2.Zero;
		}
	}

	private Vector3 Walk(float delta)
	{
		_moveDir = Input.GetVector("move_left", "move_right", "move_forward", "move_backward");
		Vector3 forward = _camera.GlobalTransform.Basis * new Vector3(_moveDir.X, 0, _moveDir.Y);
		_walkVel = _walkVel.MoveToward(
			new Vector3(forward.X, 0, forward.Z).Normalized() * Speed * _moveDir.Length(),
			Acceleration * delta
		);
		return _walkVel;
	}

	private Vector3 Gravity(float delta)
	{
		_gravVel = IsOnFloor() ? Vector3.Zero : _gravVel.MoveToward(
			new Vector3(0, Velocity.Y - _gravity, 0),
			_gravity * delta
		);
		return _gravVel;
	}

	private Vector3 Jump(float delta)
	{
		if (_jumping)
		{
			if (IsOnFloor()) _jumpVel = new(0, Mathf.Sqrt(4 * JumpHeight * _gravity), 0);
			_jumping = false;
			return _jumpVel;
		}
		_jumpVel = IsOnFloor() ? Vector3.Zero : _jumpVel.MoveToward(
			Vector3.Zero,
			_gravity * delta
		);
		return _jumpVel;
	}
}
