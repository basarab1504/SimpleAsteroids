using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICollideable : IComponent
    {
        GameObject GameObject { get; }
        Points Points { get; }
        void Collide(ICollideable other);
    }
}
