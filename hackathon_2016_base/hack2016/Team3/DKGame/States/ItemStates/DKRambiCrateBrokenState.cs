using System;

namespace DKGame
{
    public class DKRambiCrateBrokenState : IItemState, ISpriteDelegate
    {
        private DKRambiCrate item;

        public DKRambiCrateBrokenState(DKRambiCrate item)
        {
            this.item = item;
            item.Sprite = ItemSpriteFactory.Instance.CreateDKRambiCrateOpeningSprite();
            item.Sprite.AnimationDelegate = this;
            SoundPool.PlaySound(Sound.RambiCrateOpen);
        }

        public void ProcessBreak()
        {
            item.Sprite = ItemSpriteFactory.Instance.CreateDKRambiCrateOpenedSprite();
        }

        public void ProcessIdle()
        {
            item.State = new DKRambiCrateIdleState(item);
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

        public void SpriteAnimationFinished()
        {
            ProcessBreak();
        }
    }
}
