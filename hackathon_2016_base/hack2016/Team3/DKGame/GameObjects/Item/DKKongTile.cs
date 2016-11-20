using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public abstract class DKKongTile : IItem
    {
        protected IBody body;
        public IBody Body
        {
            get { return body; }
            set { body = value; }
        }

        protected ISprite sprite;
        public ISprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        protected IItemState state;

        public IItemState State
        {
            get { return state; }
            set { state = value; }
        }

        protected DKKongTileType kongTileLetter;

        public DKKongTileType KongTileLetter
        {
           
            get { return kongTileLetter; }
        }

        public GameObjectType GameObjType
        {
            get { return GameObjectType.Collectable; }
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
