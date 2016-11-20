using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace DKGame
{
	public class GenericSprite : ISprite
	{
		private static readonly int DEFAULT_UPDATES_PER_FRAME = 8;

		private Texture2D texture;
		private int totalSourceFrames;
		private int currentSourceFrame = 0;
		private int updatesPerFrame; //higher = slower
		private List<int> animationFrames;

		private int sourceFrameHeight;
		private int sourceFrameWidth;

		private ISpriteDelegate animationDelegate;

		public ISpriteDelegate AnimationDelegate
		{
			set{
				animationDelegate = value;
			}
		}

		public GenericSprite(Texture2D texture, int totalFrames, List<int> animationFrames) :
		this(texture, totalFrames, animationFrames, DEFAULT_UPDATES_PER_FRAME) { }

		public GenericSprite(Texture2D texture, int totalFrames, int updatesPerFrame) :
		this(texture, totalFrames, new List<int> { }, updatesPerFrame) { }

		public GenericSprite(Texture2D texture, int totalFrames) : 
		this(texture, totalFrames, new List<int> { }, DEFAULT_UPDATES_PER_FRAME) { }

		public GenericSprite(Texture2D texture, int totalFrames, List<int> animationFrames, int updatesPerFrame)
		{
			if (animationFrames.Count == 0)
			{
				for (int i = 0; i < totalFrames; i++)
				{
					animationFrames.Add(i);
				}
			}

			this.texture = texture;
			this.animationFrames = animationFrames;
			this.updatesPerFrame = updatesPerFrame;

			totalSourceFrames = totalFrames;

			sourceFrameHeight = texture.Height;
			sourceFrameWidth = texture.Width / totalSourceFrames;
		}

		public void Update()
		{
			currentSourceFrame++;
			if ((currentSourceFrame / updatesPerFrame) >= animationFrames.Count)
			{
				if (animationDelegate != null)
				{
					animationDelegate.SpriteAnimationFinished();
				}
				currentSourceFrame = 0;
			}
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 drawLocation, bool flipped)
		{
			int currentFramePosCol = animationFrames.ElementAt(currentSourceFrame / updatesPerFrame);
			Rectangle sourceRectangle = CalculateSourceRect(sourceFrameWidth, sourceFrameHeight, currentFramePosCol);

			SpriteEffects effects = flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Vector2 bottomCenter = new Vector2(sourceFrameWidth / 2, sourceFrameHeight);

			DKDrawingPipeline.Instance.DrawObject(spriteBatch, texture, drawLocation, sourceRectangle, bottomCenter, effects);
		}

		public void DrawForHUD(SpriteBatch spriteBatch, Vector2 position, bool flipped)
		{
			int currentFramePosCol = animationFrames.ElementAt(currentSourceFrame / updatesPerFrame);
			Rectangle sourceRectangle = CalculateSourceRect(sourceFrameWidth, sourceFrameHeight, currentFramePosCol);

			SpriteEffects effects = flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Vector2 bottomCenter = new Vector2(sourceFrameWidth / 2, sourceFrameHeight);

			spriteBatch.Draw(texture, position, sourceRectangle, Color.White, 0, bottomCenter, 1, effects, 0);
		}

		private static Rectangle CalculateSourceRect(int sourceFrameWidth, int sourceFrameHeight, int currentFramePos)
		{
			return new Rectangle(sourceFrameWidth * currentFramePos, 0, sourceFrameWidth, sourceFrameHeight);
		}
        public Vector2 Dimensions
        {
            get { return new Vector2(sourceFrameWidth, sourceFrameHeight); }
        }
    }
}
