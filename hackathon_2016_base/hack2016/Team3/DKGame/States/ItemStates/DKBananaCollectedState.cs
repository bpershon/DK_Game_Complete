using System;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class DKBananaCollectedState : IItemState
    {
        private DKBanana item;
        private const int X_COLLECTED_SPEED = -150;
        private const int Y_COLLECTED_SPEED = -200;

        public DKBananaCollectedState(DKBanana item)
        {
            this.item = item;
            ScoreSystem.addBananas(1);
            SoundPool.PlaySound(Sound.CollectibleBanana);
            item.Body.Velocity = new Vector2(X_COLLECTED_SPEED, Y_COLLECTED_SPEED);
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
            // nop
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
