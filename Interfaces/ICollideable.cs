using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICollideable : IGameComponent
    {
        int Type { get; }
        Points Points { get; }
        void Collide(ICollideable other);
    }
}
