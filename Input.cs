using System;

namespace SimpleAsteroids
{
    public class Input
    {
        public void Update()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Spacebar:
                        Console.WriteLine("You pressed F1!");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
