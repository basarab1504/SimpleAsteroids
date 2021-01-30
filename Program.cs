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
            // CollisionTest();
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

            game.Create<Arena>(Vector2.Zero).FromZeroSteps = 5;
            var ship = game.Create<Ship>(Vector2.Zero);
            ship.Size = new Vector2(3, 1);
            ship.Direction = new Vector2(1, 0);
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

            game.Create<Arena>(Vector2.Zero).FromZeroSteps = 5;

            var asteroid = game.Create<MockAsteroid>(Vector2.Zero);
            asteroid.Velocity = new Vector2(1, 0);

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(asteroid.Position == new Vector2(5, 0));
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(asteroid.Position == new Vector2(-2, 0));
        }

        static void ConsoleTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();
            game.Create<Ship>(Vector2.Zero);
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
            game.Create<Ship>(Vector2.Zero);
            game.Create<NoChildAsteroid>(new Vector2(0, 4));
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
            game.Create<Ship>(Vector2.Zero);
            game.Update();
        }

        static void LaserBeamTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(15, 15));
            game.Start();

            var ship = game.Create<Ship>(Vector2.Zero);

            ship.ShootLaser();

            game.Update();
            System.Console.WriteLine(game.Get<GameObject>().Count == 4);
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameObject>().Count == 1);

        }

        static void LaserBeamCollisionTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(15, 15));
            game.Start();

            var ship = game.Create<Ship>(Vector2.Zero);
            var asteroid = game.Create<NoChildAsteroid>(new Vector2(0, 4));
            var asteroid2 = game.Create<NoChildAsteroid>(new Vector2(0, 3));

            game.Update();
            game.Update();
            ship.ShootLaser();
            game.Update();
            System.Console.WriteLine(game.Get<GameObject>().Count == 4);
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameObject>().Count == 1);
        }

        static void AsteroidsGameTest()
        {
            GameSession session = new GameSession(new AsteroidsGame(new ConsoleDrawer(10, 10)));
            session.Start();
        }

        static void SpawnerTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var asteroidSpawner = game.Create<CooldownSpawner<MockAsteroid>>(new Vector2(3, 3));
            var asteroidSpawner2 = game.Create<CooldownSpawner<MockAsteroid>>(new Vector2(-3, -3));

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 4);

            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 6);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void UFOSpawnerTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ufoSpawner = game.Create<CooldownSpawner<UFO>>(new Vector2(0, 3));
            ufoSpawner.SpawnCooldown = 5;

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 2);

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 3);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void AsteroidsArenaTest()
        {
            Game game = new AsteroidsGame(new ConsoleDrawer(10, 10));

            // var ship = game.Create<Ship>(new Vector2(4, 0));
            game.Start();
            game.Update();

            var ship = game.Get<Ship>()[0];

            ship.Position = new Vector2(4, 0);
            ship.Direction = new Vector2(1, 0);
            ship.Velocity = new Vector2(1, 0);

            game.Update();
            System.Console.WriteLine(ship.Position == new Vector2(5, 0));
            game.Update();
            System.Console.WriteLine(ship.Position == new Vector2(-4, 0));
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(ship.Position == new Vector2(-1, 0));
            // System.Console.WriteLine(game.Score == 0);
        }

        static void PhysicsLayerTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = game.Create<Ship>(new Vector2(0, 1));
            var ship2 = game.Create<Ship>(new Vector2(0, -3));

            ship.Velocity = new Vector2(0, -1);
            ship.Direction = new Vector2(0, -1);

            ship2.Velocity = new Vector2(0, 1);
            ship2.Direction = new Vector2(0, 1);

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 2);

            var asteroid = game.Create<MockAsteroid>(new Vector2(0, 2));

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 2);
            // System.Console.WriteLine(game.Score == 1);
        }

        static void NoMoveUFOTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = game.Create<Ship>(new Vector2(0, 3));

            var ufo = game.Create<UFO>(new Vector2(-4, 0));

            var ufo2 = game.Create<UFO>(new Vector2(4, 0));

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            // System.Console.WriteLine(game.Get<GameObject>()[3].Position == new Vector2(0, 1));
            // System.Console.WriteLine(game.Get<GameObject>()[4].Position == new Vector2(1, 1));
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 2);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void MoveUFOTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = game.Create<Ship>(new Vector2(2, 0));

            var ufo = game.Create<UFO>(new Vector2(-5, -3));
            ufo.Velocity = new Vector2(0, 1);

            // ufo.Target = ship;

            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameObject>().Count == 2);
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameObject>().Count == 1);
            game.Update();
            // System.Console.WriteLine(game.Score == 0);
        }

        static void CollisionTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = game.Create<Ship>(new Vector2(2, 0));
            ship.Direction = new Vector2(-1, 0);
            ship.Velocity = new Vector2(-1, 0);

            var asteroid = game.Create<NoChildAsteroid>(new Vector2(-2, 0));
            asteroid.Velocity = new Vector2(1, 0);

            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 0);
            // System.Console.WriteLine(game.Score == 1);
        }

        static void TwoShipBulletTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = game.Create<Ship>(new Vector2(-3, 0));
            var ship2 = game.Create<Ship>(new Vector2(3, 0));

            ship.Direction = new Vector2(1, 0);
            ship2.Direction = new Vector2(-1, 0);

            ship.Shoot();
            ship2.Shoot();

            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 2);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void BulletTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = game.Create<Ship>(new Vector2(0, -2));

            ship.Shoot();

            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameObject>()[1].Position == new Vector2(0, 2));
            game.Update();
            game.Update();
            System.Console.WriteLine(game.Get<GameObject>().Count == 1);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void ManyBulletTest()
        {
            TestGame game = new TestGame(new ConsoleDrawer(10, 10));
            game.Start();

            var ship = game.Create<Ship>(new Vector2(0, -2));

            ship.Shoot();

            ship.Direction = new Vector2(1, 0);

            ship.Shoot();

            ship.Direction = new Vector2(-1, 0);

            ship.Shoot();

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>()[1].Position == new Vector2(0, 2));
            System.Console.WriteLine(game.Get<GameObject>()[2].Position == new Vector2(4, -2));
            System.Console.WriteLine(game.Get<GameObject>()[3].Position == new Vector2(-4, -2));

            game.Update();
            game.Update();

            System.Console.WriteLine(game.Get<GameObject>().Count == 1);
            // System.Console.WriteLine(game.Score == 0);
        }
    }
}
