using System;
using System.Numerics;

namespace SimpleAsteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            // CollisionTest();
            BulletTest();
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
        }

        static void BulletTest()
        {
            Game game = new Game();

            var ship = game.Create<Ship>(Vector2.Zero);

            var bullet = game.Create<Bullet>(ship.GunPos);

            game.Start();
            game.Update();

            ship.Push(bullet);

            game.Update();
            game.Update();
            game.Update();
        }
    }
}
