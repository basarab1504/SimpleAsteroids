using System;
using System.Numerics;

namespace SimpleAsteroids
{
    public class RectangleCollider : ICollideable
    {
        public event Action<ICollideable> Collided;
        public int Layer { get; set; }
        public Points Points => GetPoints();
        public Transform Transform { get; set; }

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
