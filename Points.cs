using System.Numerics;

namespace SimpleAsteroids
{
    public struct Points
    {
        public float Top { get; }
        public float Bottom { get; }
        public float Left { get; }
        public float Right { get; }

        public Vector2 Center { get; }
        public Vector2 TopRight { get; }
        public Vector2 BottomLeft { get; }

        public Points(Vector2 center, Vector2 halfSize)
        {
            TopRight = center + halfSize;
            BottomLeft = center - halfSize;

            this.Center = center;
            this.Top = TopRight.Y;
            this.Right = TopRight.X;
            this.Bottom = BottomLeft.Y;
            this.Left = BottomLeft.X;
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
