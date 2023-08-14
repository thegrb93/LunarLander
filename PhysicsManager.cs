
using Microsoft.Xna.Framework;

public class PhysicsManager
{
	public FarseerPhysics.Dynamics.World World { get; } = new FarseerPhysics.Dynamics.World( new Vector2() );
	public PhysicsManager()
	{
	}

	public void Update()
	{
	}
}
