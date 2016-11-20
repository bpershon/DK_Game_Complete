using System;

namespace DKGame
{
    public class DKKongTileIdleState : IItemState
    {
        private DKKongTile item;

        public DKKongTileIdleState(DKKongTile item)
        {
            this.item = item;
            //item.Sprite = ItemSpriteFactory.Instance.CreateDKKongTileSprite();
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
            item.State = new DKKongTileCollectedState(item);
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
