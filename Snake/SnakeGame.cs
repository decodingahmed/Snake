using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Framework;
using SnakeNet.Framework.Renderer;
using SnakeNet.GameObjects;

namespace SnakeNet
{
    public class SnakeGame : Game
    {
        private readonly Snake _snake;
        
        public SnakeGame()
            : base(new ConsoleRenderer(60, 30))
        {
            _snake = new Snake(5);

            SetTargetFramesPerSecond(2); // Important for the game to work
        }

        public override void HandleInput(TimeSpan elapsed)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                    _snake.Direction = MoveDirection.Up;
                else if (key == ConsoleKey.DownArrow)
                    _snake.Direction = MoveDirection.Down;
                else if (key == ConsoleKey.LeftArrow)
                    _snake.Direction = MoveDirection.Left;
                else if (key == ConsoleKey.RightArrow)
                    _snake.Direction = MoveDirection.Right;
            }
        }

        public override void Update(TimeSpan elapsed)
        {
            base.Update(elapsed);

            _snake.Update(elapsed);
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);

            _snake.Draw(GameRenderer);
        }
    }
}
