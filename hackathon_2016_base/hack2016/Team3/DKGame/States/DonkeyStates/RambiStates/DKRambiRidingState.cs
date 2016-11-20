namespace DKGame
{
    public class DKRambiRidingState : PlayerRambiRidingState
    {
        public DKRambiRidingState(Player player)
        {
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKRidingWalkSprite());
		}
    }
}
