using System.Numerics;

namespace SimpleAsteroids
{
    public class LaserBullet : Component, IAwakeable, IStartable, IUpdateable
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;
        public Vector2 Velocity { get; set; }

        public void Start()
        {
            Transform.Size = new Vector2(0.5f, 0.5f);
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Type = 1;
            lifeTimeLeft = LifeTime;
        }

        public void Update(float deltaTime)
        {
            Transform.Position += Velocity * deltaTime;

            if (lifeTimeLeft == 0)
                Parent.Destroy();
            lifeTimeLeft--;
        }
    }
}
