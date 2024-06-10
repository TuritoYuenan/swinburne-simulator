using Godot;

namespace SwinburneSimulator;

public partial class ButtonSettings : Button
{
	public override void _Pressed()
	{
		GetTree().ChangeSceneToFile("res://Views/Settings.tscn");
	}
}
