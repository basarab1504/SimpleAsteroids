using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleAsteroids
{
    class Container
    {
        class PerType<T>
        {
            public static List<T> list = new List<T>();
        }

        public IReadOnlyList<T> Get<T>() => PerType<T>.list;
        public void Add<T>(T item) => PerType<T>.list.Add(item);
        public void Remove<T>(T item) => PerType<T>.list.Remove(item);
        public void Remove(GameObject gameObject)
        {

        }
    }
}
