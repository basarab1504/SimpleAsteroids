using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class Component : IAwakeable
    {
        public GameObject Parent { get; set; }
        public bool Active { get; set; }
        public bool Destroyed { get; set; }

        public Transform Transform => Parent.Transform;

        public void Awake()
        {
            Active = true;
        }

        public T CreateOnScene<T>(Vector2 position) where T : Component, new()
        {
            return Parent.CreateOnScene<T>(position);
        }

        public IEnumerable<T> GetFromScene<T>() where T : Component
        {
            return Parent.GetFromScene<T>();
        }

        public T Add<T>(T item) where T : Component
        {
            return Parent.Add<T>(item);
        }

        public T Add<T>() where T : Component
        {
            return Parent.Add<T>(CreateOnScene<T>(Transform.Position));
        }

        public T Get<T>() where T : Component
        {
            return Parent.Get<T>();
        }

        public void Remove<T>() where T : Component
        {
            Parent.Remove<T>();
        }
    }
}
