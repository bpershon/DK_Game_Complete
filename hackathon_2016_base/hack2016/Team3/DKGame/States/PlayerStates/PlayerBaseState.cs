using System;
namespace DKGame
{
	/**
	 * Base constructor and fields   
	 **/
	public abstract class PlayerBaseState
	{
		protected Player player;
		protected IPlayerStateTransitionSet transitionSet;

		protected virtual void Setup(Player setupPlayer, IPlayerStateTransitionSet setupTransitionSet, ISprite sprite)
		{
			this.player = setupPlayer;
			this.player.Sprite = sprite;
			this.player.Body.Dimensions = sprite.Dimensions;
			this.transitionSet = setupTransitionSet;
		}
	}
}
