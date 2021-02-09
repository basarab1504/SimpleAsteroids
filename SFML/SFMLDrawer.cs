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
            window.SetFramerateLimit(10);
        }

        public void Update(IEnumerable<IDrawable> drawables)
        {
            window.DispatchEvents();
            window.Clear();

            foreach (var item in drawables)
                item.Draw(this);

            window.Display();
        }

        public void Draw(Vector2 postion, Vector2 size)
        {
            SFML.Graphics.RectangleShape shape = new SFML.Graphics.RectangleShape(new Vector2f(size.X, size.Y));
            shape.Position = GetDrawPositions(postion);
            shape.FillColor = Color.Red;
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