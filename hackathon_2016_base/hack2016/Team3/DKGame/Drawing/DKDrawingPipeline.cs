using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace DKGame
{
	public class DKDrawingPipeline
	{
		private static DKDrawingPipeline instance = new DKDrawingPipeline();

        public static readonly int WINDOW_WIDTH = 256;
		public static readonly int WINDOW_HEIGHT = 256;

		private static readonly Vector2 VIEWPORT = DKGame.ViewportSize;
		private static readonly Vector2 SCALE = new Vector2(VIEWPORT.X / WINDOW_WIDTH, VIEWPORT.Y / WINDOW_HEIGHT);

		private Vector2 mapMax;
		private Vector2 mapMin;

		//The game's location relative to the window
		private Vector2 gameLocation = Vector2.Zero;

		//The camera's location
		private Vector2 cameraLocation = Vector2.Zero;

		private ISprite bananaSprite = ItemSpriteFactory.Instance.CreateDKBananaSprite();
		private ISprite lifeSprite = ItemSpriteFactory.Instance.CreateDKBalloonSprite();
		private SpriteFont hudFont = FontFactory.Instance.GetHudFont();

		public Vector2 CameraLocation
		{
			get
			{
				return cameraLocation;
			}

			set
			{
				cameraLocation = value;
				cameraLocation.X = Math.Min(mapMax.X, cameraLocation.X);
				cameraLocation.X = Math.Max(mapMin.X, cameraLocation.X);
				cameraLocation.Y = Math.Min(mapMax.Y, cameraLocation.Y);
				cameraLocation.Y = Math.Max(mapMin.Y, cameraLocation.Y);
			}
		}

		public static DKDrawingPipeline Instance
		{
			get
			{
				return instance;
			}
		}

		private DKDrawingPipeline()
		{
			SetAreaProperties(DKAreaPropertyLookup.LookupPropertiesForArea("beginning"));
		}

		public void UpdateHUDAnimations()
		{
			bananaSprite.Update();
			lifeSprite.Update();
		}

		public void DrawObject(SpriteBatch spriteBatch, Texture2D texture, Vector2 worldPosition, Rectangle sourceRectangle, Vector2 bottomCenter, SpriteEffects effects)
		{
			Vector2 drawLocation = ComputeObjectAbsolutePosition(worldPosition);
			spriteBatch.Draw(texture, drawLocation, sourceRectangle, Color.White, 0, bottomCenter, SCALE, effects, 0);
		}

		public void DrawBackground(SpriteBatch spriteBatch, Texture2D texture)
		{
			spriteBatch.Draw(texture, gameLocation, new Rectangle((int)cameraLocation.X, (int)cameraLocation.Y, (int)VIEWPORT.X, (int)VIEWPORT.Y), Color.White, 0, Vector2.Zero, SCALE, SpriteEffects.None, 0);
        }


		public void DrawHUD(SpriteBatch spriteBatch)
		{
			float hudTop = 50;
			float leftMargin = 50;
			float rightMargin = 75;
			float textPadding = 10;

			string bananaString = ScoreSystem.Bananas.ToString();
			string lifeString = ScoreSystem.Lives.ToString();

			float fontHeight = hudFont.MeasureString(bananaString).Y;
			Vector2 bananaSize = bananaSprite.Dimensions;
			Vector2 lifeSize = lifeSprite.Dimensions;

			bananaSprite.DrawForHUD(spriteBatch, new Vector2(leftMargin, hudTop + bananaSize.Y/2.0f), false);

			spriteBatch.DrawString(hudFont, bananaString, new Vector2(leftMargin + bananaSize.X + textPadding, hudTop - fontHeight/2.0f), Color.White);

			lifeSprite.DrawForHUD(spriteBatch, new Vector2(VIEWPORT.X - rightMargin, hudTop + lifeSize.Y / 2.0f), false);
		
			spriteBatch.DrawString(hudFont, lifeString, new Vector2(VIEWPORT.X - rightMargin + lifeSize.X + textPadding, hudTop - fontHeight / 2.0f), Color.White);
		}

		public bool ObjectInSight(IGameObject gameObject)
		{
			Rectangle cameraRect = new Rectangle((int)cameraLocation.X, (int)cameraLocation.Y, WINDOW_WIDTH, WINDOW_HEIGHT);
			Rectangle objectRect = new Rectangle((int)gameObject.Body.TopLeft.X, (int)gameObject.Body.TopLeft.Y, (int)gameObject.Body.Dimensions.X, (int)gameObject.Body.Dimensions.Y);

			return cameraRect.Intersects(objectRect);
		}

		public void SetAreaProperties(DKAreaProperties props)
		{
			mapMin = new Vector2(props.origin.X, props.origin.Y);
			mapMax = new Vector2(props.origin.X + props.size.X - WINDOW_WIDTH, props.origin.Y + props.size.Y - WINDOW_HEIGHT);
		}

		private Vector2 ComputeObjectAbsolutePosition(Vector2 worldPosition)
		{
			Vector2 relativePosition = new Vector2(worldPosition.X - cameraLocation.X, worldPosition.Y - cameraLocation.Y);
			Vector2 unSCALEdPosition = new Vector2(gameLocation.X + relativePosition.X, gameLocation.Y + relativePosition.Y);
			return new Vector2(SCALE.X * unSCALEdPosition.X, SCALE.Y * unSCALEdPosition.Y);
		}
	}
}
