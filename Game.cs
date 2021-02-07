using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public abstract class Game
    {
        List<GameObject> toAdd = new List<GameObject>();
        List<GameObject> toDestroy = new List<GameObject>();
        List<GameObject> gameObjects = new List<GameObject>();

        Container container = new Container();
        IDrawer drawer;
        Physics physics = new Physics();
        Input input = new Input();

        public abstract bool IsOver { get; }

        public Game(IDrawer drawer)
        {
            this.drawer = drawer;
        }

        public T Create<T>() where T : new()
        {
            T drawable = new T();
            container.Add<T>(drawable);
            return drawable;
        }

        public T Create<T>(Vector2 position) where T : GameObject, new()
        {
            var gameObject = new T();
            gameObject.Transform.Position = position;
            gameObject.Game = this;
            toAdd.Add(gameObject);
            return gameObject;
        }

        //нужно лучше
        public IList<T> Get<T>() where T : GameObject
        {
            IList<T> collection = new List<T>();
            foreach (var item in gameObjects)
                if (item is T)
                    collection.Add(item as T);
            return collection;
        }

        public void Start()
        {
            toAdd.Clear();
            gameObjects.Clear();
            toDestroy.Clear();
            IternalStart();
        }

        public void Update()
        {
            //создать
            gameObjects.AddRange(toAdd);
            //включить
            toAdd.ForEach(x => { x.Start(); input.KeyPressed += x.OnInput; });
            toAdd.Clear();

            //рисовка
            drawer.Update(container.Get<IDrawable>());

            //физика
            physics.Update(container.Get<ICollideable>());

            //ввод
            input.Update();

            //логика
            foreach (var item in gameObjects)
            {
                item.Update();
                if (item.Destroyed)
                    toDestroy.Add(item);
            }

            //удаление
            foreach (var item in toDestroy)
                gameObjects.Remove(item);
            toDestroy.Clear();
            
            IternalUpdate();
        }

        protected abstract void IternalStart();
        protected abstract void IternalUpdate();
    }
}
