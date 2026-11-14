using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class PlayerCamera : Camera2D
{
	[ExportCategory("Main Camera Settings")]
	
	[Export] 
	[UIHint("What to target")] 
	public Node2D Target;
	
	[Export] 
	public bool SmoothingEnabled = true;
    
	[Export(PropertyHint.Range, "0,10,")] 
	[UIHint("How much the camera smooths (closer to 0 means it's closer to the player when smoothing while further from 0 will result in the camera being further from the player when smoothing)")] 
	public float SmoothingDistance = 2;

	private const float MaxSmoothingDelay = 11; // Max smoothing range + 1
	public override void _PhysicsProcess(double delta)
	{
		if (Target != null)
		{
			Vector2 cameraPosition;

			if (SmoothingEnabled)
			{
				float weight = (MaxSmoothingDelay - SmoothingDistance) / 100;
				cameraPosition = GlobalPosition.Lerp(Target.GlobalPosition, weight);
			}
			else
			{
				cameraPosition = Target.GlobalPosition;
			}
            
			GlobalPosition = cameraPosition;
		}
	}
}
