
using Microsoft.Xna.Framework;
/**
* THIS FILE WAS GENERATED USING Scripts/statecreator.py
* PLEASE USE THE SCRIPT TO GENERATE OTHER SUCH FILES, DO NOT CREATE THEM MANUALLY
**/
namespace DKGame
{
    public abstract class PlayerWinState : PlayerBaseStateRegular, ISpriteDelegate
    {
        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
        {
            base.Setup(player, transitionSet, sprite);
            this.player.Body.Velocity = Vector2.Zero;
            this.player.HorizontalImpulse = 0.0f;
            player.Sprite.AnimationDelegate = this;
        }

        public override void ProcessLeft()
        {
            // No-Op
        }

        public override void ProcessRight()
        {
            // No-Op
        }

        public override void ProcessUp()
        {
            // No-Op
        }

        public override void ProcessDown()
        {
            // No-Op
        }

        public override void ChangePlayer()
        {
            // No-Op
        }

        public override void Die()
        {
            // No-Op
        }

        public override void PerformAction()
        {
            // No-Op
        }

        public override void MountRambi()
        {
            // No-Op
        }

        public override void DismountRambi()
        {
            // No-Op
        }

        public override void HorizontalIdle()
        {
            // No-op
        }

        public override void VerticalIdle()
        {
            // No-op
        }

        public void SpriteAnimationFinished()
        {
            WorldManager.Instance.Reset();
        }
    }
}
