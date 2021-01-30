namespace SimpleAsteroids
{
    public interface ICollideable
    {
        System.Numerics.Vector2 Position { get; }
        void Collide(ICollideable other);
        bool ShouldCollide(ICollideable other);
    }
}
