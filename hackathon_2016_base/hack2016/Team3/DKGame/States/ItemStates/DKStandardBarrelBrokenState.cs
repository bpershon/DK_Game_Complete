using System;

namespace DKGame
{
    public class DKStandardBarrelBrokenState : IItemState
    {
        private DKStandardBarrel item;

        public DKStandardBarrelBrokenState(DKStandardBarrel item)
        {
            this.item = item;
            item.Sprite = ItemSpriteFactory.Instance.CreateDKStandardBarrelBrokenSprite();
            SoundPool.PlaySound(Sound.CollectibleBarrelBreak);
        }

        public void ProcessBreak()
        {
            // nop
        }

        public void ProcessIdle()
        {
            item.State = new DKStandardBarrelIdleState(item);
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
