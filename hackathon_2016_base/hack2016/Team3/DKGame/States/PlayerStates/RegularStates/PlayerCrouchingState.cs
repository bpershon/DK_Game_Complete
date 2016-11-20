using Microsoft.Xna.Framework;

namespace DKGame
{
    public abstract class PlayerCrouchingState : PlayerBaseStateRegular
    {
		protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
		{
			base.Setup(player, transitionSet, sprite);
			this.player.Body.Velocity = new Vector2(0.0f, this.player.Body.Velocity.Y);
			this.player.HorizontalImpulse = 0.0f;
		}

        public override void ProcessLeft()
        {
            //Crouched Player doesn't move left
        }

        public override void ProcessRight()
        {
            //Crouched Player doesn't move right
        }

        public override void ProcessDown()
        {
            // Down has no effect on crouched Player
        }
        public override void HorizontalIdle()
        {
            //No-op
        }
    }
}
