using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public class CollisionHandler
    {
        /*
         *  Convention is object1 is top/left of object2 collision 
         *  REMOVEME notes: collision engine has enum of gameobject types. 
         */
        private Dictionary<Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide>, ICommand> crLookupTable = new Dictionary<Tuple<GameObjectType, GameObjectType, CollisionEngine.CollisionSide>, ICommand>();
        DKGame game;

        public CollisionHandler(DKGame dkgame)
        {
            game = dkgame;
            LoadCollisionResponse();
        }
        
        private void LoadCollisionResponse()
        {
            crLookupTable.Add(Tuple.Create(GameObjectType.PLAYER, GameObjectType.DKCHECKPOINTBARREL, CollisionEngine.CollisionSide.LEFT), new PlayerCPBarrelCommand(game));
        }
        
        public void CollisionResponse(GameObjectType object1, GameObjectType object2, CollisionEngine.CollisionSide side)
        {
            Tuple <GameObjectType, GameObjectType, CollisionEngine.CollisionSide> key = Tuple.Create(object1, object2, side);
            if(crLookupTable.ContainsKey(key))
            {
                crLookupTable[key].Execute();
            }
            else
            {
                key = Tuple.Create(object2, object1, side);
                if (crLookupTable.ContainsKey(key))
                {
                    crLookupTable[key].Execute();
                }
            }
        }
    }
}