namespace SnakeNet.Framework.Rendering
{
    public interface IRenderer
    {
        int Width { get; }
        int Height { get; }

        void DrawText(string text, int x, int y);
        void Clear();
    }
}
