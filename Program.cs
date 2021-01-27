using System;
using System.Numerics;

namespace SimpleAsteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            // StaticShipTest();
            // CollisionTest();
            // BulletTest();
            // ManyBulletTest();
            // TwoShipBulletTest();
            // NoMoveUFOTest();
            // MoveUFOTest();
            // PhysicsLayerTest();
            // SpawnerTest();
            // UFOSpawnerTest();
            // LaserBeamTest();
            // LaserBeamCollisionTest();
            AsteroidsArenaTest();
            // AsteroidsGameTest();
        }

        static void StaticShipTest()
        {
            Game game = new Game();
            game.Create<Ship>(Vector2.Zero);
            game.Update();
        }

        static void LaserBeamTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(Vector2.Zero);

            ship.ShootLaser();

            game.Update();
            System.Console.WriteLine(game.TEST.Count == 4);
            game.Update();
            game.Update();
            System.Console.WriteLine(game.TEST.Count == 1);

        }

        static void LaserBeamCollisionTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(Vector2.Zero);
            var asteroid = game.Create<NoChildAsteroid>(new Vector2(0, 4));
            var asteroid2 = game.Create<NoChildAsteroid>(new Vector2(0, 3));

            game.Update();
            game.Update();
            ship.ShootLaser();
            game.Update();
            System.Console.WriteLine(game.TEST.Count == 5);
            game.Update();
            game.Update();
            System.Console.WriteLine(game.TEST.Count == 1);
        }

        static void AsteroidsGameTest()
        {
            Game game = new AsteroidsGame();
            game.Start();
            while (true)
            {
                game.Update();
                Console.ReadKey();
            }
        }

        static void SpawnerTest()
        {
            Game game = new Game();

            var asteroidSpawner = game.Create<CooldownSpawner<MockAsteroid>>(new Vector2(3, 3));
            var asteroidSpawner2 = game.Create<CooldownSpawner<MockAsteroid>>(new Vector2(-3, -3));

            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 4);

            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 6);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void UFOSpawnerTest()
        {
            Game game = new Game();

            var ufoSpawner = game.Create<CooldownSpawner<UFO>>(new Vector2(0, 3));
            ufoSpawner.SpawnCooldown = 5;

            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 2);

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 3);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void AsteroidsArenaTest()
        {
            Game game = new AsteroidsGame();

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
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(0, 1));
            var ship2 = game.Create<Ship>(new Vector2(0, -3));

            ship.Velocity = new Vector2(0, -1);
            ship.Direction = new Vector2(0, -1);

            ship2.Velocity = new Vector2(0, 1);
            ship2.Direction = new Vector2(0, 1);

            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 2);

            var asteroid = game.Create<MockAsteroid>(new Vector2(0, 2));

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 2);
            // System.Console.WriteLine(game.Score == 1);
        }

        static void NoMoveUFOTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(0, 3));

            var ufo = game.Create<UFO>(new Vector2(-4, 0));

            var ufo2 = game.Create<UFO>(new Vector2(4, 0));

            game.Update();
            game.Update();
            game.Update();
            game.Update();
            // System.Console.WriteLine(game.TEST[3].Position == new Vector2(0, 1));
            // System.Console.WriteLine(game.TEST[4].Position == new Vector2(1, 1));
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 2);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void MoveUFOTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(2, 0));

            var ufo = game.Create<UFO>(new Vector2(-3, -3));
            ufo.Velocity = new Vector2(0, 1);

            // ufo.Target = ship;

            game.Update();
            game.Update();
            System.Console.WriteLine(game.TEST.Count == 3);
            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(game.TEST.Count == 1);
            game.Update();
            // System.Console.WriteLine(game.Score == 0);
        }

        static void CollisionTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(Vector2.Zero);
            ship.Position = new Vector2(2, 0);
            ship.Direction = new Vector2(-1, 0);
            ship.Velocity = new Vector2(-1, 0);

            var asteroid = game.Create<MockAsteroid>(Vector2.Zero);
            asteroid.Position = new Vector2(-2, 0);
            asteroid.Velocity = new Vector2(1, 0);

            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 1);
            // System.Console.WriteLine(game.Score == 1);
        }

        static void TwoShipBulletTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(-3, 0));
            var ship2 = game.Create<Ship>(new Vector2(3, 0));

            ship.Direction = new Vector2(1, 0);
            ship2.Direction = new Vector2(-1, 0);

            ship.Shoot();
            ship2.Shoot();

            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 2);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void BulletTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(0, -2));

            ship.Shoot();

            game.Update();
            game.Update();
            System.Console.WriteLine(game.TEST[1].Position == new Vector2(0, 2));
            game.Update();
            game.Update();
            System.Console.WriteLine(game.TEST.Count == 1);
            // System.Console.WriteLine(game.Score == 0);
        }

        static void ManyBulletTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(0, -2));

            ship.Shoot();

            ship.Direction = new Vector2(1, 0);

            ship.Shoot();

            ship.Direction = new Vector2(-1, 0);

            ship.Shoot();

            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST[1].Position == new Vector2(0, 2));
            System.Console.WriteLine(game.TEST[2].Position == new Vector2(4, -2));
            System.Console.WriteLine(game.TEST[3].Position == new Vector2(-4, -2));

            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 1);
            // System.Console.WriteLine(game.Score == 0);
        }
    }
}
