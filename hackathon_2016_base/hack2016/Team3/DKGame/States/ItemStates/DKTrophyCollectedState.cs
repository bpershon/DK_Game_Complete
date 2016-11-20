using System;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class DKTrophyCollectedState : IItemState
    {
        private static int counter = 1;
        private DKTrophy item;

        public DKTrophyCollectedState(DKTrophy item)
        {
            this.item = item;
            if (counter++ == 1) SoundPool.PlaySound(Sound.CollectibleTrophy1);
            else if (counter++ == 2) SoundPool.PlaySound(Sound.CollectibleTrophy2);
            else if (counter++ == 3) SoundPool.PlaySound(Sound.CollectibleTrophy3);
            else if (counter++ > 3) SoundPool.PlaySound(Sound.CollectibleTrophyAll);

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
