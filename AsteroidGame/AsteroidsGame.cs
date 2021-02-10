using System.Numerics;

namespace SimpleAsteroids
{
    public class AsteroidsGame : Game
    {
        public AsteroidsGame(IDrawer drawer) : base(drawer)
        {
        }

        private Ship ship;

        public override bool IsOver => ship.Destroyed;
        public int Score => GetFromScene<Scorer>()[0].Score;

        protected override void IternalStart()
        {
            CreateOnScene<Arena>(Vector2.Zero).FromZeroSteps = 25;
            ship = CreateOnScene<Ship>(Vector2.Zero);
            ship.Transform.Direction = new Vector2(1, 0);
            // ship.Velocity = new Vector2(1, 0);
            ship.Shoot();

            // CreateOnScene<CooldownSpawner<Asteroid>>(new Vector2(6, 6));
            // CreateOnScene<CooldownSpawner<Asteroid>>(new Vector2(-6, -6));
            CreateOnScene<CooldownSpawner<UFO>>(new Vector2(20, 20)).SpawnCooldown = 30;
        }

        protected override void IternalUpdate()
        {
        }
    }
}
