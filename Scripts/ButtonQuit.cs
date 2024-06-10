using Godot;

namespace SwinburneSimulator;

public partial class ButtonQuit : Button
{
	public override void _Pressed()
	{
		GetTree().Quit();
	}
}
