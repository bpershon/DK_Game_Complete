namespace DKGame
{
    public class DKBIdleState : PlayerBIdleState
    {
        public DKBIdleState(Player player)
        {
           Setup(player,
				 DKStateTransitionSet.Instance,
				 PlayerSpriteFactory.Instance.CreateDKBarrelIdleSprite());
		}
    }
}
