using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public class EnemyDieByBarrelCommand : ICommand
    {
        private IEnemy enemy;
        private DKThrownBarrel barrel;

        public EnemyDieByBarrelCommand(IGameObject enemyObj, IGameObject barrelObj)
        {
            enemy = (IEnemy)enemyObj;
            barrel = (DKThrownBarrel)barrelObj;
        }
        public void Execute()
        {
            enemy.Kill();
            barrel.State.ProcessBreak();
        }
    }
}
