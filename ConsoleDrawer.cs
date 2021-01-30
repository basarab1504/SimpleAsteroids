using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class ConsoleDrawer : IDrawer, ICanvas
    {
        private char[,] window;
        private int xCenter => window.GetLength(1) / 2;
        private int yCenter => window.GetLength(0) / 2;

        public ConsoleDrawer(int width, int height)
        {
            window = new char[height, width];
        }

        public void Update(IEnumerable<IDrawable> toDraw)
        {
            Clear();
            Draw(toDraw);
            Display();
        }

        public void Draw(Vector2 position, Vector2 size)
        {
            var pos = GetDrawPositions(position);
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    int x = pos.x + i;
                    int y = pos.y + j;
                    if (x < window.GetLength(0) && y < window.GetLength(1))
                        window[y, x] = '*';
                }
            }
        }

        private void Draw(IEnumerable<IDrawable> toDraw)
        {
            foreach (var item in toDraw)
                item.Draw(this);
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

        private (int x, int y) GetDrawPositions(Vector2 position)
        {
            int x = (int)(xCenter + position.X);
            int y = (int)(yCenter + position.Y);
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