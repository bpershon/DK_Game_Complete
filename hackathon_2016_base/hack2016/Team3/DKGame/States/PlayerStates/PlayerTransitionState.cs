using System;
namespace DKGame
{
	/**
	 * This class is for transition states which just have a sprite by default, no movement options
	 **/
	public abstract class PlayerTransitionState : PlayerBaseState, IPlayerState
	{
		public virtual void ProcessLeft()
		{
			//No-op
		}

		public virtual void ProcessRight()
		{
			//No-op
		}

		public virtual void ProcessUp()
		{
			//No-op
		}

		public virtual void ProcessDown()
		{
			//No-op
		}

		public virtual void ChangePlayer()
		{
			//No-op
		}

		public virtual void Die()
		{
			//By default, you can die mid-transition
			transitionSet.ToDead(player);
		}

		public virtual void PerformAction()
		{
			//No-op
		}

		public virtual void MountRambi()
		{
			//No-op
		}

		public virtual void DismountRambi()
		{
			// No-Op
		}

        public virtual void HorizontalIdle()
        {
            //No-op
        }

        public virtual void VerticalIdle()
        {
            //No-op
        }

		public virtual void Update()
		{
			//No-op
		}
        public virtual void Win()
        {
            //By default, you can win mid-transition
            transitionSet.ToWin(player);
        }

        public virtual bool StateWinSideCol { get { return false; } }
    }
}
