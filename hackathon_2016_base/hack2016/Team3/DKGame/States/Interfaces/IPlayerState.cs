namespace DKGame
{
    public interface IPlayerState
    {
		#region Collision Response

		void Die();

		#endregion

		#region Input

        void ProcessLeft();

        void ProcessRight();

        void ProcessUp();

        void ProcessDown();

		void PerformAction();

		void ChangePlayer();

		void HorizontalIdle();

		void VerticalIdle();

		#endregion

		#region Update

		void Update();

		#endregion

		#region State-Controlled Action

        void MountRambi();

        void DismountRambi();

        void Win();

		#endregion
      
        bool StateWinSideCol { get; } 
    }
}

