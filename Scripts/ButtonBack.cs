using Godot;

namespace SwinburneSimulator;

public partial class ButtonBack : Button
{
	public override void _Pressed()
	{
		GetTree().ChangeSceneToFile("res://Views/MainMenu.tscn");
	}
}
