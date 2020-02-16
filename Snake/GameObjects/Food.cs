using SnakeNet.Components;
using SnakeNet.Content;
using Gamework.Rendering;

namespace SnakeNet.GameObjects
{
    public class Food : ICollidable
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
