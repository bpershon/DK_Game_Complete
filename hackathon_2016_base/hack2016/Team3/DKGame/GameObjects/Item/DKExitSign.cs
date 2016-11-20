using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public class DKExitSign : IItem
    {
        private IBody body;
        public IBody Body
        {
            get { return body; }
            set { body = value; }
        }

        private ISprite sprite;
        public ISprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        private IItemState state;

        public IItemState State
        {
            get { return state; }
            set { state = value; }
        }

        public GameObjectType GameObjType
        {
            get { return GameObjectType.DKExitSign; }
        }

        public DKExitSign()
        {
            sprite = ItemSpriteFactory.Instance.CreateDKBalloonSprite();
            state = new DKExitSignIdleState(this);
            BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = new Vector2(150, 150), Dimensions = sprite.Dimensions };
            Filter filter = new Filter();
            filter.Category = (byte)Filter.Categories.Collectible;
            filter.Mask = (byte)Filter.Categories.Player;
            bodyDef.Filter = filter;
            body = PhysicsWorld.Instance.CreateBody(bodyDef);
            body.UserData = this;
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, body.BottomCenter, false);
        }

        public void SetInitialPosition(Vector2 pos)
        {
            body.BottomCenter = pos;
        }

    }
}
