using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class GameComponent : IGameComponent
    {
        public bool Active { get; set; }
        public bool Destroyed { get; set; }
        public Game Game { private get; set; }
        public Transform Transform { get; set; } = new Transform();

        public virtual void Initialize()
        {
            Active = true;
        }

        public T Create<T>(Vector2 position) where T : GameComponent, new()
        {
            var created = new T();
            created.Game = Game;
            Game.Add(created);
            created.Transform.Position = position;
            return created;
        }

        public IReadOnlyCollection<T> Get<T>() where T : class, IGameComponent
        {
            return Game.Get<T>();
        }
    }
}
