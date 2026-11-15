using System.ComponentModel.DataAnnotations;
using Godot;

namespace SpaceExploration101.Scripts;

[GlobalClass]
public partial class TankComponent : SpaceshipComponent
{
    [Export]
    public SpaceshipResourceBase Resource { get; set; }

    [Export] [UIHint("If the resource is liquid, this is in milliters; if not, units are in cubic centimeters")]
    public float MaxCapacity;

    [Export]
    [UIHint("If the resource is liquid, this is in milliters; if not, units are in cubic centimeters")]
    public float CurrentCapacity
    {
        get => _currentCapacity;
        set
        {
            if (value <= MaxCapacity)
            {
                _currentCapacity = value;
            }
        }
    }
    
    private float _currentCapacity;

    public TankComponent() : this(null, 0.0f, 0.0f) { }

    public TankComponent(SpaceshipResourceBase resource, float maxCapacity = 0.0f, float currentCapacity = 0.0f)
    {
        Resource = resource;
        MaxCapacity = maxCapacity;
        CurrentCapacity = currentCapacity;
    }
}