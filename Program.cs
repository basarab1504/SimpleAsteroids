using System;
using System.Numerics;

namespace SimpleAsteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            // CollisionTest();
            // BulletTest();
            // ManyBulletTest();
            // TwoShipBulletTest();
        }

        static void CollisionTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(Vector2.Zero);
            ship.Position = new Vector2(2, 0);
            ship.Direction = new Vector2(-1, 0);
            ship.Velocity = new Vector2(-1, 0);

            var asteroid = game.Create<Asteroid>(Vector2.Zero);
            asteroid.Position = new Vector2(-2, 0);
            asteroid.Velocity = new Vector2(1, 0);

            game.Start();
            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 0);
        }

        static void TwoShipBulletTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(-3, 0));
            var ship2 = game.Create<Ship>(new Vector2(3, 0));

            ship.Direction = new Vector2(1, 0);
            ship2.Direction = new Vector2(-1, 0);

            var bullet = game.Create<Bullet>(ship.GunPos);
            var bullet2 = game.Create<Bullet>(ship2.GunPos);

            game.Start();

            ship.Push(bullet);
            ship2.Push(bullet2);

            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 2);
        }

        static void BulletTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(0, -2));

            var bullet = game.Create<Bullet>(ship.GunPos);

            game.Start();

            ship.Push(bullet);

            game.Update();
            game.Update();
            game.Update();
            System.Console.WriteLine(bullet.Position == new Vector2(0, 2));
            game.Update();
            System.Console.WriteLine(bullet.Destroyed == true);
        }

        static void ManyBulletTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(0, -2));

            game.Start();

            var bullet1 = game.Create<Bullet>(ship.GunPos);
            ship.Push(bullet1);

            ship.Direction = new Vector2(1, 0);

            var bullet2 = game.Create<Bullet>(ship.GunPos);
            ship.Push(bullet2);

            ship.Direction = new Vector2(-1, 0);

            var bullet3 = game.Create<Bullet>(ship.GunPos);
            ship.Push(bullet3);

            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(bullet1.Position == new Vector2(0, 2));
            System.Console.WriteLine(bullet2.Position == new Vector2(4, -2));
            System.Console.WriteLine(bullet3.Position == new Vector2(-4, -2));

            game.Update();

            System.Console.WriteLine(bullet1.Destroyed == true);
            System.Console.WriteLine(bullet2.Destroyed == true);
            System.Console.WriteLine(bullet3.Destroyed == true);
        }
    }
}
