namespace DKGame
{
    public class PlayerDieCommand : ICommand
    {
        private Player player;

        public PlayerDieCommand(IGameObject playerObj)
        {
            player = (Player)playerObj;
        }

        public void Execute()
        {
            player.State.Die();
        }
    }
}
