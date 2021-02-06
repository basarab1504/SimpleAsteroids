namespace SimpleAsteroids
{
    public interface IGameComponent
    {
        bool Active { get; }
        bool Destroyed { get; }
        void Initialize();
    }
}