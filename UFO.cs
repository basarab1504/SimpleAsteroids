using System.Numerics;

namespace SimpleAsteroids
{
    public class UFO : GameObject
    {
        private float cooldown;
        public float GunForce { get; set; } = 1;
        public Vector2 GunPos => Position + Direction;
        public Ship PlayerShip { get; set; }
        public float ShootingCooldown { get; set; } = 3;
        public float DistanceToKeep { get; set; } = 3;

        public UFO()
        {
            Symbol = 'U';
        }

        public override void Update()
        {
            Position += Velocity;
            Direction = Vector2.Normalize(PlayerShip.Position - Position);

            if((PlayerShip.Position - Position).Length() > DistanceToKeep)
                Velocity = Direction;
            else
                Velocity = Vector2.Zero;

            if (cooldown == 0 && !PlayerShip.Destroyed)
                Shoot();
            cooldown--;
        }

        private void Shoot()
        {
            var bullet = Create<Bullet>(GunPos);
            bullet.Direction = Direction;
            bullet.Velocity = Direction * GunForce;
            cooldown = ShootingCooldown;
        }
    }
}
