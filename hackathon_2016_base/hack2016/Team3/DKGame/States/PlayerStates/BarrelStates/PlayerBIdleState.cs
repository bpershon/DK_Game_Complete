namespace DKGame
{
    public abstract class PlayerBIdleState : PlayerBaseStateBarrel
    {
        private const int FALLING_THRESHOLD = 40;

        public override void ProcessLeft()
        {
            transitionSet.ToBarrelWalking(player);
			player.State.ProcessLeft();
        }

        public override void ProcessRight()
        {
            transitionSet.ToBarrelWalking(player);
			player.State.ProcessRight();
        }

        public override void VerticalIdle()
        {
            //No-op
        }

        public override void Update()
        {
            base.Update();

            if (!player.HasCollisionFlag(PlayerCollisionState.Ground) && player.Body.Velocity.Y > FALLING_THRESHOLD)
            {
                transitionSet.ToBarrelFalling(player);
            }
        }
    }
}
