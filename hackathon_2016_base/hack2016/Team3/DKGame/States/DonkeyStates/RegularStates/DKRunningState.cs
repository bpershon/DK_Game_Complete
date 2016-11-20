namespace DKGame
{
    public class DKRunningState : PlayerRunningState
    {
		public DKRunningState(Player player)
		{
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKRunSprite());
		}
    }
}
