namespace DKGame
{
    public class DDMountState : PlayerMountState
    {
        public DDMountState(Player player)
        {
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRidingWalkSprite());
		}
    }
}
