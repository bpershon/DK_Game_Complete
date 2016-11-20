using Microsoft.Xna.Framework;
using System;

namespace DKGame
{
    public abstract class PlayerJumpingState : PlayerBaseStateRegular
    {
		private static readonly float JUMP_IMPULSE_MAG = -190.0f;
        private const double MOVEMENT_THRESHOLD = 0.0001;

        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
		{
			base.Setup(player, transitionSet, sprite);
			player.Body.ApplyScaledImpulse(new Vector2(0.0f, JUMP_IMPULSE_MAG));
		}

		public override void ProcessUp()
		{
			// No-op, can't jump while jumping (double jump)
		}

        public override void ProcessDown()
        {
            // No-Op, can't crouch while jumping
        }

        public override void ChangePlayer()
        {
            // No-Op, can't change players while jumping
        }

        public override void PerformAction()
        {
            // No-Op, can't roll while jumping
        }

        public override void HorizontalIdle()
        {
			player.HorizontalImpulse = 0.0f;
        }

        public override void VerticalIdle()
        {
            //TODO: Zero player Y velocity so gravity can start pulling him down (short hop mechanic)
        }

		public override void Update()
		{
			base.Update();
			if (player.HasCollisionFlag(PlayerCollisionState.Ground))
			{
				if (Math.Abs(player.HorizontalImpulse) > MOVEMENT_THRESHOLD)
				{
					transitionSet.ToWalking(player);
				}
				else
				{
					transitionSet.ToIdle(player);
				}
			}
		}
    }
}
