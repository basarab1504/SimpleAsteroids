using System;
using System.Collections.Generic;
using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public abstract class GameObject
    {
        public Transform Transform { get; set; } = new Transform();
        public Game Game { set; private get; }
        public Vector2 Velocity { get; set; }
        public bool Destroyed { get; protected set; }
        public int ScoreForDestroying { get; set; }

        public Vector2 Position => Transform.Position;

        //можно лучше
        protected T Create<T>(Vector2 position) where T : GameObject, new()
        {
            return Game.Create<T>(position);
        }

        protected T Create<T>() where T : new()
        {
            return Game.Create<T>(this);
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
    }
}
