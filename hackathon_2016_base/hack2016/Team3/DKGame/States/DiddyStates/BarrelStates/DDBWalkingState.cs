using System;

namespace DKGame
{
    public class DDBWalkingState : PlayerBWalkingState
    {
        public DDBWalkingState(Player player)
        {
            Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDBarrelWalkSprite());
		}
        public override bool StateWinSideCol { get { return false; } }
    }
}
