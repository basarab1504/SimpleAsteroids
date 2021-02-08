using System.Numerics;

namespace SimpleAsteroids
{
    public class RectangleShape : Component, IDrawable
    {
        public void Draw(ICanvas canvas)
        {
            canvas.Draw(Transform.Position, Transform.Size);
        }
    }
}
