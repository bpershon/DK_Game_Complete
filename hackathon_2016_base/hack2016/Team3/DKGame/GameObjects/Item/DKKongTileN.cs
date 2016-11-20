using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public class DKKongTileN : DKKongTile
    {

        public DKKongTileN()
        {
            kongTileLetter = DKKongTileType.N;
            sprite = ItemSpriteFactory.Instance.CreateDKKongTileSprite(kongTileLetter);
            state = new DKKongTileIdleState(this);
            BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = new Vector2(225, 150), Dimensions = sprite.Dimensions, Type = BodyType.Kinematic };
            Filter filter = new Filter();
            filter.Category = (byte)Filter.Categories.Collectible;
            filter.Mask = (byte)Filter.Categories.Player;
            bodyDef.Filter = filter;
            body = PhysicsWorld.Instance.CreateBody(bodyDef);
            body.UserData = this;
        }

    }
}
