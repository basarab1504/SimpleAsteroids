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
                        iElement.OnCollide(jElement);
                        jElement.OnCollide(iElement);
                        break;
                    }
                }
            }
        }
    }
}
