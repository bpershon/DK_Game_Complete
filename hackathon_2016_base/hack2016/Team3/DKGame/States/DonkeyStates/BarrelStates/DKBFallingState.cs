/**
 * THIS FILE WAS GENERATED USING Scripts/statecreator.py
 * PLEASE USE THE SCRIPT TO GENERATE OTHER SUCH FILES, DO NOT CREATE THEM MANUALLY
 **/
namespace DKGame
{
    public class DKBFallingState : PlayerBFallingState
    {
        public DKBFallingState(Player player)
        {
            Setup(player,
				  DKStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDKBarrelIdleSprite());
		}
    }
}
