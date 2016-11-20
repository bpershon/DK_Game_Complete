using System;

namespace DKGame
{
    public class DKPlayerBarrelIdleState : IItemState
    {
        private DKPlayerBarrel item;

        public DKPlayerBarrelIdleState(DKPlayerBarrel item)
        {
            this.item = item;
            item.Sprite = ItemSpriteFactory.Instance.CreateDKPlayerBarrelSprite();
        }

        public void ProcessBreak()
        {
            //break / roll
            item.State = new DKPlayerBarrelRollState(item);
        }

        public void ProcessIdle()
        {
            // nop
        }

        public void ProcessCollected()
        {
            //Barrel is no longer its own item
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
