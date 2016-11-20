
namespace DKGame
{
    public static class ScoreSystem
    {
        private static int lives = 3;
        private const int BANANA_THRESHOLD = 100;
        private const int INITIAL_BANANAS = 0;
        private const int INITIAL_LIVES = 3;

        public static int Lives
        {
            get { return lives; }
        }

        public static void addLives(int count)
        {
            lives += count;
        }

        public static void subLives()
        {
            lives--;
        }

        private static int bananas;

        public static int Bananas
        {
            get { return bananas; }
        }

        public static void addBananas(int count)
        {
            int bananaThreshold = BANANA_THRESHOLD;
            bananas += count;
            if (bananas >= bananaThreshold)
            {
                lives++;
                bananas %= bananaThreshold;
            }
        }

        private static bool[] kongTiles = new bool[4];

        public static void addKongTiles(DKKongTileType kongTileLetter)
        {
            switch (kongTileLetter)
            {
                case DKKongTileType.K: kongTiles[0] = true; break;
                case DKKongTileType.O: kongTiles[1] = true; break;
                case DKKongTileType.N: kongTiles[2] = true; break;
                case DKKongTileType.G: kongTiles[3] = true; break;
            }
            bool getExtraLife = true;
            foreach (bool tileCollected in kongTiles)
            {
                if (tileCollected == false)
                {
                    getExtraLife = false;
                    break;
                }
            }
            if (getExtraLife)
            {
                lives++;
                clearKongTiles();
            }
        }

        public static void clearKongTiles()
        {
            kongTiles = new bool[4];
        }
        
        public static void Reset()
        {
            clearKongTiles();
            lives = INITIAL_LIVES;
            bananas = INITIAL_BANANAS;
        }
    }
}
