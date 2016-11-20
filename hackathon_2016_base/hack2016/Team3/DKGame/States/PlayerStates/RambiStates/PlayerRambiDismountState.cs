namespace DKGame
{
    public abstract class PlayerRambiDismountState : PlayerTransitionState, ISpriteDelegate
    {
        public override void DismountRambi()
        {
            transitionSet.ToIdle(player);
        }

        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
        {
            base.Setup(player, transitionSet, sprite);
            player.Sprite.AnimationDelegate = this;
        }

        public void SpriteAnimationFinished()
        {
            transitionSet.ToIdle(player);
        }
    }
}
