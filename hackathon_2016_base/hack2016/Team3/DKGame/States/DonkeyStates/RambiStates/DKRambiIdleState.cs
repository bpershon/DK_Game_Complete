namespace DKGame
{
	public class DKRambiIdleState : PlayerRambiIdleState
	{
		public DKRambiIdleState(Player player)
		{
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKRidingIdleSprite());
		}
	}
}
