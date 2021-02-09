namespace SimpleAsteroids
{
    public class Spawner<T> : Component, ISpawner where T : Component, new()
    {
        public void Spawn()
        {
            CreateOnScene<T>(Transform.Position);
        }
    }
}
