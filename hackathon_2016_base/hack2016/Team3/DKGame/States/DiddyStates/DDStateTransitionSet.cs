using System;
namespace DKGame
{
	public class DDStateTransitionSet : IPlayerStateTransitionSet
	{
		private static DDStateTransitionSet instance = new DDStateTransitionSet();

		public static DDStateTransitionSet Instance
		{
			get
			{
				return instance;
			}
		}

		public void ToBarrelIdle(Player player)
		{
			player.State = new DDBIdleState(player);
		}

		public void ToBarrelJumping(Player player)
		{
			player.State = new DDBJumpingState(player);
		}

		public void ToBarrelThrowing(Player player)
		{
			player.State = new DDBThrowingState(player);
		}

        public void ToBarrelThrown(Player player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateDDBarrelThrowPt2Sprite();
        }

		public void ToBarrelWalking(Player player)
		{
			player.State = new DDBWalkingState(player);
		}

        public void ToBarrelFalling(Player player)
        {
            player.State = new DDBFallingState(player);
        }

        public void ToRambiCharge(Player player)
		{
			player.State = new DDRambiChargeState(player);
		}

		public void ToRambiDismount(Player player)
		{
			player.State = new DDRambiDismountState(player);
		}

		public void ToRambiRiding(Player player)
		{
			player.State = new DDRambiRidingState(player);
		}

		public void ToRambiJumping(Player player)
		{
			player.State = new DDRambiJumpingState(player);
		}

		public void ToRambiIdle(Player player)
		{
			player.State = new DDRambiIdleState(player);
		}

        public void ToRambiFalling(Player player)
        {
            player.State = new DKRambiFallingState(player);
        }

        public void ToCrouching(Player player)
		{
			player.State = new DDCrouchingState(player);
		}

		public void ToDead(Player player)
		{
			player.State = new DDDeadState(player);
		}

		public void ToIdle(Player player)
		{
			player.State = new DDIdleState(player);
		}

		public void ToJumping(Player player)
		{
			player.State = new DDJumpingState(player);
		}

		public void ToMount(Player player)
		{
			player.State = new DDMountState(player);
		}

		public void ToPickup(Player player)
		{
			player.State = new DDPickupState(player);
		}

		public void ToRolling(Player player)
		{
			player.State = new DDRollingState(player);
		}

		public void ToRunning(Player player)
		{
			player.State = new DDRunningState(player);
		}

		public void ToWalking(Player player)
		{
			player.State = new DDWalkingState(player);
		}

		public void ToCharacterSwap(Player player)
		{
			player.State = new DKIdleState(player);
		}

        public void ToFalling(Player player)
        {
            player.State = new DDFallingState(player);
        }

        public void ToWin(Player player)
        {
            player.State = new DDWinState(player);
        }
    }
}
