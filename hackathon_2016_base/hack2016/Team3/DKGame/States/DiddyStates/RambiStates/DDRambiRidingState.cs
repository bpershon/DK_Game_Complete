namespace DKGame
{
    public class DDRambiRidingState : PlayerRambiRidingState
    {
        public DDRambiRidingState(Player player)
        {
			//TODO: t175 - Add DDRidingWalkSprite
			Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRidingWalkSprite());
		}
    }
}
