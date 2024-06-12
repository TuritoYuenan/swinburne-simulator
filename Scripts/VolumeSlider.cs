using Godot;

public partial class VolumeSlider : HSlider
{
	[Export]
	public string AudioBusName = "Master";

	private int _bus;

	public override void _Ready()
	{
		_bus = AudioServer.GetBusIndex(AudioBusName);
		Value = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(_bus));
	}

	public override void _ValueChanged(double newValue)
	{
		AudioServer.SetBusVolumeDb(_bus, (float) Mathf.LinearToDb(Value));
	}
}
