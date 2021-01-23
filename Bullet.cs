namespace SimpleAsteroids
{
    public class Bullet : GameObject
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;

        public Bullet()
        {
            Symbol = 'B';
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
