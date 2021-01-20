using System;

namespace SimpleAsteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            game.Update();
            game.Update();
            game.Update();
        }
    }
}
