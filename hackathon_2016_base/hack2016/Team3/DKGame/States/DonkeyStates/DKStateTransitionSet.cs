using System;
namespace DKGame
{
	public class DKStateTransitionSet : IPlayerStateTransitionSet
	{
		private static DKStateTransitionSet instance = new DKStateTransitionSet();

		public static DKStateTransitionSet Instance
		{
			get
			{
				return instance;
			}
		}

		public void ToBarrelIdle(Player player)
		{
			player.State = new DKBIdleState(player);
		}

		public void ToBarrelJumping(Player player)
		{
			player.State = new DKBJumpingState(player);
		}

		public void ToBarrelThrowing(Player player)
		{
			player.State = new DKBThrowingState(player);
		}

        public void ToBarrelThrown(Player player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateDKBarrelThrowPt2Sprite();
        }

		public void ToBarrelWalking(Player player)
		{
			player.State = new DKBWalkingState(player);
		}

        public void ToBarrelFalling(Player player)
        {
            player.State = new DKBFallingState(player);
        }

		public void ToRambiCharge(Player player)
		{
			player.State = new DKRambiChargeState(player);
		}

		public void ToRambiDismount(Player player)
		{
			player.State = new DKRambiDismountState(player);
		}

		public void ToRambiRiding(Player player)
		{
			player.State = new DKRambiRidingState(player);
		}

		public void ToRambiJumping(Player player)
		{
			player.State = new DKRambiJumpingState(player);
		}

		public void ToRambiIdle(Player player)
		{
			player.State = new DKRambiIdleState(player);
		}

        public void ToRambiFalling(Player player)
        {
            player.State = new DKRambiFallingState(player);
        }

		public void ToCrouching(Player player)
		{
			player.State = new DKCrouchingState(player);
		}

		public void ToDead(Player player)
		{
			player.State = new DKDeadState(player);
		}

		public void ToIdle(Player player)
		{
			player.State = new DKIdleState(player);
		}

		public void ToJumping(Player player)
		{
			player.State = new DKJumpingState(player);
		}

		public void ToMount(Player player)
		{
			player.State = new DKMountState(player);
		}

		public void ToPickup(Player player)
		{
			player.State = new DKPickupState(player);
		}

		public void ToRolling(Player player)
		{
			player.State = new DKRollingState(player);
		}

		public void ToRunning(Player player)
		{
			player.State = new DKRunningState(player);
		}

		public void ToWalking(Player player)
		{
			player.State = new DKWalkingState(player);
		}

		public void ToCharacterSwap(Player player)
		{
			player.State = new DDIdleState(player);
		}

        public void ToFalling(Player player)
        {
            player.State = new DKFallingState(player);
        }

        public void ToWin(Player player)
        {
            player.State = new DKWinState(player);
        }
	}
}
