using System;
using Godot;
using Godot.Collections;

namespace SpaceExploration101.Scripts;

[GlobalClass]
public partial class SpaceshipComponent(
    string name,
    float powerConsumption,
    float cost,
    PackedScene prefab,
    NodePath owner
    ) : SpaceshipResourceBase
{

    [Export] 
    public NodePath Owner { get; set; } = owner;
    
    [Export]
    public string Name { get; set; }
    
    [Export]
    public float PowerConsumption { get; set; }
    
    [Export]
    public float Cost { get; set; }
    
    [Export]
    public Dictionary<ComponentType, SpaceshipComponent> Connections { get; set; }
    
    [Export]
    public PackedScene Prefab { get; set; }
    
    public SpaceshipComponent() : this("", 0.0f, 0.0f, null, null) { }

    public enum ComponentType
    {
        Engine,
        Storage
    }
}