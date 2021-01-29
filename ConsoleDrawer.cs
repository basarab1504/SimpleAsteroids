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
                var pos = GetDrawPositions(item);
                if (pos.x < window.GetLength(0) && pos.y < window.GetLength(1))
                    window[pos.y, pos.x] = item.Symbol;
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

        private (int x, int y) GetDrawPositions(GameObject gameObject)
        {
            int x = (int)(xCenter + gameObject.Position.X);
            int y = (int)(yCenter + gameObject.Position.Y);
            return (x: x, y: y);
        }

        private void Clear()
        {
            for (int i = 0; i < window.GetLength(0); i++)
                for (int j = 0; j < window.GetLength(0); j++)
                    window[i, j] = '_';
        }
    }
}