namespace SimpleAsteroids
{
    public class CooldownSpawner<T> : Spawner<T>, ISpawner, IUpdateable where T : Component, new()
    {
        private float cooldown;
        public float SpawnCooldown { get; set; } = 3;

        public void Update(float deltaTime)
        {
            cooldown -= deltaTime;
            if (cooldown <= 0)
            {
                Spawn();
                cooldown = SpawnCooldown;
            }
        }
    }
}
