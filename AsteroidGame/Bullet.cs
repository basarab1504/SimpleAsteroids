using System.Numerics;

namespace SimpleAsteroids
{
    public class Bullet : Component, IStartable, IUpdateable
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;
        public Vector2 Velocity { get; set; }
        public int Type { get; set; }

        public void Start()
        {
            // Transform.Size = new Vector2(0.5f, 0.5f);
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Collided += Collide;
            coll.Type = Type;
            lifeTimeLeft = LifeTime;
        }

        private void Collide(ICollideable other)
        {
            Parent.Destroy();
        }

        public void Update(float deltaTime)
        {
            Transform.Position += Velocity * deltaTime;

            if (lifeTimeLeft <= 0)
                Parent.Destroy();
            lifeTimeLeft -= deltaTime;
        }
    }
}
