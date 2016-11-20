using System;

namespace DKGame
{
    public class DKPlayerBarrelRollState : IItemState
    {
        private DKPlayerBarrel item;

        public DKPlayerBarrelRollState(DKPlayerBarrel item)
        {
            this.item = item;
            item.Sprite = ItemSpriteFactory.Instance.CreateDKBarrelRollSprite();
        }

        public void ProcessBreak()
        {
            // nop
        }

        public void ProcessIdle()
        {
            item.State = new DKPlayerBarrelIdleState(item);
            item.Sprite = ItemSpriteFactory.Instance.CreateDKPlayerBarrelSprite();
        }

        public void ProcessCollected()
        {
            // nop
        }

        public void ProcessToggle()
        {
            ProcessIdle();
        }

        public void Update()
        {
           //nop
        }
    }
}
