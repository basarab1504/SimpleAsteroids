namespace SimpleAsteroids
{
    public class Asteroid : GameObject
    {
        public Asteroid()
        {
            Symbol = 'A';
        }

        public override void Update()
        {
            Position += Velocity;
        }

        public override void OnCollide(GameObject other)
        {
            base.OnCollide(other);

            var asteroid = Create<Asteroid>();
            asteroid.Position = Position + Direction;
            asteroid.Velocity = Velocity;
            asteroid.Direction = Direction;
        }
    }
}
