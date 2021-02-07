using System;
using System.Numerics;

namespace SimpleAsteroids
{
    public class MockAsteroid : Asteroid
    {
        public override void Initialize()
        {
            Active = true;
            Create<RectangleShape>(Transform.Position).Transform = Transform;
            var coll = Create<RectangleCollider>(Transform.Position);
            coll.Collided += Collide;

            coll.Transform = Transform;
            coll.Layer = 0;
        }
    }

    public class NoChildAsteroid : MockAsteroid
    {
        public override void Initialize()
        {
            CreateDrawable<RectangleShape>().Transform = Transform;
            var coll = CreateCollideable<RectangleCollider>();
            coll.Collided += Collide;

            coll.Transform = Transform;
            coll.Layer = 0;
        }
    }

    public class Asteroid : GameComponent, IUpdateable
    {
        public Vector2 Velocity { get; set; }

        public override void Initialize()
        {
            Active = true;
            Create<RectangleShape>(Transform.Position).Transform = Transform;
            var coll = Create<RectangleCollider>(Transform.Position);
            coll.Collided += Collide;
            coll.Transform = Transform;
            coll.Layer = 0;
            PushRandomDirection();
        }

        public void Update()
        {
            Transform.Position += Velocity;
        }

        protected void Collide(ICollideable other)
        {
            if (other is Ship || other is Bullet)
            {
                Destroyed = true;
                var asteroid = Create<Asteroid>(Transform.Position + Transform.Direction);
                asteroid.Velocity = Velocity;
                asteroid.Transform.Direction = Transform.Direction;
            }
        }

        private void PushRandomDirection()
        {
            Vector2 direction = RandomDirection();
            Transform.Direction = Vector2.Normalize(direction);
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
