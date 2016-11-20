using System;
using System.Collections.Generic;

namespace DKGame
{
    public static class PlayerCollisionHandlerLookupTable
    {

        public static void LoadPlayerCRTable(Dictionary<Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide>, PlayerCollisionHandler.Command> playerCRLookupTable)
        {
            #region Items
            //CP barrel
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Collectable, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.ItemCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Collectable, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.ItemCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Collectable, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.ItemCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Collectable, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.ItemCollect);
            //Rambi Crate
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKRambiCrate, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.BreakRambiCrate);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKRambiCrate, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.BreakRambiCrate);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKRambiCrate, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.BreakRambiCrate);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKRambiCrate, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.BreakRambiCrate);
            //ExitSign
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKExitSign, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.ExitSignCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKExitSign, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.ExitSignCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKExitSign, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.ExitSignCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKExitSign, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.ExitSignCollect);
            //RegBarrel Roll for sprint 3
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKStandardBarrel, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.StandardBarrelCollision);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKStandardBarrel, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.StandardBarrelCollision);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKStandardBarrel, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.StandardBarrelCollision);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKStandardBarrel, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.StandardBarrelCollision);
            //Playerbarrel for sprint 3
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKPlayerBarrel, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.PlayerBarrelCollision);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKPlayerBarrel, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.PlayerBarrelCollision);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKPlayerBarrel, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.PlayerBarrelCollision);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.DKPlayerBarrel, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.PlayerBarrelCollision);
            //levelblock
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.LevelBlock, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.None);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.LevelBlock, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.None);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.LevelBlock, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.None);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.LevelBlock, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.PlayerLevelBlockTop);
            //rambi (treated as pickup item for now)
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Rambi, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.RambiCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Rambi, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.RambiCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Rambi, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.RambiCollect);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Rambi, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.RambiCollect);
            //teleporter (for hidden levels)
			playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Teleporter, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.PlayerTeleport);
			playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Teleporter, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.PlayerTeleport);
			playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Teleporter, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.PlayerTeleport);
			playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Teleporter, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.PlayerTeleport);
			#endregion

            #region Enemies
            //gnawty: Convention 1st object top / left position
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Enemy, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.PlayerKillEnemy);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Enemy, CollisionEngine.CollisionSide.LEFT), PlayerCollisionHandler.Command.PlayerEnemySideCol);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Enemy, CollisionEngine.CollisionSide.RIGHT), PlayerCollisionHandler.Command.PlayerEnemySideCol);
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Player, GameObjectType.Enemy, CollisionEngine.CollisionSide.BOTTOM), PlayerCollisionHandler.Command.PlayerKillEnemy);
            //gnawty lands on player
            playerCRLookupTable.Add(Tuple.Create(GameObjectType.Enemy, GameObjectType.Player, CollisionEngine.CollisionSide.TOP), PlayerCollisionHandler.Command.PlayerDie);
            #endregion
        }
    }
}

