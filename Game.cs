using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class Game
    {
        GameCollection gameCollection = new GameCollection();

        GameCollection<IDrawable> drawables = new GameCollection<IDrawable>(x => x.Active);
        GameCollection<ICollideable> collideables = new GameCollection<ICollideable>(x => x.Active);
        GameCollection<IUpdateable> updateables = new GameCollection<IUpdateable>(x => x.Active);

        IDrawer drawer;
        Physics physics = new Physics();
        Input input = new Input();

        public abstract bool IsOver { get; }

        public Game(IDrawer drawer)
        {
            this.drawer = drawer;
            gameCollection.Added += Categorize;
            gameCollection.Removed += Decategorize;
        }

        // public T Create<T>() where T : IComponent, new()
        // {
        //     T item = new T();
        //     Categorize(item);
        //     return item;
        // }

        // public T Create<T>(Vector2 position) where T : IComponent, new()
        // {
        //     var gameObject = new T();
        //     gameObject.Transform.Position = position;
        //     gameObject.Game = this;
        //     return gameObject;
        // }

        public void Start()
        {
            IternalStart();
        }

        public void Update()
        {
            toAdd.AddRange(toAwake);
            toAdd.ForEach(x => x.Initialize());
            //создать
            //включить

            //рисовка
            drawer.Update(drawables.FilteredItems);

            //физика
            physics.Update(collideables.FilteredItems);

            //ввод
            input.Update();

            //логика
            foreach (var item in updateables.FilteredItems)
            {
                item.Update();
                if (item.Destroyed)
                    toDestroy.Add(item);
            }

            //удаление
            foreach (var item in toDestroy)
            {
                gameObjects.Remove(item);
                if (drawables.ContainsKey(item))
                    drawables.Remove(item);
            }
            toDestroy.Clear();
            
            IternalUpdate();
        }

        protected abstract void IternalStart();
        protected abstract void IternalUpdate();
    }
}
