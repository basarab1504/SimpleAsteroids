using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class ConsoleDrawer : IDrawer, ICanvas
    {
        private struct Tile
        {
            private int i, j;

            public char Value { get; set; }
            public Color Color { get; set; }
            public int I => i;
            public int J => j;

            public Tile(int i, int j, Color color = default)
            {
                this.i = i;
                this.j = j;
                Value = '_';
                Color = color;
            }
        }

        private Dictionary<Color, ConsoleColor> colors = new Dictionary<Color, ConsoleColor>();

        private Tile[,] window;
        private int xCenter => window.GetLength(1) / 2;
        private int yCenter => window.GetLength(0) / 2;

        public ConsoleDrawer(int width, int height)
        {
            window = new Tile[height, width];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    window[i, j] = new Tile(i, j, new Color(0, 0, 0));

            colors.Add(new Color(0, 0, 0), ConsoleColor.Black);
            colors.Add(new Color(255, 255, 255), ConsoleColor.White);
            colors.Add(new Color(0, 255, 0), ConsoleColor.Green);
            colors.Add(new Color(255, 0, 0), ConsoleColor.Red);
            colors.Add(new Color(0, 0, 255), ConsoleColor.Blue);
            colors.Add(new Color(255, 255, 0), ConsoleColor.Yellow);
        }

        public void Update(IEnumerable<IDrawable> toDraw)
        {
            Clear();
            Draw(toDraw);
            Display();
        }

        public void Draw(Points points, Color color)
        {
            for (float i = points.Left; i <= points.Right; i++)
            {
                for (float j = points.Bottom; j <= points.Top; j++)
                {
                    var pos = GetDrawPositions(i, j);
                    var pos_x = pos.j;
                    var pos_y = pos.i;

                    if (pos_x < window.GetLength(1) && pos_x >= 0 && pos_y < window.GetLength(0) && pos_y >= 0)
                    {
                        window[pos_y, pos_x].Value = '*';
                        window[pos_y, pos_x].Color = color;
                    }
                }
            }
            Console.ResetColor();
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
                {
                    Console.ForegroundColor = colors[window[i, j].Color];
                    System.Console.Write($" {window[i, j].Value} ");
                    Console.ResetColor();
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("======");
        }

        private (int i, int j) GetDrawPositions(float x, float y)
        {
            int _x = (int)(xCenter + x);
            int _y = (int)(yCenter + y);
            return (i: _x, j: _y);
        }

        private void Clear()
        {
            for (int i = 0; i < window.GetLength(0); i++)
                for (int j = 0; j < window.GetLength(0); j++)
                {
                    window[i, j].Value = '_';
                    window[i, j].Color = new Color(0, 0, 0);
                }
        }
    }
}