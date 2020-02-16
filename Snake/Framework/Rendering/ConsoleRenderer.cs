using System;

namespace SnakeNet.Framework.Rendering
{
    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer(int width, int height)
        {
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = width;
            Console.BufferHeight = Console.WindowHeight = height;
        }

        public int Width => Console.WindowWidth;

        public int Height => Console.WindowHeight;

        public void Clear()
        {
            Console.Clear();
        }

        public void DrawText(string text, int x, int y)
        {
            if (x < 0 || y < 0)
                return;

            if (x > Width || y > Height)
                return;

            // TODO: In the future, this needs to be console window size aware (render target size)
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
