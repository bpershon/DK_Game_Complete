using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DKGame
{
	public enum DKKongTileType
	{
		A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
	}

    public class ItemSpriteFactory : ISpriteFactory
    {
        private static readonly string FILE_PATH = "Item/";
        private static readonly string BACKGROUND_PATH = "Background/";
        private Texture2D balloonLifeSpriteSheet;
        private Texture2D bananaGroupSpriteSheet;
        private Texture2D bananaSpriteSheet;
        private Texture2D checkPointBarrelSpriteSheet;
        private Texture2D kongTileSpriteSheet;
        private Texture2D playerBarrelSpriteSheet;
        private Texture2D rambiCrateSpriteSheet;
        private Texture2D standardBarrelSpriteSheet;
        private Texture2D standardBarrelBrokenSpriteSheet;
        private Texture2D pickupBarrelSpriteSheet;
        private Texture2D ostTrophySpriteSheet;
        private Texture2D ostTrophyCollectedSpriteSheet;
        private Texture2D arrowSignSpriteSheet;
        private Texture2D exitSignSpriteSheet;
        private Texture2D introSignSpriteSheet;
        private Texture2D tireSpriteSheet;
        private Texture2D backgroundSpriteSheet;
        private Texture2D levelBlockSpriteSheet;
        private Texture2D barrelRollSpriteSheet;
        private Texture2D rambiIdleSpriteSheet;
        private Texture2D gameOverSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            #region Item Textures
            balloonLifeSpriteSheet = content.Load<Texture2D>(FILE_PATH + "balloon_life");
            bananaGroupSpriteSheet = content.Load<Texture2D>(FILE_PATH + "banana_bunch");
            bananaSpriteSheet = content.Load<Texture2D>(FILE_PATH + "banana_single");
            checkPointBarrelSpriteSheet = content.Load<Texture2D>(FILE_PATH + "barrel_check");
            kongTileSpriteSheet = content.Load<Texture2D>(FILE_PATH + "token_letters");
            playerBarrelSpriteSheet = content.Load<Texture2D>(FILE_PATH + "barrel_dk");
            rambiCrateSpriteSheet = content.Load<Texture2D>(FILE_PATH + "crate_rambi");
            standardBarrelSpriteSheet = content.Load<Texture2D>(FILE_PATH + "barrel_reg");
            standardBarrelBrokenSpriteSheet = content.Load<Texture2D>(FILE_PATH + "barrel_reg_break");
            pickupBarrelSpriteSheet = content.Load<Texture2D>(FILE_PATH + "barrel_reg_roll_start");
            ostTrophySpriteSheet = content.Load<Texture2D>(FILE_PATH + "token_ost");
            arrowSignSpriteSheet = content.Load<Texture2D>(FILE_PATH + "sign_arrow");
            exitSignSpriteSheet = content.Load<Texture2D>(FILE_PATH + "sign_exit");
            introSignSpriteSheet = content.Load<Texture2D>(FILE_PATH + "sign_intro");
            tireSpriteSheet = content.Load<Texture2D>(FILE_PATH + "tire");
            ostTrophyCollectedSpriteSheet = content.Load<Texture2D>(FILE_PATH + "token_ost_collected");
            barrelRollSpriteSheet = content.Load<Texture2D>(FILE_PATH + "barrel_reg_roll");
            rambiIdleSpriteSheet = content.Load<Texture2D>(FILE_PATH + "rambi_idle");
            levelBlockSpriteSheet = content.Load<Texture2D>(BACKGROUND_PATH + "levelBlock");
            backgroundSpriteSheet = content.Load<Texture2D>(BACKGROUND_PATH + "DKCMap");
            gameOverSpriteSheet = content.Load<Texture2D>(BACKGROUND_PATH + "gameOver");
            #endregion
        }

        #region Item Sprite functions
        public ISprite CreateDKArrowSignSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(arrowSignSpriteSheet, totalFrames);
        }
        public ISprite CreateDKBalloonSprite()
        {
            int totalFrames = 7;
            List<int> dkBalloonAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1 };

            return new GenericSprite(balloonLifeSpriteSheet, totalFrames,dkBalloonAnimationFrames);
        }
        public ISprite CreateDKBananaGroupSprite()
        {
            int totalFrames = 6;
            List<int> dkBananaGroupAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 5, 4, 3, 2, 1 };

            return new GenericSprite(bananaGroupSpriteSheet, totalFrames, dkBananaGroupAnimationFrames);
        }
        public ISprite CreateDKBananaSprite()
        {
            int totalFrames = 8;
            return new GenericSprite(bananaSpriteSheet, totalFrames);
        }
        public ISprite CreateDKBarrelRollSprite()
        {
            int totalFrames = 8;
            return new GenericSprite(barrelRollSpriteSheet, totalFrames);
        }
        public ISprite CreateDKCheckpointBarrelSpriteUnopened()
        {
            int totalFrames = 9;
            List<int> dkCheckpointUnopenedAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

            return new GenericSprite(checkPointBarrelSpriteSheet, totalFrames, dkCheckpointUnopenedAnimationFrames);
        }
		public ISprite CreateDKCheckpointBarrelSpriteOpened()
		{
			int totalFrames = 9;
            List<int> dkCheckpointBarrelOpenedAnimationFrames = new List<int> { 8 };

            return new GenericSprite(checkPointBarrelSpriteSheet, totalFrames, dkCheckpointBarrelOpenedAnimationFrames);
		}
        public ISprite CreateDKExitSignSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(exitSignSpriteSheet, totalFrames);
        }
        public ISprite CreateDKIntroSignSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(introSignSpriteSheet, totalFrames);
        }
        public ISprite CreateDKPlayerBarrelSprite()
        {
            int totalFrames = 5;
            List<int> dkPlayerBarrelAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 3, 2, 1 };

            return new GenericSprite(playerBarrelSpriteSheet, totalFrames,  dkPlayerBarrelAnimationFrames);
        }
        public ISprite CreateDKRambiCrateUnopenedSprite()
        {
            int totalFrames = 3;
            List<int> dkRambiUnopenedAnimationFrames = new List<int> { 0 };
            return new GenericSprite(rambiCrateSpriteSheet, totalFrames, dkRambiUnopenedAnimationFrames);
        }
		public ISprite CreateDKRambiCrateOpeningSprite()
		{
			int totalFrames = 3;
			return new GenericSprite(rambiCrateSpriteSheet, totalFrames);
		}
		public ISprite CreateDKRambiCrateOpenedSprite()
		{
			int totalFrames = 3;
            List<int> dkRambiOpenedAnimationFrames = new List<int> { 2 };

            return new GenericSprite(rambiCrateSpriteSheet, totalFrames, dkRambiOpenedAnimationFrames);
		}
        public ISprite CreateDKStandardBarrelSprite()
        {
            int totalFrames = 6;
			return new GenericSprite(standardBarrelSpriteSheet, totalFrames);
        }
        public ISprite CreateDKStandardBarrelBrokenSprite()
        {
            int totalFrames = 9;
            return new GenericSprite(standardBarrelBrokenSpriteSheet, totalFrames);
        }
        public ISprite CreateDKTireSprite()
        {
            int totalFrames = 7;
            return new GenericSprite(tireSpriteSheet, totalFrames);
        }
        public ISprite CreateDKTrophySprite()
        {
            int totalFrames = 8;
            return new GenericSprite(ostTrophySpriteSheet, totalFrames);
        }
        public ISprite CreateDKTrophyCollectedSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(ostTrophyCollectedSpriteSheet, totalFrames);
        }
        public ISprite CreateDKKongTileSprite(DKKongTileType tileType)
		{
			int totalFrames = 26;
            List<int> kongTileAnimationFrames = new List<int> { (int)tileType };

            return new GenericSprite(kongTileSpriteSheet, totalFrames, kongTileAnimationFrames);
		}
        public ISprite CreateLevelBlockSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(levelBlockSpriteSheet, totalFrames);
        }
        public ISprite CreateDKRambiIdleSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(rambiIdleSpriteSheet, totalFrames);
        }
		public BackgroundSprite CreateBackgroundSprite()
		{
			return new BackgroundSprite(backgroundSpriteSheet);
		}
        public BackgroundSprite CreateGameOverSprite()
        {
            return new BackgroundSprite(gameOverSpriteSheet);
        }
        #endregion
    }

}
