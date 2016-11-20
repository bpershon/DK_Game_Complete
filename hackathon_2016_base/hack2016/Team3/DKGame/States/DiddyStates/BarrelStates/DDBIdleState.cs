using System;

namespace DKGame
{
    public class DDBIdleState : PlayerBIdleState
    {
        public DDBIdleState(Player player)
        {
           Setup(player,
				 DDStateTransitionSet.Instance,
				 PlayerSpriteFactory.Instance.CreateDDBarrelIdleSprite());
		}
        public override bool StateWinSideCol { get { return true; } }
    }
}
