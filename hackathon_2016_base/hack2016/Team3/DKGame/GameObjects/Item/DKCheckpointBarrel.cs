using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public class DKCheckpointBarrel : IItem
    {
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
            get { return GameObjectType.Collectable; }
        }

        private IBody body;
        public IBody Body
        {
            get { return body; }
            set { body = value; }
        }

        public DKCheckpointBarrel()
        {
            sprite = ItemSpriteFactory.Instance.CreateDKCheckpointBarrelSpriteUnopened();
            state = new DKCheckpointBarrelIdleState(this);
            BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = new Vector2(300, 150), Dimensions = sprite.Dimensions, Type = BodyType.Kinematic };
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

        public void ProcessBreak()
        {
            state.ProcessBreak();
        }

        public void SetInitialPosition(Vector2 pos)
        {
            body.BottomCenter = pos;
        }

    }
}
