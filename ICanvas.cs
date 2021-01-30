using System.Collections.Generic;
using System.Numerics;

namespace SimpleAsteroids
{
    public interface ICanvas
    {
        void Draw(IEnumerable<Vector2> points);
    }
}