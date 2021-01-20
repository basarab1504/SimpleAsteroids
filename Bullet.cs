namespace SimpleAsteroids
{
    public class Bullet : GameObject
    {
        public float LifeTime { get; set; } = 3;
        private float lifeTimeLeft;

        public Bullet()
        {
            lifeTimeLeft = LifeTime;
            Symbol = 'B';
        }

        public override void Update()
        {
            Position += Velocity;
            
            lifeTimeLeft--;
            if (lifeTimeLeft == 0)
                Destroyed = true;
        }
    }
}
