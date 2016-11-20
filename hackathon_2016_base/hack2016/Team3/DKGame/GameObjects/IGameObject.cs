
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DKGame
{
	public enum GameObjectType { Player, LevelBlock, Rambi, DKExitSign, DKPlayerBarrel, DKRambiCrate, DKStandardBarrel, Enemy, ThrownBarrel, Collectable, Teleporter };

	public interface IGameObject
    {
        void Update();

        void Draw(SpriteBatch spriteBatch);

        void SetInitialPosition(Vector2 pos);

        GameObjectType GameObjType { get; }

        IBody Body { get; set; }

        ISprite Sprite { get; set; }
    }
}