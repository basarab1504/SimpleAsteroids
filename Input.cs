using System;

namespace SimpleAsteroids
{
    public class Input
    {
        public event Action<ConsoleKey> KeyPressed;

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                KeyPressed(key.Key);
            }
        }
    }
}
