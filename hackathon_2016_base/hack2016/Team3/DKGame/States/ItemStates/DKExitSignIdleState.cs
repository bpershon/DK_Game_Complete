using System;

namespace DKGame
{
    public class DKExitSignIdleState : IItemState
    {
        private DKExitSign item;

        public DKExitSignIdleState(DKExitSign item)
        {
            this.item = item;
            this.item.Sprite = ItemSpriteFactory.Instance.CreateDKExitSignSprite();
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
            item.State = new DKExitSignCollectedState(item);
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
