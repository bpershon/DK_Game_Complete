namespace DKGame
{
    public abstract class PlayerPickupState : PlayerTransitionState, ISpriteDelegate
    {
        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
		{
			base.Setup(player, transitionSet, sprite);
			player.Sprite.AnimationDelegate = this;
		}

		public void SpriteAnimationFinished()
		{
			transitionSet.ToBarrelIdle(player);
		}

        public override bool StateWinSideCol { get { return true; } }
    }
}
