namespace SimpleAsteroids
{
    public interface IComponent
    {
        bool Active { get; set; }
        bool Destroyed { get; set; }
    }
}
