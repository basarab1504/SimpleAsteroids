using System.Numerics;

namespace SimpleAsteroids
{
    public class LaserBullet : Bullet
    {
        public override void OnCollide(GameObject other)
        {

        }
    }

    public class Bullet : GameObject
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;

        public Bullet()
        {
            Symbol = 'B';
            ColliderRadius = 0.5f;
            Size = new Vector2(0.5f, 0.5f);
        }

        public override void Start()
        {
            base.Start();
            lifeTimeLeft = LifeTime;
        }

        public override void Update()
        {
            Position += Velocity;

            if (lifeTimeLeft == 0)
                Destroyed = true;
            lifeTimeLeft--;
        }
    }
}
