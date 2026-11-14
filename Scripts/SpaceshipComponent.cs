using Godot;

namespace SpaceExploration101.Scripts;

[GlobalClass]
public partial class SpaceshipComponent : SpaceshipResourceBase
{
    [Export]
    public string Name { get; set; }
    
    [Export]
    public float PowerConsumption { get; set; }
    
    [Export]
    public float Cost { get; set; }
    
    [Export]
    public PackedScene Prefab { get; set; }
}