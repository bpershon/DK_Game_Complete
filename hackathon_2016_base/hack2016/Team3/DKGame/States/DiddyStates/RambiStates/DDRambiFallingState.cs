/**
 * THIS FILE WAS GENERATED USING Scripts/statecreator.py
 * PLEASE USE THE SCRIPT TO GENERATE OTHER SUCH FILES, DO NOT CREATE THEM MANUALLY
 **/
namespace DKGame
{
    public class DDRambiFallingState : PlayerRambiFallingState
    {
        public DDRambiFallingState(Player player)
        {
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDRidingIdleSprite());
		}
    }
}
