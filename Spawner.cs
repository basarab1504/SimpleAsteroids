namespace SimpleAsteroids
{
    public interface ISpawner
    {
        void Spawn();
    }

    public class CooldownSpawner<T> : GameObject, ISpawner where T : GameObject, new()
    {
        private float cooldown;
        public float SpawnCooldown { get; set; } = 3;

        public CooldownSpawner()
        {
            Symbol = 's';
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

        public void Spawn()
        {
            Create<T>(Position);
        }
    }
}
