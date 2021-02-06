using System.Numerics;
using SFML.Graphics;

namespace SimpleAsteroids
{
    public class Bullet : GameComponent, IUpdateable
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;
        public Vector2 Velocity { get; set; }

        public Bullet()
        {
            Transform.Size = new Vector2(0.5f, 0.5f);
        }

        public override void Initialize()
        {
            base.Initialize();
            Create<RectangleShape>(Transform.Position).Transform = Transform;
            var coll = Create<RectangleCollider>(Transform.Position);
            coll.Collided += Collide;
            coll.Transform = Transform;
            coll.Type = 1;
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
