
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LunarLander
{
	public class Ship : PhysicsObject, InputObject
	{
		public Ship() : base()
		{
			GraphicMesh = shipModel;
		}
		public void KeyPressed(Keys key)
		{
		}
		public void KeyReleased(Keys key)
		{
		}

		public Keys[] ListeningKeys { get; } = new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D };

		public static Model shipModel;
		public static void LoadContent()
		{
			shipModel = LunarLander.instance.Content.Load<Model>( "models/ship" );
			Util.SetAllMeshesEffect( shipModel );
		}
	}
}
