using Godot;

namespace SwinburneSimulator.Scripts;

public partial class LinkButton : Button
{
	[Export(PropertyHint.None)]
	public string URL = "";

	public override void _Pressed()
	{
		OS.ShellOpen(URL);
	}
}
