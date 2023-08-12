using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
	public class ShipContent
	{
		public ShipContent()
		{
		}
	}

	public class Ship : GameObject, InputObject
	{
		public Ship()
		{
		}

        public void KeyPressed(Keys key)
        {
        }
		public void KeyReleased(Keys key)
        {

        }

		public Keys[] ListeningKeys { get; } = new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D };
		public DrawLayer DrawLayer { get; } = DrawLayer.Foreground;
		static ShipContent Content { get; } = new ShipContent();
	}
}
