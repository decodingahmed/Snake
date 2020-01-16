using System;
using System.Collections.Generic;
using System.Text;
using SnakeNet.Content;
using SnakeNet.Framework;

namespace SnakeNet.GameObjects
{
    public class Food
    {
        public int X { get; }
        public int Y { get; }

        public Food(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw(IRenderer renderer)
        {
            renderer.DrawText(Images.Food, X, Y);
        }
    }
}
