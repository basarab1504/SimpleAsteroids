using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class GameObject
    {
        public Game Game { set; private get; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new Vector2(0, 1);
        public Vector2 Size { get; set; } = new Vector2(1, 1);
        public float ColliderRadius { get; set; } = 1;
        public Vector2 Velocity { get; set; }
        public bool Destroyed { get; protected set; }
        public char Symbol { get; set; }
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
    }
}
