using System.Collections.Generic;
using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SimpleAsteroids
{
    public class SFMLDrawer : IDrawer, ICanvas
    {
        RenderWindow window;

        public SFMLDrawer(uint width, uint height)
        {
            var videoMode = new VideoMode(width * 10, height * 10);
            window = new RenderWindow(videoMode, "Asteroids");
            window.SetActive(true);
            window.SetVerticalSyncEnabled(true);
            // window.SetFramerateLimit(10);
        }

        public void Update(IEnumerable<IDrawable> drawables)
        {
            window.DispatchEvents();
            window.Clear();

            foreach (var item in drawables)
                item.Draw(this);

            window.Display();
        }

        public void Draw(Points points, Color color)
        {
            var shape = new SFML.Graphics.CircleShape((points.TopRight - points.Center).Length());
            shape.Position = GetDrawPositions(points.Center);
            shape.FillColor = new SFML.Graphics.Color(color.r, color.g, color.b);
            window.Draw(shape);
        }

        private Vector2f GetDrawPositions(Vector2 pos)
        {
            float x = (int)(window.Size.X / 2 + pos.X);
            float y = (int)(window.Size.Y / 2 + pos.Y);
            return new Vector2f(x, y);
        }
    }
}