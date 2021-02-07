using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICollideable
    {
        int Layer { get; }
        Points Points { get; }
        void Collide(ICollideable other);
    }
}
