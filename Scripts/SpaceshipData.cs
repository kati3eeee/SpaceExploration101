using Godot;
using System;
using Godot.Collections;
using SpaceExploration101.Scripts;

[GlobalClass]
public partial class SpaceshipData : SpaceshipResourceBase
{
	[Export] 
	public Array<SpaceshipComponent> Components;
}
