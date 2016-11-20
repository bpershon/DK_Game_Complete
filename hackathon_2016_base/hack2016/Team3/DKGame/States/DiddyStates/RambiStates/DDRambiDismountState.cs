namespace DKGame
{
    public class DDRambiDismountState : PlayerRambiDismountState
    {
        public DDRambiDismountState(Player player)
        {
            //should have dk rambi dismount sprite??
            //Need to have player be idle again and respawn the rambi item -brad
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRidingDismountSprite());
		}
    }
}
