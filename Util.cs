
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LunarLander
{
	public class Util
	{
		public static Matrix RotationTranslation( Vector2 position, float angle )
		{
			Matrix m = Matrix.CreateRotationZ( angle );
			m.Translation = new Vector3( position.X, position.Y, 0 );
			return m;
		}
		public static Matrix RotationTranslationZoom( Vector2 position, float angle, float zoom )
		{
			Matrix m = Matrix.CreateRotationZ( angle );
			m.Translation = new Vector3( position.X, position.Y, 0 );
			return m;
		}
		public static void SetAllMeshesEffect(Model model)
		{
			foreach( ModelMesh meshes in model.Meshes )
			{
				foreach ( ModelMeshPart parts in meshes.MeshParts )
				{
					parts.Effect = LunarLander.instance.shader;
				}
			}
		}
	}
}
