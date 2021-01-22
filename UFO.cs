using System.Numerics;

namespace SimpleAsteroids
{
    public class UFO : GameObject
    {
        public Ship PlayerShip { get; set; }
        public float FightDistance { get; set; } = 4;
        public float GunForce { get; set; } = 1;
        public Vector2 GunPos => Position + Direction;

        public UFO()
        {
            Symbol = 'U';
        }

        public override void Update()
        {
            Position += Direction * Vector2.Abs(Velocity);
            Direction = Vector2.Normalize(PlayerShip.Position - Position);
        }

        public void Shoot()
        {
            var bullet = Create<Bullet>(GunPos);
            bullet.Direction = Direction;
            bullet.Velocity = Direction * GunForce;
        }
    }
}
