namespace SimpleAsteroids
{
    public class Spawner<T> : GameObject where T : GameObject, new()
    {
        private float cooldown;
        public float SpawnCooldown { get; set; }

        public Spawner()
        {
            Symbol = 's';
        }

        public override void Update()
        {
            if (cooldown == 0)
                Spawn();
            cooldown--;
        }

        private void Spawn()
        {
            var created = Create<T>(Position);
        }
    }

    public class Asteroid : GameObject
    {
        public Asteroid()
        {
            Symbol = 'A';
        }

        public override void Update()
        {
            Position += Velocity;
        }

        public override void OnCollide(GameObject other)
        {
            base.OnCollide(other);

            var asteroid = Create<Asteroid>(Position + Direction);
            asteroid.Velocity = Velocity;
            asteroid.Direction = Direction;
        }
    }
}
