using System;
using Microsoft.Xna.Framework;
namespace DKGame
{
	public abstract class PlayerBaseStateBarrel : PlayerBaseState, IPlayerState
	{
		protected const float DEFAULT_MOVING_IMPULSE = 50.0f;

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
			transitionSet.ToBarrelJumping(player);
		}

		public virtual void ProcessDown()
		{
			//No-op, can't crouch with barrel
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
            transitionSet.ToBarrelThrowing(player);
		}

		public virtual void MountRambi()
		{
			transitionSet.ToMount(player);
			player.State.MountRambi();
		}

		public virtual void DismountRambi()
		{
			// No-Op, can't dismount when you aren't on Rambi
		}

        public virtual void HorizontalIdle()
        {
			player.HorizontalImpulse = 0.0f;
            transitionSet.ToBarrelIdle(player);
        }

        public virtual void VerticalIdle()
        {
            transitionSet.ToBarrelIdle(player);
        }

		public virtual void Update()
		{
			player.Body.ApplyScaledImpulse(new Vector2(player.HorizontalImpulse, 0.0f));
		}

        public virtual void Win()
        {
            transitionSet.ToWin(player);
        }
        public virtual bool StateWinSideCol { get { return false; } }
    }
}
