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

        public SFMLDrawer(VideoMode videoMode)
        {
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

        public void Draw(IEnumerable<Vector2> points)
        {
            Vertex[] arr = GetDrawPositions(points);
            window.Draw(arr, PrimitiveType.Quads);
        }

        private Vertex[] GetDrawPositions(IEnumerable<Vector2> points)
        {
            List<Vertex> list = new List<Vertex>();
            foreach (var item in points)
            {
                float x = (int)(window.Size.X / 2 + item.X);
                float y = (int)(window.Size.Y / 2 + item.Y);
                list.Add(new Vertex(new Vector2f(x, y)));
            }
            return list.ToArray();
        }
    }
}