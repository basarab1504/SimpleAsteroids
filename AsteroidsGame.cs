using System.Numerics;

namespace SimpleAsteroids
{
    public class AsteroidsGame : Game
    {
        public AsteroidsGame(IDrawer drawer) : base(drawer)
        {
        }

        public override bool IsOver => false;
        public int Score => Get<Scorer>()[0].Score;

        protected override void IternalStart()
        {
            // Create<Arena>(Vector2.Zero).FromZeroSteps = 5;
            Create<Ship>(new Vector2(200, 300));
            // Create<CooldownSpawner<Asteroid>>(new Vector2(300, 400));
            // Create<CooldownSpawner<Asteroid>>(new Vector2(-4, -4));
            Create<CooldownSpawner<UFO>>(new Vector2(300, 400)).SpawnCooldown = 15;
        }

        protected override void IternalUpdate()
        {

        }
    }
}
