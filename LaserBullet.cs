using System.Numerics;

namespace SimpleAsteroids
{
    public class LaserBullet : Component, IStartable, IUpdateable
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;
        public Vector2 Velocity { get; set; }

        public LaserBullet()
        {
            Transform.Size = new Vector2(0.5f, 0.5f);
        }

        public void Start()
        {
            Add<RectangleShape>();
            var coll = Add<RectangleCollider>();
            coll.Type = 1;
            lifeTimeLeft = LifeTime;
        }

        public void Update()
        {
            Transform.Position += Velocity;

            if (lifeTimeLeft == 0)
                Parent.Destroy();
            lifeTimeLeft--;
        }
    }
}
