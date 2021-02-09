using System.Numerics;

namespace SimpleAsteroids
{
    public class UFO : Component, IStartable, IUpdateable
    {
        private float cooldown;
        public float GunForce { get; set; } = 1;
        public Vector2 GunPos => Transform.Position + Transform.Direction * 2;
        public Vector2 Velocity { get; set; }
        public float ShootingCooldown { get; set; } = 3;
        public float DistanceToKeep { get; set; } = 3;

        public void Start()
        {
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Collided += Collide;
            coll.Type = 0;
        }

        public void Update()
        {
            Transform.Position += Velocity;

            cooldown--;

            foreach (var target in GetFromScene<Ship>())
            {
                Transform.Direction = Vector2.Normalize(target.Transform.Position - Transform.Position);

                if ((target.Transform.Position - Transform.Position).Length() > DistanceToKeep)
                {
                    Velocity = Transform.Direction;
                }
                else if (cooldown <= 0)
                {
                    Shoot();
                    cooldown = ShootingCooldown;
                }
            }
        }

        private void Collide(ICollideable other)
        {
            Parent.Destroy();
        }

        private void Shoot()
        {
            var bullet = CreateOnScene<Bullet>(GunPos);
            bullet.Transform.Direction = Transform.Direction;
            bullet.Velocity = Transform.Direction * GunForce;
        }
    }
}
