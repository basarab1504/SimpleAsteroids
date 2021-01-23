using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class Game
    {
        int score;

        List<GameObject> toAdd = new List<GameObject>();
        List<GameObject> toDestroy = new List<GameObject>();
        List<GameObject> gameObjects = new List<GameObject>();

        ConsoleDrawer consoleDrawer = new ConsoleDrawer(5);
        Arena arena = new Arena(5);
        Physics physics = new Physics();

        public int Score => score;
        public List<GameObject> TEST => gameObjects;

        public T Create<T>(Vector2 position) where T : GameObject, new()
        {
            var gameObject = new T() { Position = position };
            gameObject.Game = this;
            toAdd.Add(gameObject);
            return gameObject;
        }

        //нужно лучше
        public ICollection<T> Get<T>() where T : GameObject
        {
            ICollection<T> collection = new List<T>();
            foreach (var item in gameObjects)
                if (item is T)
                    collection.Add(item as T);
            return collection;
        }

        public virtual void Start()
        {
            toAdd.Clear();
            gameObjects.Clear();
        }

        public virtual void Update()
        {
            //создать
            gameObjects.AddRange(toAdd);
            toAdd.ForEach(x => x.Start());
            toAdd.Clear();

            //включить

            //рисовка
            // consoleDrawer.Update(gameObjects);

            //физика
            physics.Update(gameObjects);

            //арена
            arena.Update(gameObjects);

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
            {
                score += item.ScoreForDestroying;
                gameObjects.Remove(item);
            }
            toDestroy.Clear();
        }
    }
}
