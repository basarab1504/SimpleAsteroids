using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class ConsoleDrawer : IDrawer
    {
        private readonly int fromZeroSteps;
        private Dictionary<Vector2, char> map = new Dictionary<Vector2, char>();

        public ConsoleDrawer(int fromZeroSteps)
        {
            this.fromZeroSteps = fromZeroSteps;

            for (int y = fromZeroSteps; y >= -fromZeroSteps; y -= 1)
                for (int x = -fromZeroSteps; x <= fromZeroSteps; x += 1)
                    map.Add(new Vector2(x, y), '_');
        }

        public void Update(IEnumerable<GameObject> toCheck)
        {
            InDraw(toCheck);
            Draw();
            Clear();
        }

        private void InDraw(IEnumerable<GameObject> toCheck)
        {
            foreach (var item in toCheck)
            {
                var space = new Vector2((int)item.Position.X, (int)item.Position.Y);
                map[space] = item.Symbol;
            }
        }

        private void Draw()
        {
            for (int y = fromZeroSteps; y >= -fromZeroSteps; y -= 1)
            {
                for (int x = -fromZeroSteps; x <= fromZeroSteps; x += 1)
                    System.Console.Write($"{map[new Vector2(x, y)]} ");
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
            for (int y = fromZeroSteps; y >= -fromZeroSteps; y -= 1)
                for (int x = -fromZeroSteps; x <= fromZeroSteps; x += 1)
                    map[new Vector2(x, y)] = '_';
        }
    }
}