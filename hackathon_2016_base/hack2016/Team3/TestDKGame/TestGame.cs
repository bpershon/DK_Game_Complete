using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKGame;

namespace TestDKGame
{
    [TestClass]
    public class TestGame : Game
    {
        GraphicsDeviceManager graphics;

        [TestMethod]
        public void TestAll()
        {
            Run();
        }

        public TestGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerCollisionHandler.LoadCollisionResponseTable();

            /*Test item collisions from left*/
            PlayerOnItemCollisionTests.AssertPlayerCollectsBalloonLeft();
            PlayerOnItemCollisionTests.AssertPlayerCollectsBananaLeft();
            PlayerOnItemCollisionTests.AssertPlayerCollectsBananaGroupLeft();
            PlayerOnItemCollisionTests.AssertPlayerCollectsKongTileLeft();
            PlayerOnItemCollisionTests.AssertPlayerRollsPlayerBarrelLeft();
            PlayerOnItemCollisionTests.AssertPlayerCollectsTrophyLeft();
            PlayerOnItemCollisionTests.AssertPlayerRollsStandardBarrelLeft();

            /*Test item collisions from right*/
            PlayerOnItemCollisionTests.AssertPlayerCollectsBalloonRight();
            PlayerOnItemCollisionTests.AssertPlayerCollectsBananaRight();
            PlayerOnItemCollisionTests.AssertPlayerCollectsBananaGroupRight();
            PlayerOnItemCollisionTests.AssertPlayerCollectsKongTileRight();
            PlayerOnItemCollisionTests.AssertPlayerRollsPlayerBarrelRight();
            PlayerOnItemCollisionTests.AssertPlayerCollectsTrophyRight();
            PlayerOnItemCollisionTests.AssertPlayerRollsStandardBarrelRight();

            /*Test item collisions from bottom*/
            PlayerOnItemCollisionTests.AssertPlayerCollectsBalloonBottom();
            PlayerOnItemCollisionTests.AssertPlayerCollectsBananaBottom();
            PlayerOnItemCollisionTests.AssertPlayerCollectsBananaGroupBottom();
            PlayerOnItemCollisionTests.AssertPlayerCollectsKongTileBottom();
            PlayerOnItemCollisionTests.AssertPlayerRollsPlayerBarrelBottom();
            PlayerOnItemCollisionTests.AssertPlayerCollectsTrophyBottom();
            PlayerOnItemCollisionTests.AssertPlayerRollsStandardBarrelBottom();

            /*Test item collisions from top*/
            PlayerOnItemCollisionTests.AssertPlayerCollectsBalloonTop();
            PlayerOnItemCollisionTests.AssertPlayerCollectsBananaTop();
            PlayerOnItemCollisionTests.AssertPlayerCollectsBananaGroupTop();
            PlayerOnItemCollisionTests.AssertPlayerCollectsKongTileTop();
            PlayerOnItemCollisionTests.AssertPlayerRollsPlayerBarrelTop();
            PlayerOnItemCollisionTests.AssertPlayerCollectsTrophyTop();
            PlayerOnItemCollisionTests.AssertPlayerRollsStandardBarrelTop();

            /*Test enemy collisions from left*/
            //PlayerOnEnemyCollisionTests.AssertGnawtyKillsPlayerLeft();
            PlayerOnEnemyCollisionTests.AssertKritterKillsPlayerLeft();
            PlayerOnEnemyCollisionTests.AssertKlumpKillsPlayerLeft();
            PlayerOnEnemyCollisionTests.AssertNeckyKillsPlayerLeft();

            /*Test enemy collisions from right*/
            //PlayerOnEnemyCollisionTests.AssertGnawtyKillsPlayerRight();
            PlayerOnEnemyCollisionTests.AssertKritterKillsPlayerRight();
            PlayerOnEnemyCollisionTests.AssertKlumpKillsPlayerRight();
            PlayerOnEnemyCollisionTests.AssertNeckyKillsPlayerRight();

            /*Test enemy collisions from top*/
            //PlayerOnEnemyCollisionTests.AssertGnawtyKillsPlayerBottom();
            PlayerOnEnemyCollisionTests.AssertKritterKillsPlayerBottom();
            PlayerOnEnemyCollisionTests.AssertKlumpKillsPlayerBottom();
            PlayerOnEnemyCollisionTests.AssertNeckyKillsPlayerBottom();

            /*Test player kill enemy collisions*/
            PlayerOnEnemyCollisionTests.AssertPlayerKillsGnawty();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsKlump();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsKritter();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsNecky();

            /*Test player kill enemy by rolling from left collisions*/
            PlayerOnEnemyCollisionTests.AssertPlayerKillsGnawtyRollLeft();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsKlumpRollLeft();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsKritterRollLeft();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsNeckyRollLeft();

            /*Test player kill enemy by rolling from right collisions*/
            PlayerOnEnemyCollisionTests.AssertPlayerKillsGnawtyRollRight();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsKlumpRollRight();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsKritterRollRight();
            PlayerOnEnemyCollisionTests.AssertPlayerKillsNeckyRollRight();

        }
        
        protected override void Update(GameTime gameTime)
        {
            if(gameTime.TotalGameTime.Seconds > 2)
            {
                Exit();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
        }
    }
}
