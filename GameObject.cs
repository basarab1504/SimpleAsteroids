using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public sealed class GameObject
    {
        private List<Component> components = new List<Component>();
        public Transform Transform => Get<Transform>();
        public Game Game { set; private get; }

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
            item.Parent = this;
            components.Add(item);
            return item;
        }

        public T Add<T>() where T : Component, new()
        {
            return Game.CreateOnScene<T>(this);
        }

        //плохо
        public T Get<T>() where T : Component
        {
            foreach (var item in components)
                if (item is T)
                    return item as T;
            return default(T);
        }

        // public void Remove<T>() where T : Component
        // {
        //     foreach (var item in components)
        //         if (item is T)
        //         {
        //             item.Parent = null;
        //             components.Remove(item);
        //         }
        // }

        public void Destroy()
        {
            foreach (var item in components)
                item.Destroyed = true;
        }
    }
}
