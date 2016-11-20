using System;

namespace DKGame
{
    public class DKStandardBarrelIdleState : IItemState
    {
        private DKStandardBarrel item;

        public DKStandardBarrelIdleState(DKStandardBarrel item)
        {
            this.item = item;
            item.Sprite = ItemSpriteFactory.Instance.CreateDKStandardBarrelSprite();
        }

        public void ProcessBreak()
        {
            item.State = new DKStandardBarrelBrokenState(item);
        }

        public void ProcessIdle()
        {
            // nop
        }

        public void ProcessCollected()
        {
            PhysicsWorld.Instance.DestroyBody(this.item.Body);
            WorldManager.Instance.RemoveObject(this.item);
        }

        public void ProcessToggle()
        {
            ProcessBreak();
        }

        public void Update()
        {
            //nop
        }
    }
}
