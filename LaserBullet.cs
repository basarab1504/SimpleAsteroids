using System.Numerics;

namespace SimpleAsteroids
{
    public class LaserBullet : GameObject
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;

        public LaserBullet()
        {
            Transform.Size = new Vector2(0.5f, 0.5f);
        }

        public override void Start()
        {
            base.Start();
            Create<RectangleShape>().Transform = Transform;
            var coll = Create<RectangleCollider>();
            coll.Transform = Transform;
            coll.Type = 1;
            lifeTimeLeft = LifeTime;
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
