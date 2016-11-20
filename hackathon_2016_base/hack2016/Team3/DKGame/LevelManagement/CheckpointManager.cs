using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public class CheckpointManager
    {
        private static CheckpointManager checkpointManager = new CheckpointManager();
        public static CheckpointManager Instance
        {
            get { return checkpointManager; }
        }

        private Vector2 checkpointLocation;
        public Vector2 CheckpointLocation
        {
            get { return checkpointLocation; }
            set { checkpointLocation = value; }
        }

        public void ResetFromCheckpoint()
        {
            WorldManager.Instance.ResetFromCheckpoint(checkpointLocation);
        }

        public void UpdateCheckpointLocation(Vector2 newLocation)
        {
            checkpointLocation = newLocation;
        }

    }
}
