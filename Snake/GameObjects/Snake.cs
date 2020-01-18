using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Framework;

namespace SnakeNet.GameObjects
{
    /// <summary>
    /// Our famous hungry reptile
    /// </summary>
    public class Snake
    {
        /// <summary>
        /// All the bits of the snake
        /// </summary>
        private readonly IList<SnakeBit> _bits;
        private readonly int _gameAreaWidth;
        private readonly int _gameAreaHeight;


        /// <summary>
        /// The head of the snake
        /// </summary>
        public SnakeBit Head => _bits[0];


        /// <summary>
        /// The direction the head of the snake is moving in
        /// </summary>
        public MoveDirection Direction { get; set; } = MoveDirection.Right;


        /// <summary>
        /// Constructor for our reptile
        /// </summary>
        /// <param name="lengthOfSnake">The starting length of our reptile</param>
        public Snake(int lengthOfSnake, int gameAreaWidth, int gameAreaHeight)
        {
            _bits = InitSnake(lengthOfSnake);

            _gameAreaWidth = gameAreaWidth;
            _gameAreaHeight = gameAreaHeight;
        }


        /// <summary>
        /// All the bits of the snake
        /// </summary>
        public IList<SnakeBit> GetBits() => _bits;


        /// <summary>
        /// Update loop
        /// </summary>
        /// <param name="elapsed">Amount of time that has elapsed since the last update</param>
        public void Update(TimeSpan elapsed)
        {
            for (var i = _bits.Count - 1; i >= 0; i--)
            {
                (var previous, var current, var next) = GetSnakeBits(i, _bits);

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

                    // TODO: Handle this through collision system
                    if (current.X == -1)
                        current.X = _gameAreaWidth - 1;
                    else if (current.X == _gameAreaWidth)
                        current.X = 0;

                    if (current.Y == -1)
                        current.Y = _gameAreaHeight - 1;
                    else if (current.Y == _gameAreaHeight)
                        current.Y = 0;
                }
                else // Update body
                {
                    current.X = previous.X;
                    current.Y = previous.Y;
                    current.Direction = previous.Direction;
                }
            }
        }


        /// <summary>
        /// Rendering loop
        /// </summary>
        public void Draw(IRenderer renderer)
        {
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

            for (var i = 0; i < _bits.Count; i++)
            {
                (var previous, var current, var next) = GetSnakeBits(i, _bits);
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
        

        /// <summary>
        /// Increase our reptile's size
        /// </summary>
        public void GrowSnake()
        {
            var lastBit = _bits.Last();
            var x = 0;
            var y = 0;

            switch (lastBit.Direction)
            {
                case MoveDirection.Up:
                    x = lastBit.X;
                    y = lastBit.Y + 1;
                    break;
                case MoveDirection.Down:
                    x = lastBit.X;
                    y = lastBit.Y - 1;
                    break;
                case MoveDirection.Left:
                    x = lastBit.X + 1;
                    y = lastBit.Y;
                    break;
                case MoveDirection.Right:
                    x = lastBit.X - 1;
                    y = lastBit.Y;
                    break;
            }

            _bits.Add(new SnakeBit
            {
                Direction = lastBit.Direction,
                X = x,
                Y = y
            });
        }

        private IList<SnakeBit> InitSnake(int lengthOfSnake)
        {
            return Enumerable.Range(0, lengthOfSnake)
                .Reverse()
                .Select(index => new SnakeBit
                {
                    X = index,
                    Y = 3,
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
