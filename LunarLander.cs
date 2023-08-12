using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LunarLander
{
	public class LunarLander : Game
	{
		public GraphicsDeviceManager graphics;
		public InputManager input { get; } = new InputManager();
		public ObjectManager objects { get; } = new ObjectManager();
		public static LunarLander instance { get; } = new LunarLander();

		private LunarLander()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			var ship = new Ship();
			input.KeyListener.Focus = ship;
			objects.Add( ship );
			base.Initialize();
		}

		protected override void LoadContent()
		{
		}

		protected override void Update(GameTime gameTime)
		{
			input.Update();

            if (input.KeyState.IsKeyDown(Keys.Escape))
				Exit();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear( Color.CornflowerBlue );
			objects.Draw( gameTime );
			base.Draw( gameTime );
		}
		private static void Main( string[] args )
		{
			instance.Run();
		}
	}
}