using System;
using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public class Arena : GameObject
    {
        public int FromZeroSteps { get; set; }

        public override void Update()
        {
            foreach (var item in Get<GameObject>())
                if (IsCrossedBorders(item))
                    item.Position = RevertedPosition(item.Position);
        }

        private bool IsCrossedBorders(GameObject gameObject)
        {
            float x = gameObject.Position.X;
            float y = gameObject.Position.Y;

            return (x >= FromZeroSteps || x <= -FromZeroSteps || y >= FromZeroSteps || y <= -FromZeroSteps);
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
