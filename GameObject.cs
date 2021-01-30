using System;
using System.Collections.Generic;
using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public abstract class GameObject : IDrawable
    {
        public Game Game { set; private get; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new Vector2(0, 1);
        public Vector2 Size { get; set; } = new Vector2(1, 1);
        public float ColliderRadius { get; set; } = 1;
        public Vector2 Velocity { get; set; }
        public bool Destroyed { get; protected set; }
        //удалить
        public char Symbol { get; set; }
        public Color Color { get; set; }
        //
        public int ScoreForDestroying { get; set; }

        //можно лучше
        protected T Create<T>(Vector2 position) where T : GameObject, new()
        {
            return Game.Create<T>(position);
        }

        protected IEnumerable<T> Get<T>() where T : GameObject
        {
            return Game.Get<T>();
        }

        public virtual void Start()
        {

        }

        public abstract void Update();

        public virtual void OnInput(ConsoleKey key)
        {

        }

        public virtual void OnCollide(GameObject other)
        {
            Destroyed = true;
        }

        public void Draw(ICanvas canvas)
        {
            List<Vector2> drawables = new List<Vector2>();
            for (int i = 0; i < Size.X; i++)
                for (int j = 0; j < Size.Y; j++)
                    drawables.Add(new Vector2(Position.X + i, Position.Y + j));
            canvas.Draw(drawables);
        }
    }
}
