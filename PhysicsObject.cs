
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LunarLander
{
	public abstract class PhysicsObject : GameObject
	{
		public Model GraphicMesh;
		public Body PhysBody { get; }
		public PhysicsObject()
		{
			PhysBody = new Body( LunarLander.instance.physics.World );
		}

		public void DrawModel()
		{
			LunarLander.instance.shader.World = Util.RotationTranslation( Position, Rotation );
			foreach(ModelMesh mesh in GraphicMesh.Meshes)
			{
				mesh.Draw();
			}
		}
		public void Draw()
		{
			DrawModel();
		}
		public Vector2 Position
		{
			get { return PhysBody.Position; }
			set { PhysBody.Position = value; }
		}
		public float Rotation
		{
			get { return PhysBody.Rotation; }
			set { PhysBody.Rotation = value; }
		}

		public DrawLayer DrawLayer { get; } = DrawLayer.Foreground;
	}
}
