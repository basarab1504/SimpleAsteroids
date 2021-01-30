using System;
using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public class Ship : GameObject
    {
        public float GunForce { get; set; } = 1;
        public float LaserBeamLenght { get; set; } = 3;
        public Vector2 GunPos => Position + Direction * 2;

        public override void Update()
        {
            Position += Direction * Vector2.Abs(Velocity);
        }

        public void ShootLaser()
        {
            for (int i = 1; i <= LaserBeamLenght; i++)
                Create<LaserBullet>(GunPos + Direction * i).LifeTime = 1;
        }

        public override void OnInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Spacebar)
                Shoot();
        }

        public override void Collide(ICollideable other)
        {
            if (!(other is Ship) && !(other is ISpawner) && !(other is Arena))
                Destroyed = true;
        }

        public void Shoot()
        {
            var bullet = Create<Bullet>(GunPos);
            bullet.Direction = Direction;
            bullet.Velocity = Direction * GunForce;
        }
    }
}
