namespace SimpleAsteroids
{

    public interface IUpdateable : IComponent
    {
        void Update(float deltaTime);
    }
}
