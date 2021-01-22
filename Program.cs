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
            UFOTest();
        }

        static void UFOTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(0, 1));

            var ufo = game.Create<UFO>(new Vector2(-2, 1));

            var ufo2 = game.Create<UFO>(new Vector2(3, 1));

            ufo.PlayerShip = ship;
            ufo2.PlayerShip = ship;

            game.Update();
            ufo.Shoot();
            ufo2.Shoot();
            game.Update();
            System.Console.WriteLine(game.TEST[3].Position == new Vector2(0, 1));
            System.Console.WriteLine(game.TEST[4].Position == new Vector2(1, 1));
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 2);
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

            game.Update();
            game.Update();
            game.Update();
            game.Update();

            System.Console.WriteLine(game.TEST.Count == 1);
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
        }

        static void BulletTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(new Vector2(0, -2));

            ship.Shoot();

            game.Update();
            game.Update();
            System.Console.WriteLine(game.TEST[1].Position == new Vector2(0, 1));
            game.Update();
            System.Console.WriteLine(game.TEST.Count == 1);
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

            System.Console.WriteLine(game.TEST[1].Position == new Vector2(0, 1));
            System.Console.WriteLine(game.TEST[2].Position == new Vector2(3, -2));
            System.Console.WriteLine(game.TEST[3].Position == new Vector2(-3, -2));

            game.Update();

            System.Console.WriteLine(game.TEST.Count == 1);
        }
    }
}
