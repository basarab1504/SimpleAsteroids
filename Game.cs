using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class Game
    {
        List<GameObject> gameObjects = new List<GameObject>();
        ConsoleDrawer consoleDrawer = new ConsoleDrawer(3);
        Physics physics = new Physics();

        public List<GameObject> TEST => gameObjects;

        public void Start()
        {

        }

        public T Create<T>(Vector2 position) where T : GameObject, new()
        {
            var gameObject = new T() { Position = position };
            gameObjects.Add(gameObject);
            return gameObject;
        }

        public void Update()
        {

            //создать

            //включить

            //рисовка
            // consoleDrawer.Update(gameObjects);

            //физика
            physics.Update(gameObjects);

            //логика
            foreach (var item in gameObjects)
                item.Update();

            //удаление
            gameObjects.RemoveAll(x => x.Destroyed);
        }
    }
}
