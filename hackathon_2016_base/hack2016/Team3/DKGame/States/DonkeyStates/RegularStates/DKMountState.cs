namespace DKGame
{
    public class DKMountState : PlayerMountState
    {
        public DKMountState(Player player)
        {
            Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKRidingIdleSprite());
		}
    }
}
