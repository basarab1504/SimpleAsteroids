using System;
using System.Numerics;

namespace SimpleAsteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            // ConsoleTest();
            // SFMLTest();
            // InputTest();
            // DrawTest();

            // AsteroidsArenaTest();
            // AsteroidsGameTest();

            // StaticShipTest();
            CollisionTest();
            // BulletTest();
            // ManyBulletTest();
            // TwoShipBulletTest();
            // ArenaTest();
            // NoMoveUFOTest();
            // MoveUFOTest();
            // PhysicsLayerTest();
            // SpawnerTest();
            // UFOSpawnerTest();
            // LaserBeamTest();
            // LaserBeamCollisionTest();
        }

        static void DrawTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));

            game.Start();

            // game.Add<Arena>(Vector2.Zero).FromZeroSteps = 5;
            var ship = new Ship();
            game.Add(ship);
            ship.Transform.Size = new Vector2(3, 1);
            ship.Transform.Direction = new Vector2(1, 0);
            ship.Velocity = new Vector2(1, 0);

            // while (true)
            //     game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
        }

        static void ArenaTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            // game.Add<Arena>(Vector2.Zero).FromZeroSteps = 5;

            var asteroid = new MockAsteroid();
            game.Add(asteroid);
            asteroid.Velocity = new Vector2(1, 0);

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(asteroid.Transform.Position == new Vector2(5, 0));
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(asteroid.Transform.Position == new Vector2(-2, 0));
        }

        static void ConsoleTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();
            game.Add(new Ship());
            game.Update();
            game.Get<Ship>()[0].Shoot();
            game.Update();
            game.Update();
            game.Update();
        }

        static void SFMLTest()
        {
            AsteroidsGame game = new AsteroidsGame(new SFMLDrawer(new SFML.Window.VideoMode(800, 600)));
            game.Start();

            while (!game.IsOver)
                game.Update();
        }

        static void InputTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();
            game.Add(new Ship());
            var asteroid = new NoChildAsteroid();
            asteroid.Transform.Position = new Vector2(0, 4);
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<Asteroid>().Count == 0);
        }

        static void StaticShipTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();
            game.Add(new Ship());
            game.Update();
        }

        static void LaserBeamTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(15, 15));
            game.Start();

            var ship = new Ship();
            game.Add(ship);

            ship.ShootLaser();

            game.Update();
            System.Console.WriteLine(game.Get<GameComponent>().Count == 4);
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameComponent>().Count == 1);

        }

        static void LaserBeamCollisionTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(15, 15));
            game.Start();

            var ship = new Ship();
            game.Add(ship);
            var asteroid = new NoChildAsteroid();
            asteroid.Transform.Position = new Vector2(0, 4);
            var asteroid2 = new NoChildAsteroid();
            asteroid.Transform.Position = new Vector2(0, 3);

            game.Update();
            game.Update();
            ship.ShootLaser();
            game.Update();
            System.Console.WriteLine(game.Get<GameComponent>().Count == 4);
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameComponent>().Count == 1);
        }

        static void AsteroidsGameTest()
        {
            GameSession session = new GameSession(new AsteroidsGame(new SFMLDrawer(new SFML.Window.VideoMode(800, 600))));
            session.Start();
        }

        static void SpawnerTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var asteroidSpawner = new CooldownSpawner<MockAsteroid>();
            asteroidSpawner.Transform.Position = new Vector2(3, 3);
            var asteroidSpawner2 = new CooldownSpawner<MockAsteroid>();
            asteroidSpawner2.Transform.Position = new Vector2(-3, -3);

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 4);

            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 6);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void UFOSpawnerTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ufoSpawner = new CooldownSpawner<UFO>();
            ufoSpawner.Transform.Position = new Vector2(0, 3);
            ufoSpawner.SpawnCooldown = 5;

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 2);

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 3);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void AsteroidsArenaTest()
        {
            Game game = new AsteroidsGame(new ConsoleDrawer(10, 10));
            var ship = new Ship();
            game.Add(ship);
            // ship.Transform.Position = new Vector2(4, 0);
            game.Start();
            game.Update();

            ship.Transform.Position = new Vector2(4, 0);
            ship.Transform.Direction = new Vector2(1, 0);
            ship.Velocity = new Vector2(1, 0);

            game.Update();
            System.Console.WriteLine(ship.Transform.Position == new Vector2(5, 0));
            game.Update();
            System.Console.WriteLine(ship.Transform.Position == new Vector2(-4, 0));
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(ship.Transform.Position == new Vector2(-1, 0));
            // System.Console.WriteLine(game.Score == 0);
        }

        static void PhysicsLayerTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = new Ship();
            ship.Transform.Position = new Vector2(0, 1);
            var ship2 = new Ship();
            ship2.Transform.Position = new Vector2(0, -3);

            ship.Velocity = new Vector2(0, -1);
            ship.Transform.Direction = new Vector2(0, -1);

            ship2.Velocity = new Vector2(0, 1);
            ship2.Transform.Direction = new Vector2(0, 1);

            game.Add(ship);
            game.Add(ship2);

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 2);

            var asteroid = new MockAsteroid();
            asteroid.Transform.Position = new Vector2(0, 2);
            game.Add(asteroid);

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 2);
            // System.Console.WriteLine(game.Score == 1);
        }

        static void NoMoveUFOTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = new Ship();
            ship.Transform.Position = new Vector2(0, 3);
            game.Add(ship);

            var ufo = new UFO();
            ufo.Transform.Position = new Vector2(-4, 0);
            game.Add(ufo);

            var ufo2 = new UFO();
            ufo2.Transform.Position = new Vector2(4, 0);
            game.Add(ufo2);

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            // System.Console.WriteLine(game.Get<GameComponent>()[3].Transform.Position == new Vector2(0, 1));
            // System.Console.WriteLine(game.Get<GameComponent>()[4].Transform.Position == new Vector2(1, 1));
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 2);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void MoveUFOTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();
            var ship = new Ship();
            // ship.Transform.Position = new Vector2(2, 0);
            ship.Transform.Position = new Vector2(2, 0);
            game.Add(ship);

            // var ufo = game.Add<UFO>(new Vector2(-5, -3));
            var ufo = new UFO();
            ufo.Transform.Position = new Vector2(-5, -3);
            ufo.Velocity = new Vector2(0, 1);
            game.Add(ufo);

            // ufo.Target = ship;

            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameComponent>().Count == 2);
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameComponent>().Count == 1);
            game.Update();
            // System.Console.WriteLine(game.Score == 0);
        }

        static void CollisionTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));

            game.Start();

            var ship = new Ship();
            ship.Game = game;
            game.Add(ship);

            ship.Transform.Position = new Vector2(2, 0);
            ship.Transform.Direction = new Vector2(-1, 0);
            ship.Velocity = new Vector2(-1, 0);

            var asteroid = new NoChildAsteroid();
            asteroid.Game = game;
            asteroid.Transform.Position = new Vector2(-2, 0);
            asteroid.Velocity = new Vector2(1, 0);
            game.Add(asteroid);

            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 0);
            // System.Console.WriteLine(game.Score == 1);
        }

        static void TwoShipBulletTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();
            var ship = new Ship();
            game.Add(ship);
            ship.Transform.Position = new Vector2(-4, 0);
            var ship2 = new Ship();
            ship2.Transform.Position = new Vector2(4, 0);

            ship.Transform.Direction = new Vector2(1, 0);
            ship2.Transform.Direction = new Vector2(-1, 0);

            ship.Shoot();
            ship2.Shoot();

            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 2);
        }

        static void BulletTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();
            var ship = new Ship();
            game.Add(ship);
            ship.Transform.Position = new Vector2(0, -2);

            ship.Shoot();

            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameComponent>()[1].Transform.Position == new Vector2(0, 4));
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameComponent>().Count == 1);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void ManyBulletTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();
            var ship = new Ship();
            game.Add(ship);
            ship.Transform.Position = new Vector2(0, -2);

            ship.Shoot();

            ship.Transform.Direction = new Vector2(1, 0);

            ship.Shoot();

            ship.Transform.Direction = new Vector2(-1, 0);

            ship.Shoot();

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>()[1].Transform.Position == new Vector2(0, 4));
            System.Console.WriteLine(game.Get<GameComponent>()[2].Transform.Position == new Vector2(6, -2));
            System.Console.WriteLine(game.Get<GameComponent>()[3].Transform.Position == new Vector2(-6, -2));

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameComponent>().Count == 1);
            // System.Console.WriteLine(game.Score == 0);
        }
    }
}
