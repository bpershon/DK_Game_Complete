namespace DKGame
{
    public class PlayerRambiCollectCommand : ICommand
    {
        private Rambi rambi;
        private Player player;
        public PlayerRambiCollectCommand(IGameObject player_object, IGameObject object1)
        {
            rambi = (Rambi)object1;
            player = (Player)player_object;
        }

        public void Execute()
        {
            player.State.MountRambi();
            rambi.State.ProcessCollected();
        }
    }
}
