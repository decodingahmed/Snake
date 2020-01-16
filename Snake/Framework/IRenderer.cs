using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeNet.Framework
{
    public interface IRenderer
    {
        int Width { get; }
        int Height { get; }

        void DrawText(string text, int x, int y);
        void Clear();
    }
}
