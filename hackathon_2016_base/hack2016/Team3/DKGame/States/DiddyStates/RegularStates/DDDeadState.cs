namespace DKGame
{
    public class DDDeadState : PlayerDeadState
    {
        public DDDeadState(Player player)
        {
			Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDDeadSprite());
            SoundPool.PlaySound(Sound.PlayerDDHit);
		}
    }
}
