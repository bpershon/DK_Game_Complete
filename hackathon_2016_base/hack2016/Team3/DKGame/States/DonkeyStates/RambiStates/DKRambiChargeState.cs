namespace DKGame
{
    public class DKRambiChargeState : PlayerRambiChargeState
    {
        public DKRambiChargeState(Player player)
        {
            //TODO: t175 - ADK DKRidingHitSprite
            Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKRidingHitSprite());
		}
    }
}
