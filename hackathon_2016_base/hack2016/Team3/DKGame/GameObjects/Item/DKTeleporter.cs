using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace DKGame
{
	public class DKTeleporter : IGameObject
	{
		public IBody Body { get; set;}
		public ISprite Sprite { get; set; }

		public string Destination { get; set; }

		private Vector2 dimensions = new Vector2(30, 30);

		public DKTeleporter()
		{
			BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = new Vector2(150, 150), Dimensions = dimensions, Type = BodyType.Static };
			Filter filter = new Filter();
			filter.Category = (byte)Filter.Categories.Interactive;
			filter.Mask = (byte)Filter.Categories.Player;
			bodyDef.Filter = filter;
			Body = PhysicsWorld.Instance.CreateBody(bodyDef);
			Body.UserData = this;
		}

		public GameObjectType GameObjType
		{
			get { return GameObjectType.Teleporter; }
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			//No-op - Teleporters are not visible
		}

		public void SetInitialPosition(Vector2 position)
		{
			Body.BottomCenter = position;
		}

		public void Update()
		{
			//No-op
		}
	}
}
