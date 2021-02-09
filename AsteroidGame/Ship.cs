using System.Numerics;

namespace SimpleAsteroids
{
    public class Ship : Component, IStartable, IUpdateable
    {
        public float GunForce { get; set; } = 2;
        public float LaserBeamLenght { get; set; } = 3;
        public Vector2 GunPos => Transform.Position + Transform.Direction * 2;
        public Vector2 Velocity { get; set; }
        public int BulletType { get; set; }

        public void Start()
        {
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Collided += Collide;
            coll.Type = 2;
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
                CreateOnScene<LaserBullet>(GunPos + Transform.Direction * i).LifeTime = 1;
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
            Parent.Destroy();
        }

        public void Shoot()
        {
            var bullet = CreateOnScene<Bullet>(GunPos);
            bullet.Type = BulletType;
            bullet.Transform.Direction = Transform.Direction;
            bullet.Velocity = Transform.Direction * GunForce;
        }
    }
}
