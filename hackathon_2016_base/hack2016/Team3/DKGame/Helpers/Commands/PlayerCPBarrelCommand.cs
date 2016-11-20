using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public class PlayerCPBarrelCommand : ICommand
    {
        private DKGame game;
        
        public PlayerCPBarrelCommand(DKGame dkGame)
        {
            game = dkGame;
        }

        public void Execute()
        {
            //foreach (DKCheckpointBarrel barrel in game.gameItems)
            //{
                //barrel.State.ProcessBreak();
            //}
        }
    }
}
