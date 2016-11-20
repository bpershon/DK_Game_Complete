using System;
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class DKKongTileCollectedState : IItemState
    {
        private DKKongTile item;

        public DKKongTileCollectedState(DKKongTile item)
        {
            this.item = item;
            switch (item.KongTileLetter)
            {
                case DKKongTileType.K:
                    SoundPool.PlaySound(Sound.CollectibleLetterK);
                    break;
                case DKKongTileType.O:
                    SoundPool.PlaySound(Sound.CollectibleLetterO);
                    break;
                case DKKongTileType.N:
                    SoundPool.PlaySound(Sound.CollectibleLetterN);
                    break;
                case DKKongTileType.G:
                    SoundPool.PlaySound(Sound.CollectibleLetterG);
                    break;
            }
            ScoreSystem.addKongTiles(item.KongTileLetter);
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
