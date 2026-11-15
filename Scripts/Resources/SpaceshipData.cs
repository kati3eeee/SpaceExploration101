using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using Godot.Collections;
using SpaceExploration101.Scripts;

[GlobalClass]
public partial class SpaceshipData(
	Array<SpaceshipComponent> components,
	SpaceshipData.OrbitType orbit
	) : SpaceshipResourceBase
{
	[Export] 
	public Array<SpaceshipComponent> Components { get; set; } = components;

	[Export] 
	public OrbitType Orbit { get; set; } = orbit;

	[Export] 
	[UIHint("Size of the ship as in rooms it has (calculated based on components and area mass of the ship defined in the building stage)")]
	public int Size = 1;

	public enum OrbitType
	{
		Default
	}

	public SpaceshipData() : this([], OrbitType.Default) { }
}
