using System;
using System.Numerics;

namespace SimpleAsteroids
{
    public class MockAsteroid : Asteroid
    {
        public override void Start()
        {
        }
    }

    public class NoChildAsteroid : MockAsteroid
    {
        public override void Collide(ICollideable other)
        {
            Destroyed = true;
        }
    }

    public class Asteroid : GameObject
    {
        public Asteroid()
        {
            Symbol = 'A';
            ScoreForDestroying = 1;
        }

        public override void Start()
        {
            base.Start();
            PushRandomDirection();
        }

        public override void Update()
        {
            Position += Velocity;
        }

        public override void Collide(ICollideable other)
        {
            if (other is Ship || other is Bullet)
            {
                Destroyed = true;
                var asteroid = Create<Asteroid>(Position + Direction);
                asteroid.Velocity = Velocity;
                asteroid.Direction = Direction;
            }
        }

        private void PushRandomDirection()
        {
            Vector2 direction = RandomDirection();
            Direction = Vector2.Normalize(direction);
            Velocity = RandomDirection();
        }

        private Vector2 RandomDirection()
        {
            double random = new Random().NextDouble();
            float xVelocity = random > 0.5 ? 1 : -1;
            float YVelocity = random > 0.5 ? 1 : -1;
            return new Vector2(xVelocity, YVelocity);
        }
    }
}
