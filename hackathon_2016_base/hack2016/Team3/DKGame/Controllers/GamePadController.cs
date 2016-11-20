using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace DKGame
{
	public enum GamePadStickDirection
	{
		Center,
		Up,
		Down,
		Left,
		Right
	}

	public enum GamePadStickType
	{
		Left,
		Right
	}

    public enum GamePadButtons
    {
        None,
        A,
        B
    }

    public class GamePadController : IUserInputController, IGameController
	{
		private GamePadStickDirection lastLeftStickDirection;
		private bool gamePadConnected;
        private IUserInputReceiver centralReceiver;

		private static float RADIUS_THRESHOLD = .5f;
		private static Dictionary<GamePadStickDirection, Action> LeftStickMappings;
        private static Dictionary<GamePadButtons, Action> ButtonMappings;

		public GamePadController(IUserInputReceiver receiver)
		{
            centralReceiver = receiver;
			LeftStickMappings = new Dictionary<GamePadStickDirection, Action>
			{
				{GamePadStickDirection.Left,    receiver.MoveLeft},
				{GamePadStickDirection.Right,   receiver.MoveRight},
				{GamePadStickDirection.Up,      receiver.MoveUp},
				{GamePadStickDirection.Down,    receiver.MoveDown},
				{GamePadStickDirection.Center,  receiver.MoveHorizontalIdle},
			};

            ButtonMappings = new Dictionary<GamePadButtons, Action>
            {
                {GamePadButtons.A, receiver.MoveUp },
                {GamePadButtons.B, receiver.PerformAction }
            };
		}

		public void ProcessUpdate()
		{
			DetectConnectedState();
			if (gamePadConnected) 
			{
				GamePadState state = GamePad.GetState(PlayerIndex.One);
				GamePadStickDirection leftStickDirection = DetectStickDirection(state.ThumbSticks.Left, GamePadStickType.Left);
                GamePadButtons button = DetectButton(state);

                if (button != GamePadButtons.None)
                {
                    ButtonMappings[button]();
                }
				if (leftStickDirection != lastLeftStickDirection)
				{
					LeftStickMappings[leftStickDirection]();
					lastLeftStickDirection = leftStickDirection;
				}
			}
		}

        public void ProcessPausedUpdate()
        {
            DetectConnectedState();
            if (gamePadConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);
                GamePadStickDirection leftStickDirection = DetectStickDirection(state.ThumbSticks.Left, GamePadStickType.Left);
                GamePadButtons button = DetectButton(state);
            }
        }

        /*
		 * Detection methods 
		 */

        private void DetectConnectedState()
		{
			GamePadCapabilities capabilities = GamePad.GetCapabilities(
											   PlayerIndex.One);
			gamePadConnected = capabilities.IsConnected;
		}

		private GamePadStickDirection DetectStickDirection(Vector2 position, GamePadStickType stickType)
		{
			if (position.X > RADIUS_THRESHOLD)
				return GamePadStickDirection.Right;
			else if (position.X < -RADIUS_THRESHOLD)
				return GamePadStickDirection.Left;
			else if (position.Y > RADIUS_THRESHOLD)
				return GamePadStickDirection.Up;
			else if (position.Y < RADIUS_THRESHOLD)
				return GamePadStickDirection.Down;
			else
				return GamePadStickDirection.Center;
		}

        private GamePadButtons DetectButton(GamePadState state)
        {
            GamePadButtons result = GamePadButtons.None;
            if(state.IsButtonDown(Buttons.A))
            {
                result = GamePadButtons.A;
            } else if(state.IsButtonDown(Buttons.B))
            {
                result = GamePadButtons.B;
            }
            return result;
        }
	}
}

