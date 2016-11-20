namespace DKGame
{
    public class DDRambiJumpingState : PlayerRambiJumpingState
    {
        public DDRambiJumpingState(Player player)
        {
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRidingJumpSprite());
		} 
    }
}
