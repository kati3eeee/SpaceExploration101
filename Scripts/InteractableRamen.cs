using Godot;
using System;

public partial class InteractableRamen : Node2D
{
	[Export]
	public Sprite2D ramenSprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsMouseButtonPressed(MouseButton.Left))
		{
			GD.Print("Ramen!!!!");
			var mousePosition = GetGlobalMousePosition();
			if (ramenSprite.GetRect().HasPoint(mousePosition))
			{
				GD.Print("Ramen clicked!");
				QueueFree();
			}
		}
	}
}
