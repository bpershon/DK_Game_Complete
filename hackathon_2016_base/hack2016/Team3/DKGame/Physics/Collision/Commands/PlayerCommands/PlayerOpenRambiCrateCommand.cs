using Microsoft.Xna.Framework;

namespace DKGame
{
    public class PlayerOpenRambiCrateCommand : ICommand
    {
        private DKRambiCrate crate;
        public PlayerOpenRambiCrateCommand(IGameObject object1)
        {
            crate = (DKRambiCrate)object1;
        }
        public void Execute()
        {
            crate.State.ProcessBreak();
            IItem rambi = new Rambi();
            rambi.Body.BottomCenter = crate.Body.BottomCenter;
            WorldManager.Instance.AddObject(rambi);
            PhysicsWorld.Instance.DestroyBody(crate.Body);
        }
    }
}
