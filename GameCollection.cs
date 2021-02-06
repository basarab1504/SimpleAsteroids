using System;
using System.Collections.Generic;

namespace SimpleAsteroids
{
    class GameCollection
    {
        public event Action<IComponent> Added;
        public event Action<IComponent> Removed;

        List<IComponent> items = new List<IComponent>();

        public IReadOnlyList<IComponent> Items => items;

        public void Add(IComponent item)
        {
            items.Add(item);
            Added(item);
        }

        public void Remove(IComponent item)
        {
            items.Remove(item);
            Removed(item);
        }
    }

    class GameCollection<T>
    {
        List<T> items = new List<T>();
        List<T> cached = new List<T>();
        Predicate<T> filter;

        public GameCollection(Predicate<T> filter)
        {
            this.filter = filter;
        }

        public IReadOnlyList<T> FilteredItems
        {
            get
            {
                cached.Clear();
                foreach (var item in items)
                    if (filter(item))
                        cached.Add(item);
                return cached;
            }
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }
    }
}
