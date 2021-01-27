namespace SimpleAsteroids
{
    public class GameSession
    {
        private Game game;

        public GameSession(Game game)
        {
            this.game = game;
        }

        public void Start()
        {
            game.Start();
            while (!game.IsOver)
                game.Update();
        }
    }
}
