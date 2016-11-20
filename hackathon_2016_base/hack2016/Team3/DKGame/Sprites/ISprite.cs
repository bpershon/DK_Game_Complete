using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace DKGame
{
	public interface ISprite
	{
		// The goal here is to separate rendering code from game logic.
		// UpdatePosition signals to the sprite that it should execute a single loop of game logic.
		void Update();
		// Draw, on the other hand, should simply render the sprite with its current position.
		void Draw(SpriteBatch spriteBatch, Vector2 position, bool flipped);
		// Draw without accounting for camera
        void DrawForHUD(SpriteBatch spriteBatch, Vector2 position, bool flipped);
		// Used to get bounding boxes for collision detection
		Vector2 Dimensions
        {
            get;
        }

		ISpriteDelegate AnimationDelegate
		{
			set;
		}
    }
}

