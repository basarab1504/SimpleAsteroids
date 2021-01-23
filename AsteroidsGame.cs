using System.Numerics;

namespace SimpleAsteroids
{
    public class AsteroidsGame : Game
    {
        private Ship playerShip;

        public override void Start()
        {
            base.Start();
            playerShip = Create<Ship>(Vector2.Zero);
            Create<CooldownSpawner<Asteroid>>(new Vector2(4, 4));
            Create<CooldownSpawner<Asteroid>>(new Vector2(-4, -4));
            Create<CooldownSpawner<UFO>>(new Vector2(0, -4)).SpawnCooldown = 5;
        }

        public override void Update()
        {
            base.Update();

            if (playerShip.Destroyed)
                Start();
        }
    }
}
