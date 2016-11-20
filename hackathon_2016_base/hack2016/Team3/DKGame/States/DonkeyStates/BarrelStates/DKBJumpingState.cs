namespace DKGame
{
	public class DKBJumpingState : PlayerBJumpingState
	{
		public DKBJumpingState(Player player)
		{
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKBarrelJumpSprite());
		}
    }
}
