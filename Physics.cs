using System.Collections.Generic;
using System.Linq;

namespace SimpleAsteroids
{
    public class Physics
    {
        //ужас
        public void Update(IEnumerable<ICollideable> collideables)
        {
            foreach (var item in collideables)
                collideables.FirstOrDefault(x => x.ShouldCollide(item))?.Collide(item);
        }
        
        private bool ShouldCollide(GameObject gameObject, GameObject other)
        {
            if (gameObject is Ship)
            {
                return !(other is Ship) && !(other is ISpawner) && !(other is Arena);
            }
            else if (gameObject is Asteroid)
            {
                return other is Ship || other is Bullet;
            }
            else if (gameObject is UFO)
            {
                return other is Ship || other is Bullet;
            }
            else if (gameObject is ISpawner)
            {
                return false;
            }
            else if (gameObject is LaserBullet)
            {
                return false;
            }
            return true;
        }
    }
}
