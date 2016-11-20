using Microsoft.Xna.Framework;
using System;

namespace DKGame
{
    public class DKThrownBarrelRollState : IItemState
    {

        private DKThrownBarrel item;

        public DKThrownBarrelRollState(DKThrownBarrel item)
        {
            this.item = item;
            item.Sprite = ItemSpriteFactory.Instance.CreateDKBarrelRollSprite();
            SoundPool.PlaySound(Sound.CollectibleBarrelRoll);
        }

        public void ProcessBreak()
        {
            item.State = new DKThrowBarrelBrokenState(item);
        }

        public void ProcessIdle()
        {
            //nop
        }

        public void ProcessCollected()
        {
            // nop
        }

        public void ProcessToggle()
        {
           //nop
        }

        public void Update()
        {
            item.Body.ApplyScaledImpulse(new Vector2(item.HorizontalImpulse, 0.0f));
        }
    }
}
