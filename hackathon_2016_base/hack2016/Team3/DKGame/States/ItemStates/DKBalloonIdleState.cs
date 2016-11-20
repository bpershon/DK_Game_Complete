using System;

namespace DKGame
{
    public class DKBalloonIdleState : IItemState
    {
        private DKBalloon item;

        public DKBalloonIdleState(DKBalloon item)
        {
            this.item = item;
            this.item.Sprite = ItemSpriteFactory.Instance.CreateDKBalloonSprite();
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
            item.State = new DKBalloonCollectedState(item);
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
