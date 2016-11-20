namespace DKGame
{
    public interface IItemState
    {
        void ProcessBreak();

        void ProcessIdle();

        void ProcessCollected();

        void ProcessToggle();

        void Update();
    }
}
