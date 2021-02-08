using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class Game
    {
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

        public T CreateOnScene<T>(Vector2 position) where T : IComponent, new()
        {
            T item = new T();
            Categorize(item);
            return item;
        }

        // public T Create<T>(Vector2 position) where T : IComponent, new()
        // {
        //     var IComponent = new T();
        //     IComponent.Transform.Position = position;
        //     IComponent.Game = this;
        //     toAwake.Add(IComponent);
        //     return IComponent;
        // }

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
            foreach (var item in awakeables)
                item.Awake();
            //включить
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
            input.Update();

            //логика
            foreach (var item in updateables)
            {
                item.Update();
            }

            //удаление
            foreach (var item in components)
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
