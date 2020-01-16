using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Framework;

namespace SnakeNet.GameObjects
{
    public class Snake
    {
        private readonly IList<SnakeBit> _snake;

        public MoveDirection Direction { get; set; } = MoveDirection.Right;

        public Snake(int lengthOfSnake)
        {
            _snake = InitSnake(lengthOfSnake);
        }

        public void Update(TimeSpan elapsed)
        {
            for (var i = _snake.Count - 1; i >= 0; i--)
            {
                (var previous, var current, var next) = GetSnakeBits(i, _snake);

                // Update head
                if (i == 0)
                {
                    switch (Direction)
                    {
                        case MoveDirection.Up:
                            current.Y -= 1;
                            break;
                        case MoveDirection.Down:
                            current.Y += 1;
                            break;
                        case MoveDirection.Left:
                            current.X -= 1;
                            break;
                        case MoveDirection.Right:
                            current.X += 1;
                            break;
                    }

                    current.Direction = Direction;
                }
                else // Update body
                {
                    current.X = previous.X;
                    current.Y = previous.Y;
                    current.Direction = previous.Direction;
                }
            }
        }

        public void Draw(IRenderer renderer)
        {
            const string Wall = "█";
            const string Food = "⸰";

            const string SnakeHeadUp = "^";
            const string SnakeHeadDown = "v";
            const string SnakeHeadRight = ">";
            const string SnakeHeadLeft = "<";

            const string SnakeBodyHorizontal = "═";
            const string SnakeBodyVertical = "║";
            const string SnakeBodyDownRight = "╔";
            const string SnakeBodyDownLeft = "╗";
            const string SnakeBodyUpRight = "╚";
            const string SnakeBodyUpLeft = "╝";

            for (var i = 0; i < _snake.Count; i++)
            {
                (var previous, var current, var next) = GetSnakeBits(i, _snake);
                var bodyCharacter = "";

                // Draw head
                if (previous == null)
                {
                    switch (Direction)
                    {
                        case MoveDirection.Down:
                            bodyCharacter = SnakeHeadDown;
                            break;
                        case MoveDirection.Left:
                            bodyCharacter = SnakeHeadLeft;
                            break;
                        case MoveDirection.Right:
                            bodyCharacter = SnakeHeadRight;
                            break;
                        case MoveDirection.Up:
                            bodyCharacter = SnakeHeadUp;
                            break;
                    }
                }
                else // Draw body
                {
                    switch (current.Direction)
                    {
                        case MoveDirection.Down:
                            bodyCharacter = SnakeHeadDown;
                            break;
                        case MoveDirection.Left:
                            bodyCharacter = SnakeHeadLeft;
                            break;
                        case MoveDirection.Right:
                            bodyCharacter = SnakeHeadRight;
                            break;
                        case MoveDirection.Up:
                            bodyCharacter = SnakeHeadUp;
                            break;
                    }
                }

                renderer.DrawText(bodyCharacter, current.X, current.Y);
            }
        }

        private IList<SnakeBit> InitSnake(int lengthOfSnake)
        {
            return Enumerable.Range(0, lengthOfSnake)
                .Reverse()
                .Select(index => new SnakeBit
                {
                    X = index,
                    Y = 0,
                    IsHead = index == 0,
                    Direction = MoveDirection.Right
                })
                .ToList();
        }

        private (SnakeBit previous, SnakeBit current, SnakeBit next) GetSnakeBits(int index, IList<SnakeBit> snake)
        {
            return (previous: index == 0 ? null : snake[index - 1],
                current: snake[index],
                next: index == snake.Count - 1 ? null : snake[index + 1]);
        }
    }
}
