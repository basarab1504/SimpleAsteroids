using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class ConsoleDrawer
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
                foreach (var space in GetDrawPositions(item))
                    map[space] = item.Symbol;
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

        private IEnumerable<Vector2> GetDrawPositions(IPositionable positionable)
        {
            int halfSizeY = (int)Math.Floor(positionable.Size.Y * 0.5);
            int halfSizeX = (int)Math.Floor(positionable.Size.X * 0.5);

            for (int y = halfSizeY; y >= -halfSizeY; y -= 1)
                for (int x = -halfSizeX; x <= halfSizeX; x += 1)
                    yield return positionable.Position + new Vector2(x, y);
        }

        private void Clear()
        {
            for (int y = fromZeroSteps; y >= -fromZeroSteps; y -= 1)
                for (int x = -fromZeroSteps; x <= fromZeroSteps; x += 1)
                    map[new Vector2(x, y)] = '_';
        }
    }
}