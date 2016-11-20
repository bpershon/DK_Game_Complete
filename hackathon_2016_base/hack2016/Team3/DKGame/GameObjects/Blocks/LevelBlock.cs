using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public class LevelBlock : IBlock
    {
        private ISprite sprite;

        public ISprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public GameObjectType GameObjType
        {
            get { return GameObjectType.LevelBlock; }
        }

        private IBody body;
        public IBody Body
        {
            get { return body; }
            set { body = value; }
        }

        public LevelBlock(Vector2 position, Vector2 size)
        {
            sprite = ItemSpriteFactory.Instance.CreateLevelBlockSprite();
            BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = position, Dimensions = sprite.Dimensions };
            Filter filter = new Filter();
            filter.Category = (byte)Filter.Categories.LevelBlock;
            filter.Mask = (byte)Filter.Categories.Player + (byte)Filter.Categories.Enemy + (byte)Filter.Categories.Projectile + (byte)Filter.Categories.Throwable;
            bodyDef.Filter = filter;
            body = PhysicsWorld.Instance.CreateBody(bodyDef);
            body.UserData = this;
        }

        public void Update()
        {
            sprite.Update();
        }

        public void SetInitialPosition(Vector2 pos)
        {
            body.BottomCenter = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, body.BottomCenter, false);
        }
    }
}
