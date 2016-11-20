namespace DKGame
{
    public interface IItem : IGameObject
    {
        IItemState State { get; }
    }
}

