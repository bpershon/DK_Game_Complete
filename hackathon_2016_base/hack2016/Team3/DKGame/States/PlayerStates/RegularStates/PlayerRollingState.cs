using System;

namespace DKGame
{
    public abstract class PlayerRollingState : PlayerBaseStateRegular, ISpriteDelegate
    {
        private const int FALLING_THRESHOLD = 40;

        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
		{
			base.Setup(player, transitionSet, sprite);
			player.Sprite.AnimationDelegate = this;
		}

        public override void ProcessDown()
        {
            //No-op, can't crouch while rolling
        }

        public override void PerformAction()
        {
            //No-op, can't roll while rolling
        }

        public override void HorizontalIdle()
        {
            //No-op, player shouldn't idle until roll is finished (assumedly some friction will handle slowing?)
        }

        public override void VerticalIdle()
        {
            //No-op
        }

		public void SpriteAnimationFinished()
		{
			player.HorizontalImpulse = 0.0f;
			transitionSet.ToIdle(player);
		}

        public override void Update()
        {
            base.Update();

            if (!player.HasCollisionFlag(PlayerCollisionState.Ground) && player.Body.Velocity.Y > FALLING_THRESHOLD)
            {
                transitionSet.ToFalling(player);
            }
        }

        public override bool StateWinSideCol { get { return true; } }
    }
}
