using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICollideable : IComponent
    {
        int Layer { get; }
        Points Points { get; }
        void Collide(ICollideable other);
    }
}
