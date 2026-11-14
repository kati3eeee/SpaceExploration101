using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportCategory("Player Movement")]
	[Export]
	public float Acceleration = 500.0f;
	
	[Export] 
	public float MaxSpeed = 300.0f;
	
	[Export] 
	public float Friction = 0.99f;

	[ExportCategory("Nodes")] 
	[Export]
	public AnimatedSprite2D Sprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GetInputAndMove(delta);
	}

	public void GetInputAndMove(double delta)
	{
		var direction = Input.GetVector("left", "right", "up", "down");

		if (direction != Vector2.Zero)
		{
			Velocity += direction * Acceleration * (float)delta;
			Velocity = new Vector2(Mathf.Min(Velocity.X, MaxSpeed),  Mathf.Min(Velocity.Y, MaxSpeed));
			
			Sprite.Play("float");

			Sprite.FlipH = direction.X < 0;
		}
		else
		{
			Sprite.Play("idle");
		}

		Velocity *= Friction;

		MoveAndSlide();
	}
}
