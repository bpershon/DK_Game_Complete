using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public class DKRambiCrate : IItem
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
            get { return GameObjectType.DKRambiCrate; }
        }

        private IBody body;
        public IBody Body
        {
            get { return body; }
            set { body = value; }
        }

        public DKRambiCrate()
        {
            state = new DKRambiCrateIdleState(this);
            Vector2 rambiBB = new Vector2(41, 40);
            //For sprint 3 Rambi crate bounding box is based on open crate, causes collisions outside its sprite.
            BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = new Vector2(650, 150), Dimensions = rambiBB };
            Filter filter = new Filter();
            filter.Category = (byte)Filter.Categories.Interactive;
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
