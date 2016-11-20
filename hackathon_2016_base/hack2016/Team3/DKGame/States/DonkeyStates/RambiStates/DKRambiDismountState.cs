namespace DKGame
{
    public class DKRambiDismountState : PlayerRambiDismountState
    {
        public DKRambiDismountState(Player player)
        {
            //should have dk rambi dismount sprite??
            //Need to have player be idle again and respawn the rambi item -brad
            Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKIdleSprite());
		}
    }
}
