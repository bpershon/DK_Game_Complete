using DKGame;
using Microsoft.Xna.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDKGame
{
    public static class PlayerOnItemCollisionTests
    {
        public static void AssertPlayerCollectsBalloonLeft()
        {
            /*TEST 1:  Player vs DKBalloon Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBalloon();
            testObj.Body.BottomCenter = new Vector2(320, 300);

            DKBalloon testBal = (DKBalloon)testObj;
            Assert.IsTrue(testBal.State is DKBalloonCollectedState);
        }

        public static void AssertPlayerCollectsBananaLeft()
        {
            /*TEST 2:  Player vs DKBanana Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBanana();
            testObj.Body.BottomCenter = new Vector2(320, 300);

            DKBanana testConcrete = (DKBanana)testObj;
            Assert.IsTrue(testConcrete.State is DKBananaCollectedState);
        }

        public static void AssertPlayerCollectsBananaGroupLeft()
        {
            /*TEST 3:  Player vs DKBananaGroup Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBananaGroup();
            testObj.Body.BottomCenter = new Vector2(320, 300);

            DKBananaGroup testConcrete = (DKBananaGroup)testObj;
            Assert.IsTrue(testConcrete.State is DKBananaGroupCollectedState);
        }

        public static void AssertPlayerCollectsKongTileLeft()
        {
            /*TEST 4:  Player vs DKKongTile Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKKongTileK();
            testObj.Body.BottomCenter = new Vector2(320, 300);

            DKKongTile testConcrete = (DKKongTile)testObj;
            Assert.IsTrue(testConcrete.State is DKKongTileCollectedState);
        }

        public static void AssertPlayerRollsPlayerBarrelLeft()
        {
            /*TEST 5:  Player vs DKPlayerBarrel Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKPlayerBarrel();
            testObj.Body.BottomCenter = new Vector2(320, 300);

            DKPlayerBarrel testConcrete = (DKPlayerBarrel)testObj;
            Assert.IsTrue(testConcrete.State is DKPlayerBarrelRollState);
        }

        public static void AssertPlayerCollectsTrophyLeft()
        {
            /*TEST 6:  Player vs DKTrophy Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKTrophy();
            testObj.Body.BottomCenter = new Vector2(320, 300);

            DKTrophy testConcrete = (DKTrophy)testObj;
            Assert.IsTrue(testConcrete.State is DKTrophyCollectedState);
        }

        public static void AssertPlayerRollsStandardBarrelLeft()
        {
            /*TEST 7:  Player vs DKStandardBarrel Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKStandardBarrel();
            Vector2 testPos = new Vector2(320, 300);
            testObj.Body.BottomCenter = testPos;

            DKStandardBarrel testConcrete = (DKStandardBarrel)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.X, 0);
        }

        public static void AssertPlayerCollectsBalloonRight()
        {
            /*TEST 1:  Player vs DKBalloon Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBalloon();
            testObj.Body.BottomCenter = new Vector2(280, 300);

            DKBalloon testBal = (DKBalloon)testObj;
            Assert.IsTrue(testBal.State is DKBalloonCollectedState);
        }

        public static void AssertPlayerCollectsBananaRight()
        {
            /*TEST 2:  Player vs DKBanana Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBanana();
            testObj.Body.BottomCenter = new Vector2(280, 300);

            DKBanana testConcrete = (DKBanana)testObj;
            Assert.IsTrue(testConcrete.State is DKBananaCollectedState);
        }

        public static void AssertPlayerCollectsBananaGroupRight()
        {
            /*TEST 3:  Player vs DKBananaGroup Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBananaGroup();
            testObj.Body.BottomCenter = new Vector2(280, 300);

            DKBananaGroup testConcrete = (DKBananaGroup)testObj;
            Assert.IsTrue(testConcrete.State is DKBananaGroupCollectedState);
        }

        public static void AssertPlayerCollectsKongTileRight()
        {
            /*TEST 4:  Player vs DKKongTile Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKKongTileK();
            testObj.Body.BottomCenter = new Vector2(280, 300);

            DKKongTile testConcrete = (DKKongTile)testObj;
            Assert.IsTrue(testConcrete.State is DKKongTileCollectedState);
        }

        public static void AssertPlayerRollsPlayerBarrelRight()
        {
            /*TEST 5:  Player vs DKPlayerBarrel Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKPlayerBarrel();
            testObj.Body.BottomCenter = new Vector2(280, 300);

            DKPlayerBarrel testConcrete = (DKPlayerBarrel)testObj;
            Assert.IsTrue(testConcrete.State is DKPlayerBarrelRollState);
        }

        public static void AssertPlayerCollectsTrophyRight()
        {
            /*TEST 6:  Player vs DKTrophy Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKTrophy();
            testObj.Body.BottomCenter = new Vector2(280, 300);

            DKTrophy testConcrete = (DKTrophy)testObj;
            Assert.IsTrue(testConcrete.State is DKTrophyCollectedState);
        }

        public static void AssertPlayerRollsStandardBarrelRight()
        {
            /*TEST 7:  Player vs DKStandardBarrel Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKStandardBarrel();
            Vector2 testPos = new Vector2(280, 300);
            testObj.Body.BottomCenter = testPos;

            DKStandardBarrel testConcrete = (DKStandardBarrel)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.X, 0);
        }

        public static void AssertPlayerCollectsBalloonTop()
        {
            /*TEST 1:  Player vs DKBalloon Top*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBalloon();
            testObj.Body.BottomCenter = new Vector2(300, 320);

            DKBalloon testBal = (DKBalloon)testObj;
            Assert.IsTrue(testBal.State is DKBalloonCollectedState);
        }

        public static void AssertPlayerCollectsBananaTop()
        {
            /*TEST 2:  Player vs DKBanana Top*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBanana();
            testObj.Body.BottomCenter = new Vector2(300, 310);

            DKBanana testConcrete = (DKBanana)testObj;
            Assert.IsTrue(testConcrete.State is DKBananaCollectedState);
        }

        public static void AssertPlayerCollectsBananaGroupTop()
        {
            /*TEST 3:  Player vs DKBananaGroup Top*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBananaGroup();
            testObj.Body.BottomCenter = new Vector2(300, 310);

            DKBananaGroup testConcrete = (DKBananaGroup)testObj;
            Assert.IsTrue(testConcrete.State is DKBananaGroupCollectedState);
        }

        public static void AssertPlayerCollectsKongTileTop()
        {
            /*TEST 4:  Player vs DKKongTile Top*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKKongTileK();
            testObj.Body.BottomCenter = new Vector2(300, 310);

            DKKongTile testConcrete = (DKKongTile)testObj;
            Assert.IsTrue(testConcrete.State is DKKongTileCollectedState);
        }

        public static void AssertPlayerRollsPlayerBarrelTop()
        {
            /*TEST 5:  Player vs DKPlayerBarrel Top*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKPlayerBarrel();
            testObj.Body.BottomCenter = new Vector2(300, 310);

            DKPlayerBarrel testConcrete = (DKPlayerBarrel)testObj;
            Assert.IsTrue(testConcrete.State is DKPlayerBarrelRollState);
        }

        public static void AssertPlayerCollectsTrophyTop()
        {
            /*TEST 6:  Player vs DKTrophy Top*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKTrophy();
            testObj.Body.BottomCenter = new Vector2(300, 305);

            DKTrophy testConcrete = (DKTrophy)testObj;
            Assert.IsTrue(testConcrete.State is DKTrophyCollectedState);
        }

        public static void AssertPlayerRollsStandardBarrelTop()
        {
            /*TEST 7:  Player vs DKStandardBarrel Top*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKStandardBarrel();
            Vector2 testPos = new Vector2(300, 320);
            testObj.Body.BottomCenter = testPos;

            DKStandardBarrel testConcrete = (DKStandardBarrel)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerCollectsBalloonBottom()
        {
            /*TEST 1:  Player vs DKBalloon Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBalloon();
            testObj.Body.BottomCenter = new Vector2(300, 280);

            DKBalloon testBal = (DKBalloon)testObj;
            Assert.IsTrue(testBal.State is DKBalloonCollectedState);
        }

        public static void AssertPlayerCollectsBananaBottom()
        {
            /*TEST 2:  Player vs DKBanana Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBanana();
            testObj.Body.BottomCenter = new Vector2(300, 290);

            DKBanana testConcrete = (DKBanana)testObj;
            Assert.IsTrue(testConcrete.State is DKBananaCollectedState);
        }

        public static void AssertPlayerCollectsBananaGroupBottom()
        {
            /*TEST 3:  Player vs DKBananaGroup Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKBananaGroup();
            testObj.Body.BottomCenter = new Vector2(300, 290);

            DKBananaGroup testConcrete = (DKBananaGroup)testObj;
            Assert.IsTrue(testConcrete.State is DKBananaGroupCollectedState);
        }

        public static void AssertPlayerCollectsKongTileBottom()
        {
            /*TEST 4:  Player vs DKKongTile Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKKongTileK();
            testObj.Body.BottomCenter = new Vector2(300, 280);

            DKKongTile testConcrete = (DKKongTile)testObj;
            Assert.IsTrue(testConcrete.State is DKKongTileCollectedState);
        }

        public static void AssertPlayerRollsPlayerBarrelBottom()
        {
            /*TEST 5:  Player vs DKPlayerBarrel Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKPlayerBarrel();
            testObj.Body.BottomCenter = new Vector2(300, 280);

            DKPlayerBarrel testConcrete = (DKPlayerBarrel)testObj;
            Assert.IsTrue(testConcrete.State is DKPlayerBarrelRollState);
        }

        public static void AssertPlayerCollectsTrophyBottom()
        {
            /*TEST 6:  Player vs DKTrophy Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKTrophy();
            testObj.Body.BottomCenter = new Vector2(300, 280);

            DKTrophy testConcrete = (DKTrophy)testObj;
            Assert.IsTrue(testConcrete.State is DKTrophyCollectedState);
        }

        public static void AssertPlayerRollsStandardBarrelBottom()
        {
            /*TEST 7:  Player vs DKStandardBarrel Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new DKStandardBarrel();
            Vector2 testPos = new Vector2(300, 280);
            testObj.Body.BottomCenter = testPos;

            DKStandardBarrel testConcrete = (DKStandardBarrel)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }
    }
}
