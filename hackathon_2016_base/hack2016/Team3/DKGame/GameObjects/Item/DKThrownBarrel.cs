using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public class DKThrownBarrel : IItem
    {
        private float horizontalImpulse = 100.0f;
        public float HorizontalImpulse
        {
            get { return horizontalImpulse; }
            set { horizontalImpulse = value; }
        }

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
            get { return GameObjectType.ThrownBarrel; }
        }

        public DKThrownBarrel()
        {
            state = new DKThrownBarrelRollState(this);
            BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = new Vector2(575, 150), Type=BodyType.Dynamic, Dimensions = sprite.Dimensions };
            Filter filter = new Filter();
            filter.Category = (byte) Filter.Categories.Throwable;
            filter.Mask = (byte) Filter.Categories.Enemy + (byte)Filter.Categories.Projectile + (byte)Filter.Categories.LevelBlock;
            bodyDef.Filter = filter;
            bodyDef.Mass = 1;
            body = PhysicsWorld.Instance.CreateBody(bodyDef);
            body.UserData = this;
        }

        public void Update()
        {
            sprite.Update();
            state.Update();
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
