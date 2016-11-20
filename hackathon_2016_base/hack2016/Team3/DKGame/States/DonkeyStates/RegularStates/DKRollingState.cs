namespace DKGame
{
    public class DKRollingState : PlayerRollingState
    {
		public DKRollingState(Player player)
		{
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKRollSprite());
		}
    }
}
