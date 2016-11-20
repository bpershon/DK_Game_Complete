namespace DKGame
{
    public class PlayerExitSignCommand : ICommand
    {
        private DKExitSign exitSign;
        public PlayerExitSignCommand(IGameObject object1)
        {
            exitSign = (DKExitSign)object1;
        }

        public void Execute()
        {
            exitSign.State.ProcessCollected();
        }
    }
}
