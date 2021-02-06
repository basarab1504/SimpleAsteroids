using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class Game
    {
        List<IGameComponent> toAwake = new List<IGameComponent>();
        List<IGameComponent> toAdd = new List<IGameComponent>();
        List<IGameComponent> toDestroy = new List<IGameComponent>();
        List<IGameComponent> components = new List<IGameComponent>();

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

        public void Add(IGameComponent component)
        {
            toAwake.Add(component);
            Categorize(component);
        }

        //нужно лучше
        public IReadOnlyList<T> Get<T>() where T : class, IGameComponent
        {
            List<T> collection = new List<T>();
            foreach (var item in components)
                if (item is T)
                    collection.Add(item as T);
            return collection;
        }

        public void Start()
        {
            toAwake.Clear();
            toAdd.Clear();
            components.Clear();
            toDestroy.Clear();
            IternalStart();
        }

        public void Update()
        {
            toAdd.AddRange(toAwake);
            toAdd.ForEach(x => x.Initialize());
            //создать
            components.AddRange(toAdd);
            //включить
            toAdd.Clear();
            toAwake.Clear();

            //рисовка
            drawer.Update(drawables);

            //физика
            physics.Update(collideables);

            //ввод
            input.Update();

            //логика
            foreach (var item in updateables)
            {
                if (item.Active)
                    item.Update();
                if (item.Destroyed)
                    toDestroy.Add(item);
            }

            //удаление
            foreach (var item in toDestroy)
            {
                components.Remove(item);
                Decategorize(item);
            }
            toDestroy.Clear();

            IternalUpdate();
        }

        protected abstract void IternalStart();
        protected abstract void IternalUpdate();

        private void Categorize(IGameComponent component)
        {
            if (component is IUpdateable)
                updateables.Add((IUpdateable)component);
            if (component is ICollideable)
                collideables.Add((ICollideable)component);
            if (component is IDrawable)
                drawables.Add((IDrawable)component);
        }

        private void Decategorize(IGameComponent component)
        {
            if (component is IUpdateable)
                updateables.Remove((IUpdateable)component);
            if (component is ICollideable)
                collideables.Remove((ICollideable)component);
            if (component is IDrawable)
                drawables.Remove((IDrawable)component);
        }
    }
}
