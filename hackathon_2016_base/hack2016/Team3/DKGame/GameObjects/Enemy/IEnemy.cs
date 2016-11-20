namespace DKGame
{
    public interface IEnemy : IGameObject
    {
        bool FacingRight { get; set; }

        float Range { get; set; }

        void ChangeDirection();
        void Kill();
    }
}