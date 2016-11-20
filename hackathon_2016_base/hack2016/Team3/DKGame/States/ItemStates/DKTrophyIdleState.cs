using System;

namespace DKGame
{
    public class DKTrophyIdleState : IItemState
    {
        private DKTrophy item;

        public DKTrophyIdleState(DKTrophy item)
        {
            this.item = item;
            this.item.Sprite = ItemSpriteFactory.Instance.CreateDKTrophySprite();
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
            item.State = new DKTrophyCollectedState(item);
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
