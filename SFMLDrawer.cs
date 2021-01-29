using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SimpleAsteroids
{
    public class SFMLDrawer : IDrawer
    {
        RenderWindow window;

        public SFMLDrawer(VideoMode videoMode)
        {
            window = new RenderWindow(videoMode, "Asteroids");
            window.SetActive(true);
            window.SetVerticalSyncEnabled(true);
            window.SetFramerateLimit(10);
        }

        public void Update(IEnumerable<GameObject> toCheck)
        {
            window.DispatchEvents();
            window.Clear();
            foreach (var item in toCheck)
            {
                var shape = new CircleShape(item.ColliderRadius);
                shape.Position = GetDrawPositions(item);
                shape.FillColor = item.Color;
                window.Draw(shape);
            }
            window.Display();
        }

        private Vector2f GetDrawPositions(GameObject gameObject)
        {
            float x = (int)(window.Size.X / 2 + gameObject.Position.X);
            float y = (int)(window.Size.Y / 2 + gameObject.Position.Y);
            return new Vector2f(x, y);
        }
    }
}