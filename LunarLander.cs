using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LunarLander
{
	public class LunarLander : Game
	{
		public GraphicsDeviceManager graphics;
		public InputManager input { get; } = new InputManager();
		public ObjectManager objects { get; } = new ObjectManager();
		public PhysicsManager physics { get; } = new PhysicsManager();
		public BasicEffect shader { get; private set; }

		private LunarLander()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			shader = new BasicEffect( graphics.GraphicsDevice );
			float aspect = (float)Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
			shader.Projection = Matrix.CreateOrthographicOffCenter( -aspect, aspect, -1, 1, -1, 1 );

			base.Initialize();
		}

		protected override void LoadContent()
		{
			Ship.LoadContent();

			var ship = new Ship();
			input.KeyListener.Focus = ship;
			objects.Add( ship );
		}

		protected override void Update(GameTime gameTime)
		{
			input.Update();
			physics.Update();
			objects.Update();

			if (input.KeyState.IsKeyDown(Keys.Escape))
				Exit();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear( Color.CornflowerBlue );
			objects.Draw();
			base.Draw( gameTime );
		}
		public static LunarLander instance { get; } = new LunarLander();
		private static void Main( string[] args )
		{
			instance.Run();
		}
	}
}