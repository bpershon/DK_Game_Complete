namespace DKGame
{
    public class DDRunningState : PlayerRunningState
    {
		public DDRunningState(Player player)
		{
			Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRunSprite());
		}
    }
}
