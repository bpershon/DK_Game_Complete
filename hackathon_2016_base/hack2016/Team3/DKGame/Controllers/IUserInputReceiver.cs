namespace DKGame
{
	public interface IUserInputReceiver
	{
		void MoveLeft();
		void MoveRight();
		void MoveUp();
		void MoveDown();
		void MoveVerticalIdle();
        void MoveHorizontalIdle();
        void PerformAction();
		void CharacterSwap();
		void Reset();
	}
}
