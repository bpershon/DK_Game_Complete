
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using WindowsInput;

namespace DKGame
{
	/*
	 * Main class for our platformer game 
	 */
	public class DKGame : Game, IGameStateReceiver
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private List<IGameController> inputControllers;
        private bool paused = false;

		private static readonly Vector2 WINDOW_SIZE = new Vector2(516, 452);

		private static DKGame instance;

		public static Vector2 ViewportSize
		{
			get
			{
				Viewport vp = instance.GraphicsDevice.Viewport;
				return new Vector2(vp.Width, vp.Height);
			}
		}

        public DKGame()
		{
			instance = this;
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			inputControllers = new List<IGameController> {new GameKeyboardController(this) };
			graphics.PreferredBackBufferWidth = (int)WINDOW_SIZE.X;
			graphics.PreferredBackBufferHeight = (int)WINDOW_SIZE.Y;
		}

		#region Overriden Game Methods

		/*
		 * Allows the game to perform any initialization it needs to before starting to run.
		 * This is where it can query for any required services and load any non-graphic
		 * related content.  Calling base.Initialize will enumerate through any components
		 * and initialize them as well.
		 */
		protected override void Initialize()
        {
            WorldManager.Instance.Initialize();
            base.Initialize(); 
        }

		/*
		 * LoadContent will be called once per game and is the place to load
		 * all of your content.
		 */
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
            SoundPool.LoadContent(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
			FontFactory.Instance.LoadAllFonts(Content);
            WorldManager.Instance.LoadAllGameObjects();
            PlayerCollisionHandler.LoadCollisionResponseTable();
            EnemyCollisionHandler.LoadCollisionResponseTable();
        }

		/*
		 * Allows the game to run logic such as updating the world,
		 * checking for collisions, gathering input, and playing audio.
		 * Param gameTime provides a snapshot of timing values.
		 */
		protected override void Update(GameTime gameTime)
		{
            //InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_X);
            if (!paused) {
                PhysicsWorld.Instance.Update(gameTime);
                foreach (IGameController controller in inputControllers)
                {
                    controller.ProcessUpdate();
                }
                WorldManager.Instance.Update();
            }else
            {
                foreach (IGameController controller in inputControllers)
                {
                    controller.ProcessUpdate();
                }
            }
            
            Test.move();
            //InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_X);
            base.Update(gameTime);
        }

		/*
		 * This is called when the game should draw itself.
		 * Param gameTime provides a snapshot of timing values.
		 */
		protected override void Draw(GameTime gameTime)
		{

            if (!paused)
            {
                graphics.GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                WorldManager.Instance.Draw(spriteBatch);

                spriteBatch.End();

                base.Draw(gameTime);
            }
		}

		#endregion

		#region IGameStateReceiver

		public void Quit()
		{
			Exit();
		}

        public void Pause()
        {
            paused = !paused;
        }

		#endregion
	}
}

