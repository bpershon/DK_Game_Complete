using System;
namespace DKGame
{
	public class PlayerTeleportCommand : ICommand
	{
		Player player;
		DKTeleporter teleporter;

		public PlayerTeleportCommand(Player teleportingPlayer, IGameObject gameObject)
		{
			teleporter = (DKTeleporter)gameObject;
			player = teleportingPlayer;
		}

		public void Execute()
		{
			DKAreaProperties props = DKAreaPropertyLookup.LookupPropertiesForArea(teleporter.Destination);
			DKDrawingPipeline.Instance.SetAreaProperties(props);
			player.Body.BottomCenter = props.startPos;
		}
	}
}
