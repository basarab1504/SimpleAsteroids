using System.Numerics;

namespace SimpleAsteroids
{
    public class AsteroidsGame : Game
    {
        private int score;

        public override void Start()
        {
            base.Start();
            Create<Arena>(Vector2.Zero).FromZeroSteps = 5;
            Create<Ship>(Vector2.Zero);
            // Create<CooldownSpawner<Asteroid>>(new Vector2(4, 4));
            // Create<CooldownSpawner<Asteroid>>(new Vector2(-4, -4));
            // Create<CooldownSpawner<UFO>>(new Vector2(0, -4)).SpawnCooldown = 5;
        }

        public override void Update()
        {
            base.Update();

            if (Get<Ship>().Count == 0)
            {
                System.Console.WriteLine($"+==+==|YOUR SCORE: {score}|==+==+");
                // Start();
            }
        }
    }
}
