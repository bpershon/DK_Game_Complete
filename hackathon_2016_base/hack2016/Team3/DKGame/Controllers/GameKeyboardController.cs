using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DKGame
{
    public class GameKeyboardController : IGameController
	{
		private List<Keys> lastPressedKeys;
		private Dictionary<Keys, Action> controllerKeyMapping;
        private IGameStateReceiver centralReceiver;

		public GameKeyboardController(IGameStateReceiver receiver)
		{
			lastPressedKeys = new List<Keys>();
            centralReceiver = receiver;
			controllerKeyMapping = new Dictionary<Keys, Action>{
				{Keys.Q, 		centralReceiver.Quit},
                {Keys.Enter,    centralReceiver.Pause}
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
                foreach (Keys liftedKey in lifted) 
				{
					lastPressedKeys.Remove(liftedKey);
				}
                if (GetFirstToMap(lastPressedKeys) != Keys.None)
                {
                    controllerKeyMapping[GetFirstToMap(lastPressedKeys)]();
                }
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

