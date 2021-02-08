using System.Numerics;

namespace SimpleAsteroids
{
    public struct Points
    {
        public float Top { get; }
        public float Bottom { get; }
        public float Left { get; }
        public float Right { get; }

        public Points(Vector2 center, Vector2 halfSize)
        {
            Vector2 topRight = center + halfSize;
            Vector2 bottomLeft = center - halfSize;

            this.Top = topRight.Y;
            this.Right = topRight.X;
            this.Bottom = bottomLeft.Y;
            this.Left = bottomLeft.X;
        }

        public bool Intersect(Points other)
        {
            bool outside =
              Right <= other.Left ||
              Left >= other.Right ||
              Bottom >= other.Top ||
              Top <= other.Bottom;
            return (outside == false);
        }
    }
}
