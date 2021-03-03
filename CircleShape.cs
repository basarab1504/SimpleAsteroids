namespace SimpleAsteroids
{
    public class CircleShape : Component, IDrawable
    {
        public Points Points => GetPoints();
        public Color Color { get; set; }

        private Points GetPoints()
        {
            return new Points(Transform.Position, Transform.Size * 0.5f);
        }

        public void Draw(ICanvas canvas)
        {
            canvas.Draw(GetPoints(), Color);
        }
    }
}
