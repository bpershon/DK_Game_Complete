namespace DKGame
{
    public class PlayerPlayerBarrelCollisionCommand : ICommand
    {
        private DKPlayerBarrel barrel;
        private Player player;

        public PlayerPlayerBarrelCollisionCommand(IGameObject playerObj, IGameObject object1)
        {
            barrel = (DKPlayerBarrel)object1;
            player = (Player)playerObj;
        }
        public void Execute()
        {
			player.CollidedWithBarrel(barrel);
        }
    }
}
