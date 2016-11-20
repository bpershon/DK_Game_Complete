using System;
namespace DKGame
{
	public class PlayerRambiIdleState : PlayerBaseStateRambi
	{
        private const int FALLING_THRESHOLD = 40;

        public override void ProcessLeft()
		{
			transitionSet.ToRambiRiding(player);
			player.State.ProcessLeft();
		}

		public override void ProcessRight()
		{
			transitionSet.ToRambiRiding(player);
			player.State.ProcessRight();
		}

		public override void VerticalIdle()
		{
			// No-op
		}

        public override void ChangePlayer()
        {
            transitionSet.ToRambiDismount(player);
        }

        public override void Update()
        {
            base.Update();

            if (!player.HasCollisionFlag(PlayerCollisionState.Ground) && player.Body.Velocity.Y > FALLING_THRESHOLD)
            {
                transitionSet.ToRambiFalling(player);
            }
        }
    }
}
