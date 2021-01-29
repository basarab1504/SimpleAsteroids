using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace SimpleAsteroids
{
    public class SFMLDrawer : IDrawer
    {
        RenderWindow window;

        public SFMLDrawer(VideoMode videoMode)
        {
            window = new RenderWindow(videoMode, "Asteroids");
            // window.SetActive(true);
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
                shape.Position = new SFML.System.Vector2f(item.Position.X, item.Position.Y);
                shape.FillColor = item.Color;
                window.Draw(shape);
            }
            window.Display();
        }
    }
}