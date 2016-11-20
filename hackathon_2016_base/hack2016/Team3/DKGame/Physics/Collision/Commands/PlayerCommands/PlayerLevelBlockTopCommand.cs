using Microsoft.Xna.Framework;

namespace DKGame
{
    class PlayerLevelBlockTopCommand : ICommand
    {
        private Player player;
        public PlayerLevelBlockTopCommand(Player object1)
        {
            player = object1;
        }
        public void Execute()
        {
			player.CollidedWithGround();
        }
    }
}

