using System;
using System.Collections.Generic;
using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public abstract class GameObject : IDrawable, ICollideable
    {
        private ICollideable Collideable { get; set; }
        public Game Game { set; private get; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new Vector2(0, 1);
        public Vector2 Size { get; set; } = new Vector2(1, 1);
        public Vector2 Velocity { get; set; }
        public bool Destroyed { get; protected set; }
        public int ScoreForDestroying { get; set; }

        public GameObject()
        {
            Collideable = new CircleCollider()
            {
                GameObject = this
            };
        }

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

        public void Draw(ICanvas canvas)
        {
            canvas.Draw(Position, Size);
        }

        public virtual void Collide(ICollideable other)
        {
            // Destroyed = true;
        }

        public bool ShouldCollide(ICollideable other)
        {
            return Collideable.ShouldCollide(other);
        }
    }
}
