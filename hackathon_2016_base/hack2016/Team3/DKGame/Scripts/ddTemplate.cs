/**
 * THIS FILE WAS GENERATED USING Scripts/statecreator.py
 * PLEASE USE THE SCRIPT TO GENERATE OTHER SUCH FILES, DO NOT CREATE THEM MANUALLY
 **/
namespace DKGame
{
    public class DD_FILE_NAME : PLAYER_FILE_NAME
    {
        public DD_FILE_NAME(Player player)
        {
        	// TODO: Edit SPRITE_CREATION for this state
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.SPRITE_CREATION);
		}
    }
}
