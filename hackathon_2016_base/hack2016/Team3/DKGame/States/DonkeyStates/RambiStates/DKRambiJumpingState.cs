namespace DKGame
{
	public class DKRambiJumpingState : PlayerRambiJumpingState
	{
		public DKRambiJumpingState(Player player)
		{
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKRidingJumpSprite());
		}
	}
}
