using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public static class EnemyCollisionHandler
    {
        public enum Command { None, EnemyDieByBarrel };
        private static Dictionary<Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide>, Command> enemyCRLookupTable = new Dictionary<Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide>, Command>();

        public static void LoadCollisionResponseTable()
        {
            EnemyCollisionHandlerLookupTable.LoadEnemyCRTable(enemyCRLookupTable);
        }

        public static void CollisionResponse(IGameObject object1, IGameObject object2, CollisionEngine.CollisionSide cSide)
        {
            IEnemy enemy;
            IGameObject objectToAct1;
            CollisionEngine.CollisionSide side = cSide;
            Command command = Command.None;
            if (object1.GameObjType == GameObjectType.Enemy)
            {
                enemy = (IEnemy)object1;
                objectToAct1 = object2;
            }
            else
            {
                objectToAct1 = object1;
                enemy = (IEnemy)object2;
            }
            Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide> key = Tuple.Create(enemy.GameObjType, objectToAct1.GameObjType, side);
            if (enemyCRLookupTable.ContainsKey(key))
            {
                command = enemyCRLookupTable[key];
            }
            ICommand commandToRun = GetCommand(enemy, objectToAct1, command);
            if (command != Command.None)
            {
                commandToRun.Execute();
            }
        }

        #region Encode Commands to ICommands with type checked arguements
        private static ICommand GetCommand(IEnemy enemy, IGameObject objectToAct1, Command command)
        {
            switch (command)
            {
                case Command.EnemyDieByBarrel:
                    return new EnemyDieByBarrelCommand(enemy, objectToAct1);
                default:
                    return null;

            }
        }
        #endregion
    }
}
