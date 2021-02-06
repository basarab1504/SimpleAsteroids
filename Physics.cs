using System.Collections.Generic;

namespace SimpleAsteroids
{
    public class Physics
    {
        //IReadOnlyList - позволяет взять по индексу, при этом ковариантный => позволяет брать более конкретный тип, чем указанный изначально
        public void Update(IReadOnlyList<ICollideable> collideables)
        {
            for (int i = 0; i <= collideables.Count; i++)
                for (int j = i + 1; j < collideables.Count; j++)
                {
                    var a = collideables[i];
                    var b = collideables[j];
                    if (a.Layer == b.Layer && Intersects(a, b))
                    {
                        a.Collide(b);
                        b.Collide(a);
                    }
                }
        }

        private static bool Intersects(ICollideable a, ICollideable b)
        {
            return a.Points.Intersect(b.Points);
        }
    }
}
