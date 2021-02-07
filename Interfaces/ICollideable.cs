using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICollideable
    {
        int Type { get; }
        Points Points { get; }
        void Collide(ICollideable other);
    }
}
