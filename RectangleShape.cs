using System.Numerics;

namespace SimpleAsteroids
{
    public class RectangleShape : IDrawable
    {
        public Transform Transform { get; set; }

        public void Draw(ICanvas canvas)
        {
            canvas.Draw(Transform.Position, Transform.Size);
        }
    }
}
