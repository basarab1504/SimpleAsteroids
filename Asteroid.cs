using System;
using System.Numerics;

namespace SimpleAsteroids
{
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

        private Vector2 RandomVelocity()
        {
            double random = new Random().NextDouble();
            float xVelocity = random > 0.5 ? 1 : -1;
            float YVelocity = random > 0.5 ? 1 : -1;
            return new Vector2(xVelocity, YVelocity);
        }
    }
}
