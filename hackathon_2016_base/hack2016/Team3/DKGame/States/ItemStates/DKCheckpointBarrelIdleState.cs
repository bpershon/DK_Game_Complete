using System;

namespace DKGame
{
    public class DKCheckpointBarrelIdleState : IItemState
    {
        private DKCheckpointBarrel item;

        public DKCheckpointBarrelIdleState(DKCheckpointBarrel item)
        {
            this.item = item;
            this.item.Sprite = ItemSpriteFactory.Instance.CreateDKCheckpointBarrelSpriteUnopened();
        }

        public void ProcessBreak()
        {
            //NO-OP this is collectable
        }

        public void ProcessIdle()
        {
            // nop
        }

        public void ProcessCollected()
        {
            this.item.Sprite = ItemSpriteFactory.Instance.CreateDKCheckpointBarrelSpriteOpened();
            //not removed from wm list to keep on screen
            PhysicsWorld.Instance.DestroyBody(this.item.Body);
            CheckpointManager.Instance.UpdateCheckpointLocation(this.item.Body.BottomCenter);
            SoundPool.PlaySound(Sound.CollectibleBarrelSave);
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
