using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class Physics
    {
        public void Update(IList<GameObject> toCheck)
        {
            for (int i = 0; i <= toCheck.Count; i++)
            {
                for (int j = i + 1; j < toCheck.Count; j++)
                {
                    var iElement = toCheck[i];
                    var jElement = toCheck[j];
                    if (iElement.Position == jElement.Position)
                    {
                        iElement.OnCollide(jElement);
                        jElement.OnCollide(iElement);
                        break;
                    }
                }
            }
        }
    }

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
        public bool Destroyed { get; private set; }

        public char Symbol { get; set; }

        public void Update()
        {
            Position += Direction;
        }

        public void OnCollide(GameObject other)
        {
            Destroyed = true;
        }
    }

    public class Game
    {
        List<GameObject> gameObjects = new List<GameObject>();
        ConsoleDrawer consoleDrawer = new ConsoleDrawer(3);
        Physics physics = new Physics();

        public void Start()
        {
            var ship = Create();
            ship.Position = new Vector2(2, 0);
            ship.Direction = new Vector2(-1, 0);
            ship.Symbol = 'S';

            var asteroid = Create();
            asteroid.Position = new Vector2(-2, 0);
            asteroid.Direction = new Vector2(1, 0);
            asteroid.Symbol = 'A';
        }

        public GameObject Create()
        {
            var gameObject = new GameObject();
            gameObjects.Add(gameObject);
            return gameObject;
        }

        public void Update()
        {

            //создать
            //включить
            //физика
            physics.Update(gameObjects);
            //логика
            foreach (var item in gameObjects)
                item.Update();
            //рисовка
            consoleDrawer.Update(gameObjects);
            //удаление
            gameObjects.RemoveAll(x => x.Destroyed);
        }
    }
}
