using System.Collections.Generic;

namespace SimpleAsteroids
{
    public class Physics
    {
        public void Update(IList<GameObject> toCheck)
        {
            for (int i = 0; i <= toCheck.Count; i++)
            {
                for (int j = i + 1; j < toCheck.Count; j++)
                {
                    var iElement = toCheck[i];
                    var jElement = toCheck[j];
                    if (iElement.Position == jElement.Position)
                    {
                        if (ShouldCollide(iElement, jElement))
                            iElement.OnCollide(jElement);
                        if (ShouldCollide(jElement, iElement))
                            jElement.OnCollide(iElement);
                        break;
                    }
                }
            }
        }

        private bool ShouldCollide(GameObject gameObject, GameObject other)
        {
            if (gameObject is Ship)
            {
                return !(other is Ship) && !(other is ISpawner);
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
