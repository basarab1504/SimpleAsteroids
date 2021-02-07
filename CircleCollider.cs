using System;
using System.Numerics;

namespace SimpleAsteroids
{
    public class RectangleCollider : GameComponent, ICollideable
    {
        public event Action<ICollideable> Collided;
        public int Layer { get; set; }
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
