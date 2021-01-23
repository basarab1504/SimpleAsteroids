using System.Numerics;

namespace SimpleAsteroids
{
    public class AsteroidsGame : Game
    {
        public override void Start()
        {
            base.Start();
            Create<Ship>(Vector2.Zero);
            Create<CooldownSpawner<Asteroid>>(new Vector2(4, 4));
            Create<CooldownSpawner<Asteroid>>(new Vector2(-4, -4));
            Create<CooldownSpawner<UFO>>(new Vector2(0, -4)).SpawnCooldown = 5;
        }

        public override void Update()
        {
            base.Update();

            if (Get<Ship>().Count == 0)
            {
                System.Console.WriteLine($"+==+==|YOUR SCORE: {Score}|==+==+");
                Start();
            }
        }
    }
}
