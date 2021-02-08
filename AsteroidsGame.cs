using System.Numerics;

namespace SimpleAsteroids
{
    public class AsteroidsGame : Game
    {
        public AsteroidsGame(IDrawer drawer) : base(drawer)
        {
        }

        public override bool IsOver => false;
        public int Score => GetFromScene<Scorer>()[0].Score;

        protected override void IternalStart()
        {
            // Create<Arena>(Vector2.Zero).FromZeroSteps = 5;
            CreateOnScene<Ship>(Vector2.Zero);
            // ship.Direction = new Vector2(1, 0);
            // ship.Velocity = new Vector2(1, 0);

            // Create<CooldownSpawner<Asteroid>>(new Vector2(10, 10));
            // Create<CooldownSpawner<Asteroid>>(new Vector2(-4, -4));
            // Create<CooldownSpawner<UFO>>(new Vector2(50, 50)).SpawnCooldown = 30;
        }

        protected override void IternalUpdate()
        {

        }
    }
}
