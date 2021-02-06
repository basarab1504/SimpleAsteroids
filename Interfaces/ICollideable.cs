using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICollideable : IComponent
    {
        int Type { get; }
        Points Points { get; }
        void Collide(ICollideable other);
    }
}
