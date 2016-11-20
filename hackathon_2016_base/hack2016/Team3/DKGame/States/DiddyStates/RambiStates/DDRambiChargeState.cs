namespace DKGame
{
    public class DDRambiChargeState : PlayerRambiChargeState
    {
        public DDRambiChargeState(Player player)
        {
            //TODO: t175 - Add DDRidingHitSprite
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRidingHitSprite());
		}
    }
}
