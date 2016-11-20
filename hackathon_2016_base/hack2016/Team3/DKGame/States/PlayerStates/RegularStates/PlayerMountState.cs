namespace DKGame
{
    public abstract class PlayerMountState : PlayerTransitionState, ISpriteDelegate
    {
        private const double MOVEMENT_THRESHOLD = 0.001;

        public override void MountRambi()
        {
			transitionSet.ToRambiIdle(player);

			if (player.HorizontalImpulse > MOVEMENT_THRESHOLD)
			{
				player.State.ProcessRight();
			}
			else if (player.HorizontalImpulse < -MOVEMENT_THRESHOLD)
			{
				player.State.ProcessLeft();
			}
        }

        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
        {
            base.Setup(player, transitionSet, sprite);
            player.Sprite.AnimationDelegate = this;
        }

        public void SpriteAnimationFinished()
        {
            player.HorizontalImpulse = 0.0f;
            transitionSet.ToRambiRiding(player);
        }
    }
}
