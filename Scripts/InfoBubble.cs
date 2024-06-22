using Godot;

public partial class InfoBubble : CanvasLayer
{
	public override void _Ready()
	{
		GetNode<Label>("Panel/Margin/Label").Text = EditorDescription;
	}
}
