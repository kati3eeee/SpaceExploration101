using System.ComponentModel.DataAnnotations;
using Godot;

namespace SpaceExploration101.Scripts;

[GlobalClass]
public partial class Mission(
    string name,
    float destinationDistance
    ) : Resource
{
    [Export] 
    string Name { get; set; } = name;

    [Export] 
    [UIHint("In meters")]
    public float DestinationDistance { get; set; } = destinationDistance;

    public Mission() : this("", 0.0f) { }
}