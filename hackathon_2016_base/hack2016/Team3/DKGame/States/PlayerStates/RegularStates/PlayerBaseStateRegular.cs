using System;
using Microsoft.Xna.Framework;
namespace DKGame
{
	/**
	 * This class should serve as a basis for all regular states. 
	 * It should NOT be used on its own, but rather subclassed and completed.
	 **/
	public abstract class PlayerBaseStateRegular : PlayerBaseState, IPlayerState
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
			transitionSet.ToJumping(player);
		}

		public virtual void ProcessDown()
		{
			transitionSet.ToCrouching(player);
		}

        public virtual void PerformAction()
        {
			if (player.HasCollisionFlag(PlayerCollisionState.Barrel))
			{
				player.CollidingBarrel.State.ProcessCollected();
				transitionSet.ToPickup(player);
			}
			else 
			{
				transitionSet.ToRolling(player);
			}
        }

		public virtual void ChangePlayer()
		{
			transitionSet.ToCharacterSwap(player);
		}

		public virtual void Die()
		{
			transitionSet.ToDead(player);
		}

		public virtual void MountRambi()
		{
			transitionSet.ToMount(player);
			player.State.MountRambi();
		}

		public virtual void DismountRambi()
		{
			// No-Op
		}

        public virtual void HorizontalIdle()
        {
			player.HorizontalImpulse = 0.0f;
            transitionSet.ToIdle(player);
        }

        public virtual void VerticalIdle()
        {
            transitionSet.ToIdle(player);
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
