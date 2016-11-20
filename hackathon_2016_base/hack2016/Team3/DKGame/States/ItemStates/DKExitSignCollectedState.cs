using System;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class DKExitSignCollectedState : IItemState
    {

        public DKExitSignCollectedState(DKExitSign item)
        {
            WorldManager.Instance.Win();
        }

        public void ProcessBreak()
        {
            // nop
        }

        public void ProcessIdle()
        {
            // nop
        }

        public void ProcessCollected()
        {
            // nop
        }
        public void ProcessToggle()
        {
            //nop
        }

        public void Update()
        {
            //nop
        }
    }
}
