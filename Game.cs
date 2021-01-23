using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class Game
    {
        List<GameObject> toAdd = new List<GameObject>();
        List<GameObject> gameObjects = new List<GameObject>();

        ConsoleDrawer consoleDrawer = new ConsoleDrawer(5);
        Arena arena = new Arena(5);
        Physics physics = new Physics();

        public List<GameObject> TEST => gameObjects;

        public T Create<T>(Vector2 position) where T : GameObject, new()
        {
            var gameObject = new T() { Position = position };
            gameObject.Game = this;
            toAdd.Add(gameObject);
            return gameObject;
        }

        public void Update()
        {
            //создать
            gameObjects.AddRange(toAdd);
            toAdd.Clear();

            //включить

            //рисовка
            consoleDrawer.Update(gameObjects);

            //физика
            physics.Update(gameObjects);

            //арена
            arena.Update(gameObjects);

            //логика
            foreach (var item in gameObjects)
                item.Update();

            //удаление
            gameObjects.RemoveAll(x => x.Destroyed);
        }
    }
}
