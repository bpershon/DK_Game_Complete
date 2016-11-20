namespace DKGame
{
    public class DKIdleState : PlayerIdleState
    {
        public DKIdleState(Player player)
        {
            Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKIdleSprite());
		}
    }
}
