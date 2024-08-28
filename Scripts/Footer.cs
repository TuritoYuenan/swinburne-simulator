using Godot;

namespace SwinburneSimulator.Scripts;

public partial class Footer : Container
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Label labelVersion = GetNode<Label>("Version");

		string version = (string)ProjectSettings.GetSetting("application/config/version");
		labelVersion.Text = $"Version: {version}";
	}
}
