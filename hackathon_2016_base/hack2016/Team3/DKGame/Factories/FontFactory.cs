using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace DKGame
{
	public class FontFactory
	{
		private static readonly string FONT_FOLDER = "Font/";

		private static FontFactory instance = new FontFactory();

		private SpriteFont hudFont;

		public static FontFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private FontFactory()
		{
		}

		public void LoadAllFonts(ContentManager content)
		{
			hudFont = content.Load<SpriteFont>(FONT_FOLDER + "hudFont");
		}

		public SpriteFont GetHudFont()
		{
			return hudFont;
		}
	}
}
