using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICanvas
    {
        void Draw(Vector2 position, Vector2 size);
    }
}