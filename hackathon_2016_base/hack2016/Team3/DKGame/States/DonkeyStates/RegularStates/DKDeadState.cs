namespace DKGame
{
    public class DKDeadState : PlayerDeadState
    {
        public DKDeadState(Player player)
        {
			Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKDeadSprite());
            SoundPool.PlaySound(Sound.PlayerDKHit);
		}
    }
}
