namespace DKGame
{
    public class DKBWalkingState : PlayerBWalkingState
    {
        public DKBWalkingState(Player player)
        {
            Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKBarrelWalkSprite());
		}
    }
}
