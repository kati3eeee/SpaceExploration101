using System.ComponentModel.DataAnnotations;
using Godot;

namespace SpaceExploration101.Scripts;

[GlobalClass]
public partial class SpaceshipResourceBase(float mass) : Resource
{
    [Export]
    [UIHint("In grams")]
    public float Mass = mass;

    public SpaceshipResourceBase() : this(0.0f) { }
}