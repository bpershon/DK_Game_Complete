namespace DKGame
{
    public class DKPickupState : PlayerPickupState
    {
		public DKPickupState(Player player)
		{
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKBarrelPickupSprite());
		}
    }
}
