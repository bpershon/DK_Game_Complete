using System;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class DKBalloonCollectedState : IItemState
    {
        private DKBalloon item;

        public DKBalloonCollectedState(DKBalloon item)
        {
            this.item = item;
            ScoreSystem.addLives(1);
            SoundPool.PlaySound(Sound.CollectibleLifeGained);
            PhysicsWorld.Instance.DestroyBody(this.item.Body);
            WorldManager.Instance.RemoveObject(this.item);
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
