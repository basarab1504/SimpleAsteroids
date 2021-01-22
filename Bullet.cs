namespace SimpleAsteroids
{
    public class Bullet : GameObject
    {
        private float lifeTimeLeft;
        public float LifeTime { get; set; } = 3;

        public Bullet()
        {
            lifeTimeLeft = LifeTime;
            Symbol = 'B';
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
