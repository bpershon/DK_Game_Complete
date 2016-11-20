namespace DKGame
{
    public class DDPickupState : PlayerPickupState
    {
		public DDPickupState(Player player)
		{
			Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDBarrelPickupSprite());
		}
    }
}
