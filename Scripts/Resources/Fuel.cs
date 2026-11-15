using Godot;

namespace SpaceExploration101.Scripts;

[GlobalClass]
public partial class Fuel(
    string name
    ) : SpaceshipResourceBase
{
    [Export] 
    public string Name { get; set; } = name;
    
    public Fuel() : this("") { }
}