using Godot;

namespace SwinburneSimulator;

public partial class ButtonGitHub : Button
{
	public override void _Pressed()
	{
		OS.ShellOpen("https://github.com/TuritoYuenan/swinburne-simulator");
	}
}
