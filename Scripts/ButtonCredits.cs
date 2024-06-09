using Godot;

namespace SwinburneSimulator;

public partial class ButtonCredits : Button
{
	public override void _Pressed()
	{
		GetTree().ChangeSceneToFile("res://Views/Credits.tscn");
	}
}
