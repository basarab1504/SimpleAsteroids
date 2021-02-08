namespace SimpleAsteroids
{
    public interface IAwakeable : IComponent
    {
        void Awake();
    }

    public interface IStartable : IComponent
    {
        void Start();
    }

    public interface IUpdateable : IComponent
    {
        void Update();
    }
}
