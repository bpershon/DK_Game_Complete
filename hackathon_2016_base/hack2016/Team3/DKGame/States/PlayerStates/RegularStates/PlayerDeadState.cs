using System;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public abstract class PlayerDeadState : PlayerBaseStateRegular, ISpriteDelegate
    {
		protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
		{
			base.Setup(player, transitionSet, sprite);
			this.player.Body.Velocity = Vector2.Zero;
			this.player.HorizontalImpulse = 0.0f;
            player.Sprite.AnimationDelegate = this;
            ScoreSystem.subLives();
		}

        public override void ProcessLeft()
        {
            // No-Op
        }

        public override void ProcessRight()
        {
            // No-Op
        }

        public override void ProcessUp()
        {
            // No-Op
        }

        public override void ProcessDown()
        {
            // No-Op
        }

        public override void ChangePlayer()
        {
            // No-Op
        }
	   
        public override void Die()
        {
            // No-Op
        }

        public override void PerformAction()
        {
            // No-Op
        }

        public override void MountRambi()
        {
            // No-Op
        }

        public override void DismountRambi()
        {
            // No-Op
        }

        public override void HorizontalIdle()
        {
            // No-op
        }

        public override void VerticalIdle()
        {
            // No-op
        }

        public void SpriteAnimationFinished()
        {
            if (ScoreSystem.Lives > -1)
            {
                if (CheckpointManager.Instance.CheckpointLocation.X > 0 && CheckpointManager.Instance.CheckpointLocation.Y > 0)
                {
                    CheckpointManager.Instance.ResetFromCheckpoint();
                }
                else
                {
                    WorldManager.Instance.Reset();
                }
            }
            else
            {
                WorldManager.Instance.GameOver();
            }
        }
    }
}
