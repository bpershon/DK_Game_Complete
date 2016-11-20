using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using WindowsInput;

namespace DKGame
{
	[Flags]
	public enum PlayerCollisionState
	{
		Ground = 0x02,
		Barrel = 0x04
	}

    public class Player : IGameObject, IUserInputReceiver
    {
		private static readonly float LINEAR_DAMPING = 5.0f;
		private static readonly float CAMERA_DISPLACEMENT_X = DKDrawingPipeline.WINDOW_WIDTH/2.0f;
        private static readonly float CAMERA_DISPLACEMENT_Y = 2.0f*DKDrawingPipeline.WINDOW_HEIGHT/3.0f;
        private static readonly int MASS = 10;

        public PlayerCollisionState CollisionState { get; set; } = 0x00;
		public IItem CollidingBarrel { get; set; }

		private float horizontalImpulse;
		public float HorizontalImpulse
		{
			get { return horizontalImpulse; }
			set { horizontalImpulse = value; }
		}

        private IBody body;
        public IBody Body
        {
            get { return body; }
            set { body = value; }
        }

        private ISprite sprite;
        public ISprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        private IPlayerState state;
        public IPlayerState State
        {
            get { return state; }
            set { state = value; }
        }

        private bool facingRight;
        public bool FacingRight
        {
            get { return facingRight; }
            set { facingRight = value; }
        }

        public GameObjectType GameObjType
        {
            get { return GameObjectType.Player; }
        }

        public Player()
        {
            facingRight = true;  
			BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = new Vector2(150, 300), Type = BodyType.Dynamic, Dimensions = Vector2.Zero };
            Filter filter = new Filter();
            filter.Category = (byte) Filter.Categories.Player;
            filter.Mask = (byte) Filter.Categories.Enemy + (byte) Filter.Categories.Projectile + (byte) Filter.Categories.LevelBlock + (byte) Filter.Categories.Collectible + (byte) Filter.Categories.Interactive;
            bodyDef.Filter = filter;
            bodyDef.Mass = MASS;
            body = PhysicsWorld.Instance.CreateBody(bodyDef);
			body.LinearDamping = LINEAR_DAMPING;
            body.UserData = this;
            PhysicsWorld.Instance.OnContact += OnContact;
			state = new DKIdleState(this);
        }

        private void OnContact(object sender, ContactEventArgs e)
        {
            if (e.Object1.UserData is Player || e.Object2.UserData is Player)
            {
                PlayerCollisionHandler.CollisionResponse(e.Object1.UserData as IGameObject, e.Object2.UserData as IGameObject, e.Side);
            }
        }

        public void Update()
        {
            Vector2 cameraPos = new Vector2(body.BottomCenter.X - CAMERA_DISPLACEMENT_X, body.BottomCenter.Y - CAMERA_DISPLACEMENT_Y);
            WorldManager.Instance.MoveCamera(cameraPos);
            state.Update();
            sprite.Update();
			CollisionState = 0x00;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
			sprite.Draw(spriteBatch, body.BottomCenter, !facingRight);
        }

        public void SetInitialPosition(Vector2 pos)
        {
            body.BottomCenter = pos;
        }

        #region Input

        public void MoveLeft()
		{
			state.ProcessLeft();
		}

		public void MoveRight()
		{
			state.ProcessRight();
		}

		public void MoveUp()
		{
			state.ProcessUp();
		}

		public void MoveDown()
		{
			state.ProcessDown();
		}

		public void MoveHorizontalIdle()
		{
            state.HorizontalIdle();
		}

        public void MoveVerticalIdle()
        {
            state.VerticalIdle();
        }

        public void PerformAction()
        {
			state.PerformAction();
        }

		public void CharacterSwap()
		{
			state.ChangePlayer();
		}

        public void Reset()
        {
            //No-op - reset handled from above
        }

        public void Win()
        {
            state.Win();
        }

        #endregion

        #region Collision State

        public bool HasCollisionFlag(PlayerCollisionState flag)
		{
			return (CollisionState & flag) != 0;
		}

		public void CollidedWithGround()
		{
			CollisionState = CollisionState | PlayerCollisionState.Ground;
		}

		public void CollidedWithBarrel(IItem barrel)
		{
			CollisionState = CollisionState | PlayerCollisionState.Barrel;
			CollidingBarrel = barrel;
		}

		#endregion
    }
}
