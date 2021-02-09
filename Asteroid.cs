using System;
using System.Numerics;

namespace SimpleAsteroids
{
    public class MockAsteroid : Asteroid
    {
        public override void Start()
        {
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Collided += Collide;
            coll.Type = 0;
        }
    }

    public class NoChildAsteroid : MockAsteroid
    {
        public override void Start()
        {
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Collided += (x) => Parent.Destroy();
            coll.Type = 0;
        }
    }

    public class Asteroid : Component, IStartable, IUpdateable
    {
        public Vector2 Velocity { get; set; }

        public virtual void Start()
        {
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Collided += Collide;
            coll.Type = 0;
            PushRandomDirection();
        }

        public void Update()
        {
            Transform.Position += Velocity;
        }

        protected void Collide(ICollideable other)
        {
            Parent.Destroy();
            var asteroid = CreateOnScene<Asteroid>(Transform.Position + Transform.Direction);
            asteroid.Velocity = Velocity;
            asteroid.Transform.Direction = Transform.Direction;
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
