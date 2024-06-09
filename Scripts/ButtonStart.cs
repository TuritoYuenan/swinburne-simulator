using Godot;

namespace SwinburneSimulator;

public partial class ButtonStart : Button
{
	public override void _Pressed()
	{
		GetTree().ChangeSceneToFile("res://Campus/Floor9.tscn");
	}
}
