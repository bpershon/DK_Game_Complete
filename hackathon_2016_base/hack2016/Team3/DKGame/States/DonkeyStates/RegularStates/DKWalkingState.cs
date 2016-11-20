namespace DKGame
{
    public class DKWalkingState : PlayerWalkingState
    {
        public DKWalkingState(Player player)
        {
			Setup(player, 
			      DKStateTransitionSet.Instance, 
			      PlayerSpriteFactory.Instance.CreateDKWalkSprite());
		}
    }
}
