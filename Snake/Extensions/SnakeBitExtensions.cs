using System;
using System.Collections.Generic;
using System.Text;
using SnakeNet.GameObjects;

namespace SnakeNet.Extensions
{
    public static class SnakeBitExtensions
    {
        public static MoveDirection GetRelativeDirection(this SnakeBit current, SnakeBit next)
        {
            if (current.X == next.X && current.Y == next.Y)
                throw new ArgumentException("Current and next cannot be in the same position");

            if (current.X == next.X)
            {
                // Moving vertically
                return current.Y < next.Y ? MoveDirection.Up : MoveDirection.Down;
            }
            else if (current.Y == next.Y)
            {
                // Moving horizontally
                return current.X < next.X ? MoveDirection.Left : MoveDirection.Right;
            }
            else
            {
                throw new NotSupportedException("Cannot move diagonally");
            }
        }
    }
}
