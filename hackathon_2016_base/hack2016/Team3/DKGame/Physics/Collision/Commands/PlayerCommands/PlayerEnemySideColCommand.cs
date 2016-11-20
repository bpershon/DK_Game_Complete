namespace DKGame
{
    public class PlayerEnemySideColCommand : ICommand
    {
        private Player player;
        private IEnemy enemy;
        public PlayerEnemySideColCommand(IGameObject playerObj, IGameObject enemyObj)
        {
            player = (Player)playerObj;
            enemy = (IEnemy)enemyObj;
        }

        public void Execute()
        {
            if(player.State.StateWinSideCol)
            {
                enemy.Kill();
            }
            else
            {
                player.State.Die();
            }
        }
    }
}
