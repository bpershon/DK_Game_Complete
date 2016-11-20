using System;

namespace DKGame
{
    public class RambiIdleState : IItemState
    {
        private Rambi item;

        public RambiIdleState(Rambi item)
        {
            this.item = item;
            //this.item.Sprite = ItemSpriteFactory.Instance.CreateRambiSprite();
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
            item.State = new RambiCollectedState(item);
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
