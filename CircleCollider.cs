using System;
using System.Numerics;

namespace SimpleAsteroids
{
    public class CircleCollider : ICollideable
    {
        public GameObject GameObject { get; set; }
        public Vector2 Position => GameObject.Transform.Position;
        public float Radius { get; set; } = 1;

        public void Collide(ICollideable other)
        {
            GameObject.Collide(other);
        }

        public bool ShouldCollide(ICollideable other)
        {
            return Radius > (other.Position - Position).Length();
        }
    }
}
