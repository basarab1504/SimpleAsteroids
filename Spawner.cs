using System;
using System.Numerics;

namespace SimpleAsteroids
{
    public interface ISpawner
    {

    }

    public class Spawner<T> : GameObject, ISpawner where T : GameObject, new()
    {
        private float cooldown;
        public float SpawnCooldown { get; set; } = 3;

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
            created.Velocity = RandomVelocity();
            cooldown = SpawnCooldown;
        }

        private Vector2 RandomVelocity()
        {
            double random = new Random().NextDouble();
            float xVelocity = random > 0.5 ? 1 : -1;
            float YVelocity = random > 0.5 ? 1 : -1;
            return new Vector2(xVelocity, YVelocity);
        }
    }
}
