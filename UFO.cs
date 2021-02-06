using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public class UFO : GameComponent, IUpdateable
    {
        private float cooldown;
        public float GunForce { get; set; } = 1;
        public Vector2 GunPos => Transform.Position + Transform.Direction * 2;
        public float ShootingCooldown { get; set; } = 3;
        public float DistanceToKeep { get; set; } = 3;
        public Vector2 Velocity { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            Create<RectangleShape>(Transform.Position);
            var coll = Create<RectangleCollider>(Transform.Position);
            coll.Collided += Collide;
            coll.Transform = Transform;
            coll.Type = 0;
        }

        public void Update()
        {
            Transform.Position += Velocity;

            cooldown--;

            foreach (var target in Get<Ship>())
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
            Destroyed = true;
        }

        private void Shoot()
        {
            var bullet = Create<Bullet>(GunPos);
            bullet.Transform.Direction = Transform.Direction;
            bullet.Velocity = Transform.Direction * GunForce;
        }
    }
}
