using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public class BackgroundSprite
    {
        //Background image is 256*21 wide, 256*3 tall, game screen is 800x480
        private Texture2D texture;

        public BackgroundSprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
			DKDrawingPipeline.Instance.DrawBackground(spriteBatch, texture);
        }

}
}
