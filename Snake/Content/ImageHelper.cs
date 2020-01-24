using System;

namespace SnakeNet.Content
{
    public static class ImageHelper
    {
        /**
         * |╔|═|╗|
         * |║| |║|
         * |╚|═|╝|
         */

        public static string GetImage(MoveDirection previous, MoveDirection current)
        {
            if (previous == current)
            {
                if (previous == MoveDirection.Down)
                    return Images.SnakeBodyDown;
                else if (previous == MoveDirection.Left)
                    return Images.SnakeBodyLeft;
                else if (previous == MoveDirection.Right)
                    return Images.SnakeBodyRight;
                else if (previous == MoveDirection.Up)
                    return Images.SnakeBodyUp;
            }
            else
            {
                // ╔
                if ((previous == MoveDirection.Right && current == MoveDirection.Up) ||
                   (previous == MoveDirection.Down && current == MoveDirection.Left))
                {
                    return Images.SnakeBodyDownRight;
                }
                // ╗
                else if ((previous == MoveDirection.Left && current == MoveDirection.Up) ||
                    (previous == MoveDirection.Down && current == MoveDirection.Right))
                {
                    return Images.SnakeBodyDownLeft;
                }
                // ╝
                else if ((previous == MoveDirection.Left && current == MoveDirection.Down) ||
                    (previous == MoveDirection.Up && current == MoveDirection.Right))
                {
                    return Images.SnakeBodyUpLeft;
                }
                // ╚
                else if ((previous == MoveDirection.Right && current == MoveDirection.Down) ||
                    (previous == MoveDirection.Up && current == MoveDirection.Left))
                {
                    return Images.SnakeBodyUpRight;
                }
            }

            return "E";
        }
    }
}
