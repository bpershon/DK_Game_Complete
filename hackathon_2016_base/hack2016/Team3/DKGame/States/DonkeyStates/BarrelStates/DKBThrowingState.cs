namespace DKGame
{
    public class DKBThrowingState : PlayerBThrowingState
    {
		public DKBThrowingState(Player player)
		{
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKBarrelThrowPt1Sprite());
		}
    }
}
