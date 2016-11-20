using System;

namespace DKGame
{
    public class DDBThrowingState : PlayerBThrowingState
    {
		public DDBThrowingState(Player player)
		{
			Setup(player,
				  DDStateTransitionSet.Instance,
				  PlayerSpriteFactory.Instance.CreateDDBarrelThrowPt1Sprite());
		}
    }
}
