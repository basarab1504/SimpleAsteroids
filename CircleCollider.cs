using System;
using System.Numerics;

namespace SimpleAsteroids
{

    public class RectangleCollider : Component, ICollideable
    {
        public event Action<ICollideable> Collided;
        public int Type { get; set; }
        public Points Points => GetPoints();

        private Points GetPoints()
        {
            return new Points(Transform.Position, Transform.Size * 0.5f);
        }

        public void Collide(ICollideable other)
        {
            if (Collided != null)
                Collided(other);
        }
    }
}
