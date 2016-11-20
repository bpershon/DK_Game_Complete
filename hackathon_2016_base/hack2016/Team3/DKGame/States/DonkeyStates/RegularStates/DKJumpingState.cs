namespace DKGame
{
	public class DKJumpingState : PlayerJumpingState
	{
		public DKJumpingState(Player player)
		{
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKJumpSprite());
		}
	}
}
