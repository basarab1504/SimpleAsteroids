using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICollideable
    {
        GameObject GameObject { get; }
        Points Points { get; }
        void Collide(ICollideable other);
    }
}
