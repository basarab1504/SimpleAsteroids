using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public class UFO : GameObject
    {
        private float cooldown;
        public float GunForce { get; set; } = 1;
        public Vector2 GunPos => Position + Direction * 2;
        public float ShootingCooldown { get; set; } = 3;
        public float DistanceToKeep { get; set; } = 3;

        public override void Update()
        {
            Position += Velocity;

            cooldown--;

            foreach (var target in Get<Ship>())
            {
                Direction = Vector2.Normalize(target.Position - Position);

                if ((target.Position - Position).Length() > DistanceToKeep)
                {
                    Velocity = Direction;
                }
                else if (cooldown <= 0)
                {
                    Shoot();
                    cooldown = ShootingCooldown;
                }
            }
        }

        public override void Collide(ICollideable other)
        {
            if (other is Ship || other is Bullet)
                Destroyed = true;
        }

        private void Shoot()
        {
            var bullet = Create<Bullet>(GunPos);
            bullet.Direction = Direction;
            bullet.Velocity = Direction * GunForce;
        }
    }
}
