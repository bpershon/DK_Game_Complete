namespace DKGame
{
    public class DKCrouchingState : PlayerCrouchingState
    {
        public DKCrouchingState(Player player)
        {
            Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKCrouchSprite());
		}
    }
}
