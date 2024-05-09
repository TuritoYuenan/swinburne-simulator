using Godot;
using System;
public partial class head : CharacterBody3D
{
	[Export]
	public float MouseSensitivity { get; private set; } = 0.001f;
	
	private Vector2 _mouseMotion = new Vector2();
	public override void _Ready()
	{
		base._Ready();
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}
	//Rotate Character view
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseEvent)
		{
			Rotation= new Vector3(Rotation.X, Rotation.Y - mouseEvent.Relative.X * MouseSensitivity, Rotation.Z - mouseEvent.Relative.Y * MouseSensitivity);
		}
	}
}
