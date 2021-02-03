using System.Numerics;

namespace SimpleAsteroids
{
    public class Transform
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new Vector2(0, 1);
        public Vector2 Size { get; set; } = new Vector2(1, 1);
    }
}
