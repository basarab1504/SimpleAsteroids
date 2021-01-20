using System;
using System.Numerics;

namespace SimpleAsteroids
{
    public class Ship : GameObject
    {
        public float GunForce { get; set; } = 1;
        public Vector2 GunPos => Position + Direction;

        public Ship()
        {
            Symbol = 'S';
        }

        public override void Update()
        {
            Position += Direction * Vector2.Abs(Velocity);
        }

        public void Push(Bullet bullet)
        {
            bullet.Position = GunPos;
            bullet.Direction = Direction;
            bullet.Velocity = Direction * GunForce;
        }
    }
}
