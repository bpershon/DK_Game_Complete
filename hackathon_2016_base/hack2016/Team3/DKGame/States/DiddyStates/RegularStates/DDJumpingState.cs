namespace DKGame
{
    public class DDJumpingState : PlayerJumpingState
    {
        public DDJumpingState(Player player)
        {
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDJumpSprite());
		}
    }
}
