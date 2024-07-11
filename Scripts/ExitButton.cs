using Godot;

namespace SwinburneSimulator;

public partial class ExitButton : Button
{
	public override void _Pressed()
	{
		GetTree().Quit();
	}
}
