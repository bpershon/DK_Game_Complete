namespace DKGame
{
    public class DDWalkingState : PlayerWalkingState
    {
        public DDWalkingState(Player player)
        {
			Setup(player, 
			      DDStateTransitionSet.Instance, 
			      PlayerSpriteFactory.Instance.CreateDDWalkSprite());
		}
    }
}
