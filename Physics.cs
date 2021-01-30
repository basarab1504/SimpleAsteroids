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
                    if (collideables[i].ShouldCollide(collideables[j]))
                        collideables[i].Collide(collideables[j]);
                    if (collideables[j].ShouldCollide(collideables[i]))
                        collideables[j].Collide(collideables[i]);
                }
        }
    }
}
