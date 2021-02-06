namespace SimpleAsteroids
{
    public class Spawner<T> : GameComponent, ISpawner where T : GameComponent, new()
    {
        public void Spawn()
        {
            var spawned = Create<T>(Transform.Position);
        }
    }
}
