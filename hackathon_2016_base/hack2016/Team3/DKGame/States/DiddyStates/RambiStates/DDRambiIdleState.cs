namespace DKGame
{
	public class DDRambiIdleState : PlayerRambiIdleState
	{
		public DDRambiIdleState(Player player)
		{
			Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRidingIdleSprite());
		}
	}
}
