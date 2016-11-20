using Microsoft.Xna.Framework;

namespace DKGame
{
    public abstract class PlayerIdleState : PlayerBaseStateRegular
    {
        private const int FALLING_THRESHOLD = 40;

        public override void ProcessLeft()
        {
            transitionSet.ToWalking(player);
            player.State.ProcessLeft();
        }

        public override void ProcessRight()
        {
			transitionSet.ToWalking(player);
            player.State.ProcessRight();
        }

        public override void HorizontalIdle()
        {
            // No-Op
        }

        public override void VerticalIdle()
        {
            // No-op
        }

        public override void Update()
        {
            base.Update();

            if (!player.HasCollisionFlag(PlayerCollisionState.Ground) && player.Body.Velocity.Y > FALLING_THRESHOLD)
            {
                transitionSet.ToFalling(player);
            }
        }
    }
}
