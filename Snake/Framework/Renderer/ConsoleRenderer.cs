using System;

namespace SnakeNet.Framework.Renderer
{
    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {
            Console.CursorVisible = false;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void DrawText(string text, int x, int y)
        {
            // TODO: In the future, this needs to be console window size aware (render target size)
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
