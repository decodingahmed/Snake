using System;
using System.Collections.Generic;
using System.Text;
using SnakeNet.GameObjects;

namespace SnakeNet.Content
{
    public static class ImageHelper
    {
        /* 
         * |╔|═|╗|
         * |║| |║|
         * |╚|═|╝|
         */

        public static string GetImage(MoveDirection previous, MoveDirection next)
        {
            if (previous == MoveDirection.Up && (next == MoveDirection.None || next == MoveDirection.Up))
                return Images.SnakeBodyUp;
            else if (previous == MoveDirection.Down && (next == MoveDirection.None || next == MoveDirection.Down))
                return Images.SnakeBodyDown;
            else if (previous == MoveDirection.Left && (next == MoveDirection.None || next == MoveDirection.Left))
                return Images.SnakeBodyLeft;
            else if (previous == MoveDirection.Right && (next == MoveDirection.None || next == MoveDirection.Right))
                return Images.SnakeBodyRight;

            // ╝
            else if ((previous == MoveDirection.Right && next == MoveDirection.Up) ||
                (previous == MoveDirection.Down && next == MoveDirection.Left))
            {
                return Images.SnakeBodyUpLeft;
            }
            // ╚
            else if ((previous == MoveDirection.Left && next == MoveDirection.Up) || 
                (previous == MoveDirection.Down && next == MoveDirection.Right))
            {
                return Images.SnakeBodyUpRight;
            }
            // ╔
            else if ((previous == MoveDirection.Left && next == MoveDirection.Down) ||
                (previous == MoveDirection.Up && next == MoveDirection.Right))
            {
                return Images.SnakeBodyDownRight;
            }
            // ╗
            else if ((previous == MoveDirection.Right && next == MoveDirection.Down) ||
                (previous == MoveDirection.Up && next == MoveDirection.Left))
            {
                return Images.SnakeBodyDownLeft;
            }

            return "E";
        }
    }
}
