namespace SimpleAsteroids
{
    public class CooldownSpawner<T> : Spawner<T>, ISpawner, IUpdateable where T : GameComponent, new()
    {
        private float cooldown;
        public float SpawnCooldown { get; set; } = 3;

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
