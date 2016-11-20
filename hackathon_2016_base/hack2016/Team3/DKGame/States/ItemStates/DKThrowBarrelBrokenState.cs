using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    class DKThrowBarrelBrokenState : IItemState
    {
        private DKThrownBarrel item;

        public DKThrowBarrelBrokenState(DKThrownBarrel item)
        {
            this.item = item;
            //Cant move an object with no body, will need another movmement scheme if we implement
            //item.Body.ApplyImpulse(new Vector2(-2, -1));
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
