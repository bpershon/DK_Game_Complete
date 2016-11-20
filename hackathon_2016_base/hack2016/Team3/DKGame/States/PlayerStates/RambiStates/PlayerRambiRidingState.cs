using Microsoft.Xna.Framework;

namespace DKGame
{
    public abstract class PlayerRambiRidingState : PlayerBaseStateRambi
    {
        private const int FALLING_THRESHOLD = 40;

        protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
        {
            base.Setup(player, transitionSet, sprite);
        }

        public override void ChangePlayer()
        {
            transitionSet.ToRambiDismount(player);
        }

        public override void Update()
        {
            base.Update();

            if (!player.HasCollisionFlag(PlayerCollisionState.Ground) && player.Body.Velocity.Y > FALLING_THRESHOLD)
            {
                transitionSet.ToRambiFalling(player);
            }
        }

    }
}
