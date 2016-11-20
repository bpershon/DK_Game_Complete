namespace DKGame
{
    public class DDCrouchingState : PlayerCrouchingState
    {
        public DDCrouchingState(Player player)
        {
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDCrouchSprite());
		}
    }
}
