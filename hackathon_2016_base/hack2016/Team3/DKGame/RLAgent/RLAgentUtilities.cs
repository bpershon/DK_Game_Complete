using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public static class RLAgentUtilities
    {
        //used to access 8-way velocity vector
        public enum vec_dir
        {
            Up = 0,
            Up_Right = 1,
            Right = 2,
            Right_Down = 3,
            Down = 4,
            Down_Left = 5,
            Left = 6,
            Up_Left = 7
        };

        public enum dpad
        {
            Left = 0,
            Right = 1,
            Jump = 2,
            Roll = 3
        };
    }
}
