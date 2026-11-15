using System.ComponentModel.DataAnnotations;
using Godot;

namespace SpaceExploration101.Scripts;

[GlobalClass]
public partial class EngineComponent(
    float force,
    Fuel fuel
    ) : SpaceshipComponent
{
    [Export]
    [UIHint("In Newtons")]
    public float Force { get; set; }

    [Export] public Fuel Fuel { get; set; } = fuel;
    
    public bool _isConnectedToFuel = false;

    public EngineComponent() : this(0.0f, null) { }
}