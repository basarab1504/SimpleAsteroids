using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class Game
    {
        List<IComponent> toAdd = new List<IComponent>();
        List<IComponent> components = new List<IComponent>();

        List<IAwakeable> awakeables = new List<IAwakeable>();
        List<IStartable> startables = new List<IStartable>();
        List<IDrawable> drawables = new List<IDrawable>();
        List<ICollideable> collideables = new List<ICollideable>();
        List<IUpdateable> updateables = new List<IUpdateable>();

        IDrawer drawer;
        Physics physics = new Physics();
        Input input = new Input();

        public abstract bool IsOver { get; }

        public Game(IDrawer drawer)
        {
            this.drawer = drawer;
        }

        public T CreateOnScene<T>(Vector2 position) where T : Component, new()
        {
            T item = Create<T>();
            GameObject gameObject = new GameObject();
            gameObject.Game = this;
            Transform transform = Create<Transform>();
            transform.Position = position;
            gameObject.Add<Transform>(transform);
            gameObject.Add<T>(item);
            return item;
        }

        public T CreateOnScene<T>(GameObject parent) where T : Component, new()
        {
            T item = Create<T>();
            parent.Add<T>(item);
            return item;
        }

        private T Create<T>() where T : Component, new()
        {
            var component = new T();
            toAdd.Add(component);
            return component;
        }

        //ужасно
        public IReadOnlyList<T> GetFromScene<T>() where T : IComponent
        {
            List<T> ts = new List<T>();
            foreach (var item in components)
                if (item is T)
                    ts.Add((T)item);
            return ts;
        }

        public void Start()
        {
            awakeables.Clear();
            startables.Clear();
            components.Clear();
            collideables.Clear();
            drawables.Clear();
            updateables.Clear();
            IternalStart();
        }

        public void Update()
        {
            //создать
            foreach (var item in toAdd)
                Categorize(item);
            toAdd.Clear();

            //включить
            foreach (var item in awakeables)
                item.Awake();
            foreach (var item in startables)
                item.Start();
            // toAdd.ForEach(x => { x.Start(); input.KeyPressed += x.OnInput; });

            components.AddRange(awakeables);

            awakeables.Clear();
            startables.Clear();

            //рисовка
            drawer.Update(drawables);

            //физика
            physics.Update(collideables);

            //ввод
            // input.Update();

            //логика
            foreach (var item in updateables)
                if (item.Active && !item.Destroyed)
                    item.Update();

            //удаление
            foreach (var item in components)
                if (item.Destroyed)
                    Decategorize(item);
            components.RemoveAll(x => x.Destroyed);

            IternalUpdate();
        }

        protected abstract void IternalStart();
        protected abstract void IternalUpdate();

        private void Categorize(object obj)
        {
            if (obj is ICollideable)
                collideables.Add((ICollideable)obj);
            if (obj is IDrawable)
                drawables.Add((IDrawable)obj);
            if (obj is IUpdateable)
                updateables.Add((IUpdateable)obj);
            if (obj is IAwakeable)
                awakeables.Add((IAwakeable)obj);
            if (obj is IStartable)
                startables.Add((IStartable)obj);
        }

        private void Decategorize(object obj)
        {
            if (obj is ICollideable)
                collideables.Remove((ICollideable)obj);
            if (obj is IDrawable)
                drawables.Remove((IDrawable)obj);
            if (obj is IUpdateable)
                updateables.Remove((IUpdateable)obj);
            if (obj is IAwakeable)
                awakeables.Remove((IAwakeable)obj);
            if (obj is IStartable)
                startables.Remove((IStartable)obj);
        }
    }
}
