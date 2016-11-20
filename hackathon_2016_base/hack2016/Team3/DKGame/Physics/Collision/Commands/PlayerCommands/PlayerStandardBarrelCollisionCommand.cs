
using Microsoft.Xna.Framework;

namespace DKGame
{
    public class PlayerStandardBarrelCollisionCommand : ICommand
    {
        private DKStandardBarrel barrel;
        private Player player;

        public PlayerStandardBarrelCollisionCommand(IGameObject playerObj, IGameObject object1)
        {
            barrel = (DKStandardBarrel)object1;
            player = (Player)playerObj;
        }
        public void Execute()
        {
			player.CollidedWithBarrel(barrel);
        }
    }
}
