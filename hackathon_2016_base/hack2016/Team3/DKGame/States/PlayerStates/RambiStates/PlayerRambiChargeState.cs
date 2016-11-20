namespace DKGame
{
    public abstract class PlayerRambiChargeState : PlayerBaseStateRambi, ISpriteDelegate
    {
		protected override void Setup(Player player, IPlayerStateTransitionSet transitionSet, ISprite sprite)
		{
			base.Setup(player, transitionSet, sprite);
			player.Sprite.AnimationDelegate = this;
            SoundPool.PlaySound(Sound.RambiAttack);
		}

		public override void PerformAction()
		{
			//No-op
		}

		public override void DismountRambi()
		{
			//No-op, can't dismount while charging
		}

		public override void HorizontalIdle()
		{
			//No-op, player shouldn't idle until charge is finished
		}

		public void SpriteAnimationFinished()
		{
			player.HorizontalImpulse = 0.0f;
			transitionSet.ToRambiIdle(player);
		}
    }
}
