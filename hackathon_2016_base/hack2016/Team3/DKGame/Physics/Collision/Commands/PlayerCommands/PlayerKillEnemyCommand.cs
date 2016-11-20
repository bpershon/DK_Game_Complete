namespace DKGame
{
    public class PlayerKillEnemyCommand : ICommand
    {
        private IEnemy enemy;
        
        public PlayerKillEnemyCommand(IGameObject object1)
        {
            enemy = (IEnemy)object1;
        }
        public void Execute()
        {
            enemy.Kill();
        }
    }
}
