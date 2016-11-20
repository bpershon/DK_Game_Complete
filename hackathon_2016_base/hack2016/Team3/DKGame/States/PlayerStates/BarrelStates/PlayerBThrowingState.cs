using System;

namespace DKGame
{
    public abstract class PlayerBThrowingState : PlayerTransitionState, ISpriteDelegate
    {
        private const int THROW_DISPLACEMENT = -20;

        private Boolean thrown = false;
        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
        {
            base.Setup(player, transitionSet, sprite);
            player.Sprite.AnimationDelegate = this;
        }

        public override void VerticalIdle()
        {
            //No-op
        }

        public void SpriteAnimationFinished()
        {
            if (thrown)
            {
                transitionSet.ToIdle(player);
            }
            else
            {
                transitionSet.ToBarrelThrown(player);
                player.Sprite.AnimationDelegate = this;
                thrown = true;
                
                int direction = -1;
                if (player.FacingRight) { direction *= -1; }
                player.HorizontalImpulse = 0.0f;

                DKThrownBarrel thrownBarrel = new DKThrownBarrel();
                thrownBarrel.HorizontalImpulse *= direction;
                thrownBarrel.Body.BottomCenter = player.Body.BottomCenter + new Microsoft.Xna.Framework.Vector2(0, THROW_DISPLACEMENT);
                WorldManager.Instance.AddObject(thrownBarrel);
            }
        }
        public override bool StateWinSideCol { get { return true; } }
    }
}
