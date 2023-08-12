using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LunarLander.GameObject;

namespace LunarLander
{
	public enum DrawLayer : int
	{
		Background,
		Foreground,
		MaxLayers,
	}
	public interface GameObject
	{
		public DrawLayer DrawLayer { get; }
		public void Update( GameTime gameTime )
		{
		}
		public void Draw( GameTime gameTime )
		{
		}
	}

	public class ObjectManager
	{
		HashSet<GameObject>[] drawLayers = new HashSet<GameObject>[(int)DrawLayer.MaxLayers];
        HashSet<GameObject> objectsToAdd = new HashSet<GameObject>();
        HashSet<GameObject> objectsToRemove = new HashSet<GameObject>();
		public ObjectManager()
		{
			for (int i = 0; i < (int)DrawLayer.MaxLayers; ++i)
			{
				drawLayers[i] = new HashSet<GameObject>();
			}
		}

        public void Add(GameObject obj)
        {
            objectsToAdd.Add(obj);
			objectsToRemove.Remove(obj);
        }
        public void Remove(GameObject obj)
        {
            objectsToAdd.Remove(obj);
            objectsToRemove.Add(obj);
		}
		public void Update( GameTime gameTime )
		{
			foreach (GameObject obj in objectsToAdd)
			{
				drawLayers[(int)obj.DrawLayer].Add( obj );
			}
			objectsToAdd.Clear();
			foreach (GameObject obj in objectsToRemove)
			{
				drawLayers[(int)obj.DrawLayer].Remove( obj );
			}
			objectsToRemove.Clear();
			for (int i = 0; i < (int)DrawLayer.MaxLayers; ++i)
			{
				foreach (GameObject obj in drawLayers[i])
				{
					obj.Update( gameTime );
				}
			}
		}
		public void Draw( GameTime gameTime )
		{
			for (int i = 0; i < (int)DrawLayer.MaxLayers; ++i)
			{
				foreach (GameObject obj in drawLayers[i])
				{
					obj.Draw( gameTime );
				}
			}
		}
	}
}
