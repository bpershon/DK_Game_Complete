namespace DKGame
{
    public class DDRollingState : PlayerRollingState
    {
		public DDRollingState(Player player)
		{
			Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRollSprite());
		}
    }
}
