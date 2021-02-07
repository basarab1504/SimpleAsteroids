using System.Numerics;

namespace SimpleAsteroids
{
    public class LaserBullet : GameComponent, IUpdateable
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;
        public Vector2 Velocity { get; set; }

        public LaserBullet()
        {
            Transform.Size = new Vector2(0.5f, 0.5f);
        }

        public override void Initialize()
        {
            base.Initialize();
            Create<RectangleShape>(Transform.Position).Transform = Transform;
            var coll = Create<RectangleCollider>(Transform.Position);
            coll.Transform = Transform;
            coll.Layer = 0;
            lifeTimeLeft = LifeTime;
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
