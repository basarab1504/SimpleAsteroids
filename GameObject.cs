using System;
using System.Collections.Generic;
using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public sealed class GameObject
    {
        private List<IComponent> components = new List<IComponent>();
        public Transform Transform { get; set; }
        public Game Game { set; private get; }

        public GameObject()
        {
            Transform = Add<Transform>();
            components.Add(Transform);
        }

        public T CreateOnScene<T>(Vector2 position) where T : Component, new()
        {
            return Game.CreateOnScene<T>(position);
        }

        public IEnumerable<T> GetFromScene<T>() where T : Component
        {
            return Game.GetFromScene<T>();
        }

        public T Add<T>(T item) where T : Component
        {
            components.Add(item);
            return item;
        }

        //плохо
        public T Get<T>() where T : Component
        {
            foreach (var item in components)
                if (item is T)
                    return item as T;
            return default(T);
        }

        public void Remove<T>() where T : Component
        {
            foreach (var item in components)
                if (item is T)
                    components.Remove(item);
        }

        public void Destroy()
        {
            foreach (var item in components)
                item.Destroyed = true;
        }
    }
}
