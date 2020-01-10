using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Components;
using SnakeNet.Extensions;
using SnakeNet.Framework;
using SnakeNet.Framework.Renderer;
using SnakeNet.GameObjects;

namespace SnakeNet
{
    public class SnakeGame : Game
    {
        // Time to next move
        private static readonly TimeSpan StepTime = TimeSpan.FromSeconds(1);

        private readonly IList<SnakeBit> _snake;

        private TimeSpan _nextStepTimeUpdate = TimeSpan.FromSeconds(0);
        
        public SnakeGame()
            : base(new ConsoleRenderer())
        {
            _snake = InitSnake(5);

            SetTargetFramesPerSecond(1);
        }

        public override void HandleInput(TimeSpan elapsed)
        {
            base.HandleInput(elapsed);
        }

        public override void Update(TimeSpan elapsed)
        {
            base.Update(elapsed);
            
            UpdateSnake(elapsed);
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);
            
            DrawSnake();
        }

        private IList<SnakeBit> InitSnake(int lengthOfSnake)
        {
            return Enumerable.Range(0, lengthOfSnake)
                .Reverse()
                .Select(index => new SnakeBit { X = index, Y = 0 })
                .ToList();
        }

        private void UpdateSnake(TimeSpan elapsed)
        {
            //if (_nextStepTimeUpdate < elapsed)
            //{
            //    _nextStepTimeUpdate = _nextStepTimeUpdate.Add(elapsed);
            //    return;
            //}

            //_nextStepTimeUpdate = TimeSpan.FromSeconds(0);

            for (var i = 0; i < _snake.Count; i++)
            {
                (var previous, var current, var next) = GetSnakeBits(i, _snake);
                var direction = previous == null ? 
                    current.GetRelativeDirection(next) :
                    previous.GetRelativeDirection(current);
                
                switch (direction)
                {
                    case MoveDirection.Down:
                        current.Y += 1;
                        break;
                    case MoveDirection.Left:
                        current.X -= 1;
                        break;
                    case MoveDirection.Right:
                        current.X += 1;
                        break;
                    case MoveDirection.Up:
                        current.Y -= 1;
                        break;
                }
            }
        }

        private void DrawSnake()
        {
            const string Wall = "█";
            const string Food = "⸰";

            const string SnakeHeadUp = "^";
            const string SnakeHeadDown = "v";
            const string SnakeHeadRight = ">";
            const string SnakeHeadLeft = "<";
                
            const string SnakeBodyHoriz = "═";
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
                    bodyCharacter = SnakeHeadRight;
                }
                else // Draw body
                {
                    bodyCharacter = SnakeBodyHoriz;
                }

                _renderer.DrawText(bodyCharacter, current.X, current.Y);
            }
        }

        private (SnakeBit previous, SnakeBit current, SnakeBit next) GetSnakeBits(int index, IList<SnakeBit> snake)
        {
            return (previous: index == 0 ? null : snake[index - 1],
                current: snake[index],
                next: index == snake.Count - 1 ? null : snake[index + 1]);
        }

        //private MoveOrientation GetOrientation(SnakeBit current, SnakeBit next)
        //{

        //}
    }
}
