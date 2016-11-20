using System;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class DKBananaGroupCollectedState : IItemState
    {
        private DKBananaGroup item;
        private const int X_COLLECTED_SPEED = -150;
        private const int Y_COLLECTED_SPEED = -200;

        public DKBananaGroupCollectedState(DKBananaGroup item)
        {
            this.item = item;
            item.Body.Velocity = new Vector2(X_COLLECTED_SPEED, Y_COLLECTED_SPEED);
            ScoreSystem.addBananas(10);
            SoundPool.PlaySound(Sound.CollectibleBananaGroup);
            //Should probably have some form of garbage collection for collectibles off the screen to pull them from WM & PW
            //PhysicsWorld.Instance.DestroyBody(this.item.Body); 
            //WorldManager.RemoveObject(this.item);
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
