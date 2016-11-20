using System;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class RambiCollectedState : IItemState
    {
        private Rambi item;

        public RambiCollectedState(Rambi item)
        {
            this.item = item;
            //Temporary for sprint 3
            PhysicsWorld.Instance.DestroyBody(this.item.Body);
            WorldManager.Instance.RemoveObject(this.item);
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
