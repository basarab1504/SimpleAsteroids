using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public interface IUpdateable
    {
        void Update();
    }

    public interface IPositionable
    {
        Vector2 Position { get; set; }
        Vector2 Direction { get; set; }
        Vector2 Size { get; set; }
    }

    public interface IDrawable
    {
        char Symbol { get; set; }
    }

    public class GameObject : IPositionable, IUpdateable, IDrawable
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new Vector2(0, 1);
        public Vector2 Size { get; set; }

        public char Symbol { get; set; }

        public void Update()
        {
            Position += Direction;
        }
    }

    public class Game
    {
        List<GameObject> gameObjects = new List<GameObject>();
        ConsoleDrawer consoleDrawer = new ConsoleDrawer(3);

        public void Start()
        {
            var ship = Create();
            ship.Symbol = 'S';

            var asteroid = Create();
            asteroid.Symbol = 'A';
            asteroid.Position = new Vector2(-2, 1);
        }

        public GameObject Create()
        {
            var gameObject = new GameObject();
            gameObjects.Add(gameObject);
            return gameObject;
        }

        public void Update()
        {
            foreach (var item in gameObjects)
                item.Update();
            //создать
            //включить
            //физика
            //логика
            //рисовка
            //удаление
            consoleDrawer.Update(gameObjects);
        }
    }
}
