using System;

namespace DKGame
{
    public class DKRambiCrateIdleState : IItemState
    {
        private DKRambiCrate item;

        public DKRambiCrateIdleState(DKRambiCrate item)
        {
            this.item = item;
            item.Sprite = ItemSpriteFactory.Instance.CreateDKRambiCrateUnopenedSprite();
        }

        public void ProcessBreak()
        {
            item.State = new DKRambiCrateBrokenState(item);
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
            ProcessBreak();
        }

        public void Update()
        {
            //nop
        }
    }
}
