using Godot;

namespace SpaceExploration101.Scripts;
public partial class Ship : Node2D
{
	[Export]
	public SpaceshipData MyData { get; set; }
	
	[Export]
	public TileMapLayer ShipTiles { get; set; }
	
	[ExportCategory("Parallax")]
	[Export]
	public PackedScene SpaceParallaxScene { get; set; }
	
	[Export]
	public int ParallaxSlowDownAmount { get; set; }

	public float DistanceTraveled = 0.0f;
	
	public float CurrentSpeed = 0.0f;

	private EngineComponent _engine;

	//Parallax stuff
	private Node2D _currentSpaceParallax;
	private Node2D _nextSpaceParallax;
	private float _tileMapSize;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_tileMapSize = ShipTiles.GetUsedRect().Size.X * 32;
		
		_currentSpaceParallax = SpaceParallaxScene.Instantiate<TileMapLayer>();
		AddChild(_currentSpaceParallax);
		
		foreach (SpaceshipComponent component in MyData.Components)
		{
			if (component is EngineComponent engine && !engine.Owner.IsEmpty)
			{
				if (GetNode(engine.Owner) == this)
				{
					_engine = engine;
				}
			}
		}
		
		//Verify engine connection
		if (_engine?.Connections[SpaceshipComponent.ComponentType.Storage] != null)
		{
			TankComponent tank = _engine.Connections[SpaceshipComponent.ComponentType.Storage] as TankComponent;
			
			if (tank?.Resource is not Fuel fuel || tank.Owner.IsEmpty) return;
			if (_engine.Fuel.Name == fuel.Name && GetNode(tank.Owner) == this)
			{
				_engine._isConnectedToFuel = true;
			}
		}
	}

	public void CalculateCurrentSpeed()
	{
		if (_engine?._isConnectedToFuel == true)
		{
			CurrentSpeed = _engine.Force;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CalculateCurrentSpeed();
		DistanceTraveled += (float)(CurrentSpeed * delta); // 1 second of this is equal to DistanceTraveled + _engine.Force

		if (_currentSpaceParallax != null)
		{
			_currentSpaceParallax.GlobalPosition -= new Vector2((float)((CurrentSpeed / ParallaxSlowDownAmount) * delta), 0);

			if (_currentSpaceParallax.GlobalPosition.X < -_tileMapSize)
			{
				_currentSpaceParallax.QueueFree();
				
				_currentSpaceParallax = _nextSpaceParallax;
				_nextSpaceParallax = null;
			}
			else if (_currentSpaceParallax.GlobalPosition.X < -(_tileMapSize / 2) && _nextSpaceParallax == null)
			{
				_nextSpaceParallax = SpaceParallaxScene.Instantiate<TileMapLayer>();
				AddChild(_nextSpaceParallax);
				
				_nextSpaceParallax.GlobalPosition += new Vector2(_tileMapSize / 2, 0);
			}

			if (_nextSpaceParallax != null)
			{
				_nextSpaceParallax.GlobalPosition -= new Vector2((float)((CurrentSpeed / ParallaxSlowDownAmount) * delta), 0);
			}
		}

		//GD.Print(DistanceTraveled);
	}
}
