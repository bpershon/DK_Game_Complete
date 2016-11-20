using Microsoft.Xna.Framework;

namespace DKGame
{
    public abstract class PlayerWalkingState : PlayerBaseStateRegular
    {
        private const int FALLING_THRESHOLD = 40;

        public override void VerticalIdle()
        {
            //No-op
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
