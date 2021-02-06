namespace SimpleAsteroids
{
    public interface IComponent
    {
        bool Active { get; }
        bool Destroyed { get; }
    }
}
