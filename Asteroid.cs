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

        // public override void OnCollide(GameObject other)
        // {
        //     base.OnCollide(other);
        // }
    }
}
