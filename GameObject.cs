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

        }

        public T Add<T>() where T : Component
        {

        }

        public T Get<T>() where T : Component
        {

        }

        public T Remove<T>() where T : Component
        {

        }

        public void Destroy()
        {
            foreach (var item in components)
                item.Destroyed = true;
        }
    }
}
