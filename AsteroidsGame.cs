using System.Numerics;

namespace SimpleAsteroids
{
    public class AsteroidsGame : Game
    {
        public override bool IsOver => Get<Ship>().Count == 0;
        public int Score => Get<Scorer>()[0].Score;

        protected override void IternalStart()
        {
            base.Start();
            Create<Arena>(Vector2.Zero).FromZeroSteps = 5;
            Create<Ship>(Vector2.Zero);
            // Create<CooldownSpawner<Asteroid>>(new Vector2(4, 4));
            // Create<CooldownSpawner<Asteroid>>(new Vector2(-4, -4));
            // Create<CooldownSpawner<UFO>>(new Vector2(0, -4)).SpawnCooldown = 5;
        }

        protected override void IternalUpdate()
        {

        }
    }
}
