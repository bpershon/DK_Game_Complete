using System;
using Microsoft.Xna.Framework;
namespace DKGame
{
	public abstract class PlayerBaseStateRambi : PlayerBaseState, IPlayerState
	{
		protected const float DEFAULT_MOVING_IMPULSE = 100.0f;

		public virtual void ProcessLeft()
		{
			player.FacingRight = false;
			player.HorizontalImpulse = -DEFAULT_MOVING_IMPULSE;
		}

		public virtual void ProcessRight()
		{
			player.FacingRight = true;
			player.HorizontalImpulse = DEFAULT_MOVING_IMPULSE;
		}

		public virtual void ProcessUp()
		{
			transitionSet.ToRambiJumping(player);
		}

		public virtual void ProcessDown()
		{
			//No-op, can't crouch with rambi
		}

		public virtual void ChangePlayer()
		{
			//No-op for now
		}

		public virtual void Die()
		{
			transitionSet.ToDead(player);
		}

		public virtual void PerformAction()
		{
			//Rolling with rambi = charge
			transitionSet.ToRambiCharge(player);
			player.State.PerformAction();
		}

		public virtual void MountRambi()
		{
			//No-op, can't mount rambi while on rambi
		}

		public virtual void DismountRambi()
		{
			transitionSet.ToRambiDismount(player);
		}

        public virtual void HorizontalIdle()
        {
			player.HorizontalImpulse = 0.0f;
			transitionSet.ToRambiIdle(player);
        }

        public virtual void VerticalIdle()
        {
           //No-op
        }

		public virtual void Update()
		{
			player.Body.ApplyScaledImpulse(new Vector2(player.HorizontalImpulse, 0.0f));
        }

        public virtual void Win()
        {
            transitionSet.ToWin(player);
        }
        public bool StateWinSideCol { get {return true; } }
    }
}
