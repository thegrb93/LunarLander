using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
	public class Camera
	{
		GameObject following = null;
		public Camera()
		{
		}
		void Update()
		{
			if ( following != null )
			{
				LunarLander.instance.shader.View = Util.RotationTranslation( following.Position, following.Rotation );
			}
		}
	}
}
