using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class AsteroidsGame : Game
    {
        private Ship playerShip;

        public override void Start()
        {
            base.Start();
            playerShip = Create<Ship>(Vector2.Zero);
            Create<CooldownSpawner<Asteroid>>(new Vector2(4, 4));
            Create<CooldownSpawner<Asteroid>>(new Vector2(-4, -4));
            Create<CooldownSpawner<UFO>>(new Vector2(0, -4));
        }

        public override void Update()
        {
            base.Update();

            if (playerShip.Destroyed)
                Start();
        }
    }

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

        //нужно лучше
        public IEnumerable<T> Get<T>() where T : GameObject
        {
            foreach(var item in gameObjects)
                if(item is T)
                    yield return item as T;
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
                item.Update();

            //удаление
            gameObjects.RemoveAll(x => x.Destroyed);
        }
    }
}
