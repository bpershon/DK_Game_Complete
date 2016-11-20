using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public static class EnemyCollisionHandlerLookupTable
    {
        public static void LoadEnemyCRTable(Dictionary<Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide>, EnemyCollisionHandler.Command> enemyCRLookupTable)
        {
            #region Items
            //EnemyAndBarrel
            enemyCRLookupTable.Add(Tuple.Create(GameObjectType.Enemy, GameObjectType.ThrownBarrel, CollisionEngine.CollisionSide.LEFT), EnemyCollisionHandler.Command.EnemyDieByBarrel);
            enemyCRLookupTable.Add(Tuple.Create(GameObjectType.Enemy, GameObjectType.ThrownBarrel, CollisionEngine.CollisionSide.RIGHT), EnemyCollisionHandler.Command.EnemyDieByBarrel);
            enemyCRLookupTable.Add(Tuple.Create(GameObjectType.Enemy, GameObjectType.ThrownBarrel, CollisionEngine.CollisionSide.TOP), EnemyCollisionHandler.Command.EnemyDieByBarrel);
            enemyCRLookupTable.Add(Tuple.Create(GameObjectType.Enemy, GameObjectType.ThrownBarrel, CollisionEngine.CollisionSide.BOTTOM), EnemyCollisionHandler.Command.EnemyDieByBarrel);

            #endregion
        }
    }
}
