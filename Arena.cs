using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class Arena
    {
        private readonly int fromZeroSteps;

        public Arena(int fromZeroSteps)
        {
            this.fromZeroSteps = fromZeroSteps;
        }

        public void Update(IEnumerable<GameObject> toCheck)
        {
            foreach (var item in toCheck)
                if (IsCrossedBorders(item))
                    item.Position = RevertedPosition(item.Position);
        }

        private bool IsCrossedBorders(GameObject gameObject)
        {
            float x = gameObject.Position.X;
            float y = gameObject.Position.Y;

            return (x >= fromZeroSteps || x <= -fromZeroSteps || y >= fromZeroSteps || y <= -fromZeroSteps);
        }

        private Vector2 RevertedPosition(Vector2 position)
        {
            float x = position.X;
            float y = position.Y;

            if (MathF.Abs(x) >= MathF.Abs(y))
                return new Vector2(-x, y);
            else
                return new Vector2(x, -y);
        }
    }
}
