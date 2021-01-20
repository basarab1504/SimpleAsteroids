using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class GameObject : IPositionable, IUpdateable, IDrawable
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new Vector2(0, 1);
        public Vector2 Size { get; set; }
        public Vector2 Velocity { get; set; }
        public bool Destroyed { get; protected set; }

        public char Symbol { get; set; }

        public abstract void Update();

        public void OnCollide(GameObject other)
        {
            Destroyed = true;
        }
    }
}
