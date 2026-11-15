using Godot;
using System;
using SpaceExploration101.Scripts;

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

	public int Hunger = 100;
	public int Thirst = 100;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameManager.Instance.Player = this;
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
			
			Sprite.FlipH = direction.X < 0;
		}

		if ((Velocity.X < 5f && Velocity.X > -5f)
		    && (Velocity.Y < 5f && Velocity.Y > -5f)) // Velocity will never equal 0 after movement so just use these ranges to check if it's basically 0
		{
			if (IsOnFloor())
			{
				Sprite.Play("ground_idle");
			}
			else
			{
				Sprite.Play("float_idle");
			}
		}
		else
		{
			Sprite.Play("float");
		}

		Velocity *= Friction;

		MoveAndSlide();
	}

	public void On_Hunger_Timeout()
	{
		Hunger -= 1;
	}

	public void On_Thirst_Timeout()
	{
		Thirst -= 1;
	}
}
