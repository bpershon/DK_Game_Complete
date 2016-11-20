namespace DKGame
{
    public class DDIdleState : PlayerIdleState
    {
        public DDIdleState(Player player)
        {
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDIdleSprite());
		}
    }
}
