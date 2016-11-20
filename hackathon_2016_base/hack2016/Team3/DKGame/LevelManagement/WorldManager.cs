using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class WorldManager : IUserInputReceiver
    {
        private static List<IGameObject> gameObjects;
        private static List<IGameObject> waitingGameObjects;
        private static List<IUserInputReceiver> inputReceivers;
        private static List<IUserInputController> controllers;
		private static BackgroundSprite backgroundMap;
        private static bool gameIsOver = false;
        private static Player player;
        private static WorldManager instance = new WorldManager();

        public static WorldManager Instance
        {
            get
            {
                return instance;
            }
        }

        private WorldManager()
        {
        }

        public void Initialize()
        {
            inputReceivers = new List<IUserInputReceiver>();
            waitingGameObjects = new List<IGameObject>();
            controllers = new List<IUserInputController>{ new UserKeyboardController(this)};
        }

        public void LoadAllGameObjects()
        {
            DKLevelParser.ParseLevel("Levels/fullLevel1.tmx", out gameObjects);

            Player p = new Player();
            gameObjects.Add(p);
            inputReceivers.Add(p);
            player = p;
            SoundPool.PlayBackgroundMusic();

            backgroundMap = ItemSpriteFactory.Instance.CreateBackgroundSprite();
        }

		public void MoveCamera(Vector2 newPosition)
		{
			DKDrawingPipeline.Instance.CameraLocation = newPosition;
			foreach (IGameObject gameObject in gameObjects)
			{
				gameObject.Body.Awake = DKDrawingPipeline.Instance.ObjectInSight(gameObject);
			}
		}

        public void AddObject(IGameObject obj)
        {
            waitingGameObjects.Add(obj); 
        }

        public void RemoveObject(IGameObject obj)
        {
            gameObjects.Remove(obj);
        }

        public void Update()
        {
			DKDrawingPipeline.Instance.UpdateHUDAnimations();
            foreach (IUserInputController controller in controllers)
            {
                controller.ProcessUpdate();
            }
            foreach (IGameObject gameObject in gameObjects)
            {
                gameObject.Update();
                if (gameIsOver)
                {
                    break;
                }
            }
            gameObjects.AddRange(waitingGameObjects);
            waitingGameObjects.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
			backgroundMap.Draw(spriteBatch);
            foreach (IGameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
			DKDrawingPipeline.Instance.DrawHUD(spriteBatch);
        }
		public void MoveUp()
		{
			foreach (IUserInputReceiver receiver in inputReceivers)
			{
				receiver.MoveUp();
			}
		}

		public void MoveLeft()
		{
			foreach (IUserInputReceiver receiver in inputReceivers)
			{
				receiver.MoveLeft();
			}
		}

		public void MoveRight()
		{
			foreach (IUserInputReceiver receiver in inputReceivers)
			{
				receiver.MoveRight();
			}
		}

		public void MoveDown()
		{
			foreach (IUserInputReceiver receiver in inputReceivers)
			{
				receiver.MoveDown();
			}
		}

		public void MoveVerticalIdle()
		{
			foreach (IUserInputReceiver receiver in inputReceivers)
			{
				receiver.MoveVerticalIdle();
			}
		}

        public void MoveHorizontalIdle()
        {
            foreach (IUserInputReceiver receiver in inputReceivers)
            {
                receiver.MoveHorizontalIdle();
            }
        }

        public void PerformAction()
        {
            foreach (IUserInputReceiver receiver in inputReceivers)
            {
                receiver.PerformAction();
            }
        }

		public void CharacterSwap()
		{
			foreach (IUserInputReceiver receiver in inputReceivers)
			{
				receiver.CharacterSwap();
			}
		}

		public void Reset()
		{
            SoundPool.StopBackgroundMusic();
            PhysicsWorld.Instance.DestroyAllBodies();
            ScoreSystem.Reset();
            Initialize();
	        LoadAllGameObjects();
            gameIsOver = false;
		}

        public void ResetFromCheckpoint(Vector2 checkpointLocation)
        {
            Reset();
            player.SetInitialPosition(checkpointLocation); 
            gameIsOver = false;
		}

        public void GameOver()
        {
            SoundPool.StopBackgroundMusic();
            PhysicsWorld.Instance.DestroyAllBodies();
            Initialize();
            gameIsOver = true;
            gameObjects.Clear();
            ScoreSystem.Reset();
            MoveCamera(Vector2.Zero);
            backgroundMap = ItemSpriteFactory.Instance.CreateGameOverSprite();
        }

        public void Win()
        {
            SoundPool.PlaySound(Sound.PlayerDKVictory);
            ScoreSystem.Reset();
            player.Win();
        }
    }
}
