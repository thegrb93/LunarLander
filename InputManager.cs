using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
	public interface InputObject
	{
		public void KeyPressed( Keys key ) { }
		public void KeyReleased( Keys key ) { }
		public Keys[] ListeningKeys { get; }
	}

	public class InputKeyListener
	{
		Dictionary<Keys, bool> pressed = new Dictionary<Keys, bool>();
		InputObject focus = null;
		public InputObject Focus
		{
			get { return focus; }
			set
			{
				focus = value;
				pressed.Clear();
				foreach (Keys k in value.ListeningKeys) { pressed[k] = false; }
			}
		}
		public void Update( KeyboardState state )
		{
			if (focus == null)
				return;

			foreach (Keys k in focus.ListeningKeys)
			{
				if (state.IsKeyDown( k ))
				{
					if (!pressed[k])
					{
						pressed[k] = true;
						focus.KeyPressed( k );
					}
				}
				else
				{
					if (pressed[k])
					{
						pressed[k] = false;
						focus.KeyReleased( k );
					}
				}
			}
		}
	}

	public class InputManager
    {
		public InputKeyListener KeyListener { get; set; } = new InputKeyListener();
        public KeyboardState KeyState
        {
            get; private set;
        }

        public void Update()
        {
            KeyState = Keyboard.GetState();
			KeyListener.Update(KeyState);
        }
    }

}
