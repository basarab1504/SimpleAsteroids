namespace SimpleAsteroids
{
    public class CooldownSpawner<T> : Spawner<T>, ISpawner where T : GameObject, new()
    {
        private float cooldown;
        public float SpawnCooldown { get; set; } = 3;

        public CooldownSpawner()
        {
        }

        public override void Update()
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
