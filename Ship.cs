using System;
using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public class Ship : GameComponent, IUpdateable
    {
        public float GunForce { get; set; } = 2;
        public float LaserBeamLenght { get; set; } = 3;
        public Vector2 GunPos => Transform.Position + Transform.Direction * 2;
        public Vector2 Velocity { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            Create<RectangleShape>(Transform.Position).Transform = Transform;
            var coll = Create<RectangleCollider>(Transform.Position);
            coll.Collided += Collide;
            coll.Transform = Transform;
            coll.Layer = 0;
        }

        public void Update()
        {
            Transform.Position += Transform.Direction * Vector2.Abs(Velocity);
        }

        public void Thrust()
        {
            Velocity = Transform.Direction;
        }

        public void ShootLaser()
        {
            for (int i = 1; i <= LaserBeamLenght; i++)
                Create<LaserBullet>(GunPos + Transform.Direction * i).LifeTime = 1;
        }

        // public override void OnInput(ConsoleKey key)
        // {
        //     if (key == ConsoleKey.Spacebar)
        //         Shoot();
        //     else if (key == ConsoleKey.W)
        //     {
        //         Transform.Direction = -Transform.Direction;
        //         Velocity = -Velocity;
        //     }
        // }

        private void Collide(ICollideable other)
        {
            if (!(other is Ship) && !(other is ISpawner) && !(other is Arena))
                Destroyed = true;
        }

        public void Shoot()
        {
            var bullet = Create<Bullet>(GunPos);
            bullet.Transform.Direction = Transform.Direction;
            bullet.Velocity = Transform.Direction * GunForce;
        }
    }
}
