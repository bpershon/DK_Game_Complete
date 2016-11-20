using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace DKGame
{
	public static class DKAreaPropertyLookup
	{
        private static readonly Vector2 LEVEL_SIZE = new Vector2(5276, 512);
        private static readonly Vector2 CAVE1_SIZE = new Vector2(256, 256);
        private static readonly Vector2 CAVE2_SIZE = new Vector2(1024, 256);
        private static readonly Vector2 DK_ROOM_SIZE = new Vector2(256, 256);

        private static readonly DKAreaProperties MAIN_LEVEL = new DKAreaProperties(
			LEVEL_SIZE,
			new Vector2(0, 0),
			new Vector2(60, 150)
		);

		private static readonly DKAreaProperties MAIN_CAVE = new DKAreaProperties(
            LEVEL_SIZE,
			new Vector2(0, 0),
			new Vector2(150, 330)
		);

		private static readonly DKAreaProperties MAIN_CAVE_BANANAS = new DKAreaProperties(
            LEVEL_SIZE,
			new Vector2(0, 0),
			new Vector2(4175, 275)
		);

		private static readonly DKAreaProperties CAVE = new DKAreaProperties(
			CAVE1_SIZE,
			new Vector2(266, 512),
			new Vector2(420, 712)
		);

		private static readonly DKAreaProperties DK_ROOM = new DKAreaProperties(
			DK_ROOM_SIZE,
			new Vector2(0, 512),
			new Vector2(200, 666)
		);

		private static readonly DKAreaProperties CAVE_BANANAS = new DKAreaProperties(
			CAVE2_SIZE,
			new Vector2(3218, 512),
			new Vector2(3300, 680)
		);

		private static readonly Dictionary<string, DKAreaProperties> LOOKUP = new Dictionary<string, DKAreaProperties>{
			{"beginning", MAIN_LEVEL},
			{"mainbananas", MAIN_CAVE_BANANAS},
			{"cave", CAVE},
			{"dkroom", DK_ROOM},
			{"cavebananas", CAVE_BANANAS},
			{"beginningcave", MAIN_CAVE},
		};

		public static DKAreaProperties LookupPropertiesForArea(string area)
		{
			return LOOKUP[area];
		}
	}

	public class DKAreaProperties
	{
		public Vector2 size;
		public Vector2 origin;
		public Vector2 startPos;

		public DKAreaProperties(Vector2 size, Vector2 origin, Vector2 startPos)
		{
			this.size = size;
			this.origin = origin;
			this.startPos = startPos;
		}
	}
}
