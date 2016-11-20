using DKGame;
using Microsoft.Xna.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDKGame
{
    public static class PlayerOnEnemyCollisionTests
    {
        public static void AssertGnawtyKillsPlayerLeft()
        {
            /*TEST 1:  Player vs Gnawty Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Gnawty();
            testObj.Body.BottomCenter = new Vector2(310, 300);
            
            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertKritterKillsPlayerLeft()
        {
            /*TEST 2:  Player vs Kritter Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Kritter();
            testObj.Body.BottomCenter = new Vector2(320, 300);
            
            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertKlumpKillsPlayerLeft()
        {
            /*TEST 3:  Player vs Klump Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Klump();
            testObj.Body.BottomCenter = new Vector2(320, 300);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertNeckyKillsPlayerLeft()
        {
            /*TEST 4:  Player vs Necky Left*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Necky();
            testObj.Body.BottomCenter = new Vector2(320, 300);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertGnawtyKillsPlayerRight()
        {
            /*TEST 1:  Player vs Gnawty Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Gnawty();
            testObj.Body.BottomCenter = new Vector2(290, 300);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertKritterKillsPlayerRight()
        {
            /*TEST 2:  Player vs Kritter Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Kritter();
            testObj.Body.BottomCenter = new Vector2(290, 300);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertKlumpKillsPlayerRight()
        {
            /*TEST 3:  Player vs Klump Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Klump();
            testObj.Body.BottomCenter = new Vector2(290, 300);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertNeckyKillsPlayerRight()
        {
            /*TEST 4:  Player vs Necky Right*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Necky();
            testObj.Body.BottomCenter = new Vector2(290, 300);

            Assert.IsTrue(player.State is DKDeadState);
        }
        public static void AssertGnawtyKillsPlayerBottom()
        {
            /*TEST 1:  Player vs Gnawty Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Gnawty();
            testObj.Body.BottomCenter = new Vector2(300, 290);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertKritterKillsPlayerBottom()
        {
            /*TEST 2:  Player vs Kritter Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Kritter();
            testObj.Body.BottomCenter = new Vector2(300, 290);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertKlumpKillsPlayerBottom()
        {
            /*TEST 3:  Player vs Klump Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Klump();
            testObj.Body.BottomCenter = new Vector2(300, 290);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertNeckyKillsPlayerBottom()
        {
            /*TEST 4:  Player vs Necky Bottom*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Necky();
            testObj.Body.BottomCenter = new Vector2(300, 290);

            Assert.IsTrue(player.State is DKDeadState);
        }

        public static void AssertPlayerKillsGnawty()
        {
            /*TEST 1:  Player vs Gnawty*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Gnawty();
            testObj.Body.BottomCenter = new Vector2(300, 310);

            Gnawty testConcrete = (Gnawty)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsKritter()
        {
            /*TEST 2:  Player vs Kritter*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Kritter();
            testObj.Body.BottomCenter = new Vector2(300, 310);

            Kritter testConcrete = (Kritter)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsKlump()
        {
            /*TEST 3:  Player vs Klump*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Klump();
            testObj.Body.BottomCenter = new Vector2(300, 310);

            Klump testConcrete = (Klump)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsNecky()
        {
            /*TEST 4:  Player vs Necky*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            IGameObject testObj = new Necky();
            testObj.Body.BottomCenter = new Vector2(300, 310);

            Necky testConcrete = (Necky)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsGnawtyRollLeft()
        {
            /*TEST 1:  Player vs Gnawty*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            player.State = new DKRollingState(player);
            IGameObject testObj = new Gnawty();
            testObj.Body.BottomCenter = new Vector2(310, 300);

            Gnawty testConcrete = (Gnawty)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsKritterRollLeft()
        {
            /*TEST 2:  Player vs Kritter*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            player.State = new DKRollingState(player);
            IGameObject testObj = new Kritter();
            testObj.Body.BottomCenter = new Vector2(310, 300);

            Kritter testConcrete = (Kritter)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsKlumpRollLeft()
        {
            /*TEST 3:  Player vs Klump*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            player.State = new DKRollingState(player);
            IGameObject testObj = new Klump();
            testObj.Body.BottomCenter = new Vector2(310, 300);

            Klump testConcrete = (Klump)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsNeckyRollLeft()
        {
            /*TEST 4:  Player vs Necky*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            player.State = new DKRollingState(player);
            IGameObject testObj = new Necky();
            testObj.Body.BottomCenter = new Vector2(310, 300);

            Necky testConcrete = (Necky)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsGnawtyRollRight()
        {
            /*TEST 1:  Player vs Gnawty*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            player.State = new DKRollingState(player);
            IGameObject testObj = new Gnawty();
            testObj.Body.BottomCenter = new Vector2(290, 300);

            Gnawty testConcrete = (Gnawty)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsKritterRollRight()
        {
            /*TEST 2:  Player vs Kritter*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            player.State = new DKRollingState(player);
            IGameObject testObj = new Kritter();
            testObj.Body.BottomCenter = new Vector2(290, 300);

            Kritter testConcrete = (Kritter)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsKlumpRollRight()
        {
            /*TEST 3:  Player vs Klump*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            player.State = new DKRollingState(player);
            IGameObject testObj = new Klump();
            testObj.Body.BottomCenter = new Vector2(290, 300);

            Klump testConcrete = (Klump)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

        public static void AssertPlayerKillsNeckyRollRight()
        {
            /*TEST 4:  Player vs Necky*/
            Player player = new Player();
            player.Body.BottomCenter = new Vector2(300, 300);
            player.State = new DKRollingState(player);
            IGameObject testObj = new Necky();
            testObj.Body.BottomCenter = new Vector2(290, 300);

            Necky testConcrete = (Necky)testObj;
            Assert.AreNotEqual(testConcrete.Body.Velocity.Y, 0);
        }

    }
}
