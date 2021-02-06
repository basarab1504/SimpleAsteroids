using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public class Bullet : GameObject
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;

        public Bullet()
        {
            Transform.Size = new Vector2(0.5f, 0.5f);
        }

        public override void Start()
        {
            base.Start();
            CreateDrawable<RectangleShape>().Transform = Transform;
            var coll = CreateCollideable<RectangleCollider>();
            coll.Collided += Collide;
            coll.Transform = Transform;
            coll.GameObject = this;
            lifeTimeLeft = LifeTime;
        }

        private void Collide(ICollideable other)
        {
            Destroyed = true;
        }

        public override void Update()
        {
            Transform.Position += Velocity;

            if (lifeTimeLeft == 0)
                Destroyed = true;
            lifeTimeLeft--;
        }
    }
}
