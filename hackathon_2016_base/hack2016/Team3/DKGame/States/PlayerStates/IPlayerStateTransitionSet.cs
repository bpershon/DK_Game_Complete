using System;
namespace DKGame
{
	public interface IPlayerStateTransitionSet
	{
		void ToBarrelIdle(Player player);
		void ToBarrelJumping(Player player);
		void ToBarrelThrowing(Player player);
		void ToBarrelWalking(Player player);
        void ToBarrelFalling(Player player);

		void ToRambiCharge(Player player);
		void ToRambiDismount(Player player);
		void ToRambiRiding(Player player);
		void ToRambiJumping(Player player);
		void ToRambiIdle(Player player);
        void ToRambiFalling(Player player);

		void ToCrouching(Player player);
		void ToDead(Player player);
		void ToIdle(Player player);
		void ToJumping(Player player);
		void ToMount(Player player);
		void ToPickup(Player player);
		void ToRolling(Player player);
		void ToRunning(Player player);
		void ToWalking(Player player);
		void ToCharacterSwap(Player player);
        void ToBarrelThrown(Player player);
        void ToFalling(Player player);
        void ToWin(Player player);
	}
}
