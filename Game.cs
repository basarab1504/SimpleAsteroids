using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class Game
    {
        List<GameObject> toAdd = new List<GameObject>();
        List<GameObject> toDestroy = new List<GameObject>();
        List<GameObject> gameObjects = new List<GameObject>();

        ConsoleDrawer consoleDrawer = new ConsoleDrawer(5);
        Physics physics = new Physics();

        public List<GameObject> TEST => gameObjects;

        public T Create<T>(Vector2 position) where T : GameObject, new()
        {
            var gameObject = new T() { Position = position };
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

        public virtual void Start()
        {
            toAdd.Clear();
            gameObjects.Clear();
            toDestroy.Clear();
        }

        public virtual void Update()
        {
            //создать
            gameObjects.AddRange(toAdd);
            toAdd.ForEach(x => x.Start());
            toAdd.Clear();

            //включить

            //рисовка
            consoleDrawer.Update(gameObjects);

            //физика
            physics.Update(gameObjects);

            //ввод

            //логика
            foreach (var item in gameObjects)
            {
                item.Update();
                if (item.Destroyed)
                    toDestroy.Add(item);
            }

            //очки
            //удаление
            foreach (var item in toDestroy)
                gameObjects.Remove(item);
            toDestroy.Clear();
        }
    }
}
