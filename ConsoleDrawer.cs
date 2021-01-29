using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class ConsoleDrawer : IDrawer
    {
        private char[,] window;
        private int xCenter => window.GetLength(1) / 2;
        private int yCenter => window.GetLength(0) / 2;

        public ConsoleDrawer(int width, int height)
        {
            window = new char[height, width];
        }

        public void Update(IEnumerable<GameObject> toCheck)
        {
            Clear();
            Draw(toCheck);
            Display();
        }

        private void Draw(IEnumerable<GameObject> toCheck)
        {
            foreach (var item in toCheck)
            {
                int x = (int)(xCenter + item.Position.X);
                int y = (int)(yCenter + item.Position.Y);
                if (x < window.GetLength(0) && y < window.GetLength(1))
                    window[y, x] = item.Symbol;
            }
        }

        private void Display()
        {
            for (int i = 0; i < window.GetLength(0); i++)
            {
                for (int j = 0; j < window.GetLength(1); j++)
                    System.Console.Write($" {window[i, j]} ");
                System.Console.WriteLine();
            }
            System.Console.WriteLine("======");
        }

        private IEnumerable<Vector2> GetDrawPositions(GameObject gameObject)
        {
            int halfSizeY = (int)Math.Floor(gameObject.Size.Y * 0.5);
            int halfSizeX = (int)Math.Floor(gameObject.Size.X * 0.5);

            System.Console.WriteLine($"{gameObject.GetType()} {halfSizeX}:{halfSizeY}");

            for (int y = halfSizeY; y >= -halfSizeY; y -= 1)
                for (int x = -halfSizeX; x <= halfSizeX; x += 1)
                    yield return gameObject.Position + new Vector2(x, y);
        }

        private void Clear()
        {
            for (int i = 0; i < window.GetLength(0); i++)
                for (int j = 0; j < window.GetLength(0); j++)
                    window[i, j] = '_';
        }
    }
}