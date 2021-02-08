namespace SimpleAsteroids
{
    public class CooldownSpawner<T> : Spawner<T>, ISpawner, IUpdateable where T : Component, new()
    {
        private float cooldown;
        public float SpawnCooldown { get; set; } = 3;

        public CooldownSpawner()
        {
        }

        public void Update()
        {
            cooldown--;
            if (cooldown <= 0)
            {
                Spawn();
                cooldown = SpawnCooldown;
            }
        }
    }
}
