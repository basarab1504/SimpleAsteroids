using System.Numerics;

namespace SimpleAsteroids
{
    public interface IUpdateable
    {
        void Update();
    }

    public interface IPositionable
    {
        Vector2 Position { get; set; }
        Vector2 Direction { get; set; }
        Vector2 Size { get; set; }
    }

    public interface IDrawable
    {
        char Symbol { get; set; }
    }

}