using System.Numerics;

namespace SimpleAsteroids
{
    public class UFO : GameObject
    {
        private float cooldown;
        public float GunForce { get; set; } = 1;
        public Vector2 GunPos => Position + Direction;
        public float ShootingCooldown { get; set; } = 3;
        public float DistanceToKeep { get; set; } = 3;

        public UFO()
        {
            Symbol = 'U';
            ScoreForDestroying = 2;
        }

        public override void Update()
        {
            Position += Velocity;

            cooldown--;

            foreach (var target in Get<Ship>())
            {
                Direction = Vector2.Normalize(target.Position - Position);

                if ((target.Position - Position).Length() > DistanceToKeep)
                    Velocity = Direction;
                else
                    Velocity = Vector2.Zero;

                if (cooldown <= 0 && !target.Destroyed)
                {
                    Shoot();
                    cooldown = ShootingCooldown;
                }
            }
        }

        private void Shoot()
        {
            var bullet = Create<Bullet>(GunPos);
            bullet.Direction = Direction;
            bullet.Velocity = Direction * GunForce;
        }
    }
}
