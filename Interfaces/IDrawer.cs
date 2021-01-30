using System.Collections.Generic;

namespace SimpleAsteroids
{
    public interface IDrawer
    {
        void Update(IEnumerable<IDrawable> drawables);
    }
}