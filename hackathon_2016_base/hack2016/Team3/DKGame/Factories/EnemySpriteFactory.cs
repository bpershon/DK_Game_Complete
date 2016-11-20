using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DKGame
{
    public class EnemySpriteFactory : ISpriteFactory
    {
        private static readonly string FILE_PATH = "Enemy/enemy_";
		private static readonly int ENEMY_ANIMATION_SPEED = 5;
        private Texture2D gnawtySpriteSheet;
        private Texture2D klumpSpriteSheet;
        private Texture2D kritterSpriteSheet;
        private Texture2D neckySpriteSheet;
        private Texture2D neckyProjectileSpriteSheet;
        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            #region Enemy Textures
            gnawtySpriteSheet = content.Load<Texture2D>(FILE_PATH + "gnawty");
            klumpSpriteSheet = content.Load<Texture2D>(FILE_PATH + "klump");
            kritterSpriteSheet = content.Load<Texture2D>(FILE_PATH + "kritter");
            neckySpriteSheet = content.Load<Texture2D>(FILE_PATH + "necky");
            neckyProjectileSpriteSheet = content.Load<Texture2D>(FILE_PATH + "necky_projectile");
            #endregion
        }

        #region Enemy Sprite functions
        public ISprite CreateDKGnawtySprite()
        {
            int totalFrames = 8;
            return new GenericSprite(gnawtySpriteSheet, totalFrames, ENEMY_ANIMATION_SPEED);
        }
        public ISprite CreateDKKlumpSprite()
        {
            int totalFrames = 8;
            return new GenericSprite(klumpSpriteSheet, totalFrames, ENEMY_ANIMATION_SPEED);
        }
        public ISprite CreateDKKritterSprite()
        {
            int totalFrames = 8;
            return new GenericSprite(kritterSpriteSheet, totalFrames, ENEMY_ANIMATION_SPEED);
        }
        public ISprite CreateDKNeckySprite()
        {
            int totalFrames = 10;
            List<int> neckyAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            return new GenericSprite(neckySpriteSheet, totalFrames, neckyAnimationFrames, ENEMY_ANIMATION_SPEED);
        }
        public ISprite CreateDKNeckyProjectileSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(neckyProjectileSpriteSheet, totalFrames);
        }
        #endregion
    }
}
