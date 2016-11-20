using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DKGame
{
    public class UserKeyboardController : IUserInputController
	{
		private List<Keys> lastPressedKeys;
		private Dictionary<Keys, Action> controllerKeyMapping;
        private IUserInputReceiver centralReceiver;

		public UserKeyboardController(IUserInputReceiver receiver)
		{
			lastPressedKeys = new List<Keys>();
            centralReceiver = receiver;
			controllerKeyMapping = new Dictionary<Keys, Action>{
				{Keys.Down, 	centralReceiver.MoveDown},
				{Keys.Left, 	centralReceiver.MoveLeft},
				{Keys.Right, 	centralReceiver.MoveRight},
				{Keys.None, 	centralReceiver.MoveHorizontalIdle},
                {Keys.Up,       centralReceiver.MoveUp},
                {Keys.X,        centralReceiver.PerformAction},
				{Keys.R,        centralReceiver.Reset},
				{Keys.A,        centralReceiver.CharacterSwap},
            };
		}

		public void ProcessUpdate()
		{
			KeyboardState state = Keyboard.GetState();
			List<Keys> newPressedKeys = state.GetPressedKeys().ToList();

			List<Keys> lifted = new List<Keys>();
			List<Keys> pressed = new List<Keys>();

			DKGameUtilities.ListDifference(newPressedKeys, lastPressedKeys, lifted, pressed);

			if (lifted.Count != 0) 
			{
                Boolean horizontalStop = !(pressed.Contains(Keys.Right) || pressed.Contains(Keys.Left));
                foreach (Keys liftedKey in lifted) 
				{
					lastPressedKeys.Remove(liftedKey);
                    Boolean verticalStop = liftedKey.Equals(Keys.Z) || liftedKey.Equals(Keys.Down);
                    
                    if (verticalStop)
                    {
                        centralReceiver.MoveVerticalIdle();
                    }
				}
                if (horizontalStop)
                {
                    centralReceiver.MoveHorizontalIdle();
                }
                controllerKeyMapping[GetFirstToMap(lastPressedKeys)]();
			}

			if (pressed.Count != 0) 
			{
				foreach (Keys pressedKey in pressed) 
				{
					lastPressedKeys.Add(pressedKey);
				}
			}

			if (GetFirstToMap(pressed) != Keys.None)
			{
				controllerKeyMapping[GetFirstToMap(pressed)]();
			}
		}

        private Keys GetFirstToMap(List<Keys> keyList)
		{
			foreach (Keys key in keyList)
			{
				if (controllerKeyMapping.ContainsKey(key))
				{
					return key;
				}
			}

			return Keys.None;
		}


	}
}

