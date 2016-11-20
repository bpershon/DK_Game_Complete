using System;
using System.Collections.Generic;

namespace DKGame
{

    public static class PlayerCollisionHandler
    {
        /*
         *  Convention is object1 is top/left of object2 collision 
         */
        public enum Command { None, BreakRambiCrate, ExitSignCollect, RambiCollect, StandardBarrelCollision, PlayerBarrelCollision, PlayerEnemySideCol, PlayerKillEnemy, PlayerDie, PlayerLevelBlockTop, ItemCollect, PlayerTeleport };

        private static Dictionary<Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide>, Command> playerCRLookupTable = new Dictionary<Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide>, Command>();

        public static void LoadCollisionResponseTable()
        {
            PlayerCollisionHandlerLookupTable.LoadPlayerCRTable(playerCRLookupTable);
        }

        public static void CollisionResponse(IGameObject object1, IGameObject object2, CollisionEngine.CollisionSide cSide)
        {
            Player player;
            IGameObject objectToAct1;
            CollisionEngine.CollisionSide side = cSide;
            Command command = Command.None;
            if(object1.GameObjType == GameObjectType.Player)
            {
                player = (Player)object1;
                objectToAct1 = object2;
            }
            else
            {
                objectToAct1 = object1;
                player = (Player)object2;
            }            
            Tuple <GameObjectType, GameObjectType, CollisionEngine.CollisionSide> key = Tuple.Create(player.GameObjType, objectToAct1.GameObjType, side);
            if (playerCRLookupTable.ContainsKey(key))
            {
                command = playerCRLookupTable[key];
            }
            else
            {
                key = Tuple.Create(objectToAct1.GameObjType, player.GameObjType, side);
                command = playerCRLookupTable[key];
            }
            ICommand commandToRun = GetCommand(player, objectToAct1, side, command);
            if (command != Command.None)
            {
                commandToRun.Execute();
            }
        }

        #region Encode Commands to ICommands with type checked arguements
        private static ICommand GetCommand(Player player, IGameObject objectToAct1, CollisionEngine.CollisionSide side, Command command)
        {
            switch (command)
            {
                case Command.BreakRambiCrate:
                    return new PlayerOpenRambiCrateCommand(objectToAct1);
                case Command.PlayerLevelBlockTop:
                    return new PlayerLevelBlockTopCommand(player);
                case Command.ItemCollect:
                    return new PlayerItemCollectCommand(objectToAct1);
                case Command.RambiCollect:
                    return new PlayerRambiCollectCommand(player, objectToAct1);
                case Command.StandardBarrelCollision:
                    return new PlayerStandardBarrelCollisionCommand(player, objectToAct1);
                case Command.PlayerBarrelCollision:
                    return new PlayerPlayerBarrelCollisionCommand(player, objectToAct1);
                case Command.PlayerEnemySideCol:
                    return new PlayerEnemySideColCommand(player, objectToAct1);
                case Command.PlayerKillEnemy:
                    return new PlayerKillEnemyCommand(objectToAct1);
                case Command.PlayerDie:
                    return new PlayerDieCommand(player);
                case Command.ExitSignCollect:
                    return new PlayerExitSignCommand(objectToAct1);
				case Command.PlayerTeleport:
					return new PlayerTeleportCommand(player, objectToAct1);
                default:
                    return null;  

            }
        }
        #endregion
    }
}