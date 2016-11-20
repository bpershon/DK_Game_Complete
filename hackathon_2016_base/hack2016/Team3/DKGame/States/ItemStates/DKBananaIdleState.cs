using System;

namespace DKGame
{
    public class DKBananaIdleState : IItemState
    {
        private DKBanana item;

        public DKBananaIdleState(DKBanana item)
        {
            this.item = item;
            this.item.Sprite = ItemSpriteFactory.Instance.CreateDKBananaSprite();
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
            item.State = new DKBananaCollectedState(item);
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
