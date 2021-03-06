namespace SimpleAsteroids
{
    public class Scorer : Component, IUpdateable
    {
        private int score;
        public int Score => score;

        public void Update(float deltaTime)
        {
            foreach (var item in GetFromScene<Scoreable>())
                if (item.Destroyed)
                    score += item.ScoreForDestroying;
        }
    }
}