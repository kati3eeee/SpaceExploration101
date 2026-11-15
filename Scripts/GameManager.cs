using Godot;
using System;

namespace SpaceExploration101.Scripts;
public partial class GameManager : Node
{
	[Export]
	public Mission Mission;
	
	[Export]
	public ProgressBar ProgressBar;

	[Export] 
	public ProgressBar HungerBar;
	[Export] 
	public ProgressBar ThirstBar;

	//Important Object Instances
	public Ship Ship;
	public Player Player;

	public static GameManager Instance;

	public override void _Ready()
	{
		Instance = this;
		ProgressBar.MaxValue = Mission.DestinationDistance;
	}

	public override void _Process(double delta)
	{
		ProgressBar.Value = Ship.DistanceTraveled;
		HungerBar.Value = Player.Hunger;
		ThirstBar.Value = Player.Thirst;
		GD.Print(ProgressBar.Value);
	}
}
