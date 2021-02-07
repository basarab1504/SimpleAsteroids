namespace SimpleAsteroids
{
    public class Spawner<T> : GameObject, ISpawner where T : GameObject, new()
    {
        public void Spawn()
        {
            Create<T>(Transform.Position);
        }

        public override void Update()
        {
            
        }
    }
}
