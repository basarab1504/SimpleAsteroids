namespace SimpleAsteroids
{
    public class Spawner<T> : Component, ISpawner where T : IComponent, new()
    {
        public void Spawn()
        {
            CreateOnScene<T>(Transform.Position);
        }
    }
}
