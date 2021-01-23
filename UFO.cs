using System.Numerics;

namespace SimpleAsteroids
{
    public class UFO : GameObject
    {
        private float cooldown;
        public float GunForce { get; set; } = 1;
        public Vector2 GunPos => Position + Direction;
        public Ship Target { get; set; }
        public float ShootingCooldown { get; set; } = 3;
        public float DistanceToKeep { get; set; } = 3;

        public UFO()
        {
            Symbol = 'U';
        }

        public override void Update()
        {
            Position += Velocity;

            cooldown--;
            
            if (Target != null)
            {
                Direction = Vector2.Normalize(Target.Position - Position);

                if ((Target.Position - Position).Length() > DistanceToKeep)
                    Velocity = Direction;
                else
                    Velocity = Vector2.Zero;

                if (cooldown <= 0 && !Target.Destroyed)
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
