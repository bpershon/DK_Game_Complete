using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public class GetPercepts
    {
        //temp
        public GetPercepts()
        {
        }
        public Q_State qstate = new Q_State();
        private Player player;

        public void getPlayerInfo(Player playerObj)
        {
            player = playerObj;
            setDir(player.Body.Velocity);
            setInput();
        }

        #region Set Direction Vector
        private void setDir(Vector2 direction)
        {
            if (direction.X > 0 && direction.Y == 0)
            {
                qstate.VelVector[(int)RLAgentUtilities.vec_dir.Right] = true;
            }
            else if (direction.X < 0 && direction.Y == 0)
            {
                qstate.VelVector[(int)RLAgentUtilities.vec_dir.Left] = true;
            }
            else if (direction.X == 0 && direction.Y > 0)
            {
                qstate.VelVector[(int)RLAgentUtilities.vec_dir.Up] = true;
            }
            else if (direction.X == 0 && direction.Y < 0)
            {
                qstate.VelVector[(int)RLAgentUtilities.vec_dir.Down] = true;
            }
            else if (direction.X > 0 && direction.Y > 0)
            {
                qstate.VelVector[(int)RLAgentUtilities.vec_dir.Up_Right] = true;
            }
            else if (direction.X < 0 && direction.Y > 0)
            {
                qstate.VelVector[(int)RLAgentUtilities.vec_dir.Up_Left] = true;
            }
            else if (direction.X > 0 && direction.Y < 0)
            {
                qstate.VelVector[(int)RLAgentUtilities.vec_dir.Right_Down] = true;
            }
            else if (direction.X < 0 && direction.Y < 0)
            {
                qstate.VelVector[(int)RLAgentUtilities.vec_dir.Down_Left] = true;
            }
        }
        #endregion

        #region Set Input Vector
        private void setInput()
        {

        }
        #endregion
    }
}
