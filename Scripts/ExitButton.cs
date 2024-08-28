using Godot;

namespace SwinburneSimulator.Scripts;

public partial class ExitButton : Button
{
	public override void _Pressed()
	{
		GetTree().Quit();
	}
}
