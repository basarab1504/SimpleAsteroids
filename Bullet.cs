using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public class Bullet : Component, IStartable, IUpdateable
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;
        public Vector2 Velocity { get; set; }

        public Bullet()
        {
            Transform.Size = new Vector2(0.5f, 0.5f);
        }

        public void Start()
        {
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Collided += Collide;
            coll.Type = BulletType;
            lifeTimeLeft = LifeTime;
        }

        private void Collide(ICollideable other)
        {
            Destroyed = true;
        }

        public void Update()
        {
            Transform.Position += Velocity;

            if (lifeTimeLeft == 0)
                Destroyed = true;
            lifeTimeLeft--;
        }
    }
}
