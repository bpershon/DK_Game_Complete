using System;

namespace DKGame
{
    public class DKBananaGroupIdleState : IItemState
    {
        private DKBananaGroup item;

        public DKBananaGroupIdleState(DKBananaGroup item)
        {
            this.item = item;
            item.Sprite = ItemSpriteFactory.Instance.CreateDKBananaGroupSprite();
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
            item.State = new DKBananaGroupCollectedState(item);
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
