using Microsoft.Xna.Framework;
using System;
namespace DKGame
{
    public abstract class PlayerBJumpingState : PlayerBaseStateBarrel
    {
		private static readonly float JUMP_IMPULSE_MAG = -190.0f;
        private const double MOVEMENT_THRESHOLD = 0.0001;

        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
		{
			base.Setup(player, transitionSet, sprite);
			player.Body.ApplyScaledImpulse(new Vector2(0, JUMP_IMPULSE_MAG));
		}

		public override void ProcessUp()
		{
			//No-op, can't jump while jumping
		}

		public override void ChangePlayer()
		{
			//No-op, can't change players with barrel
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
					transitionSet.ToBarrelWalking(player);
				}
				else
				{
					transitionSet.ToBarrelIdle(player);
				}
			}
		}
    }
}
