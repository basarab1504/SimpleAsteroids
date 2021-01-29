using System.Collections.Generic;

namespace SimpleAsteroids
{
    public class TestGame : Game
    {
        public TestGame(IDrawer drawer) : base(drawer)
        {
        }

        public override bool IsOver => false;

        protected override void IternalStart()
        {
        }

        protected override void IternalUpdate()
        {
        }
    }
}
