using System;

namespace DKGame
{
    public class DDBJumpingState : PlayerBJumpingState
    {
        public DDBJumpingState(Player player)
        {
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDBarrelJumpSprite());
		}
        public override bool StateWinSideCol { get { return true; } }
    }
}
