namespace SimpleAsteroids
{
    public interface IDrawable : IComponent
    {
        void Draw(ICanvas canvas);
    }
}
