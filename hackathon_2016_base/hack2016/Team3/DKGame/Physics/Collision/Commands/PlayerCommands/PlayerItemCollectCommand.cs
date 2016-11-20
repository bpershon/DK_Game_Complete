namespace DKGame
{
    public class PlayerItemCollectCommand : ICommand
    {
        private IItem item;
        public PlayerItemCollectCommand(IGameObject object1)
        {
            item = (IItem)object1;
        }

        public void Execute()
        {
            item.State.ProcessCollected();
        }
    }
}
