using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Components;
using SnakeNet.Framework;
using SnakeNet.Framework.Renderer;
using SnakeNet.GameObjects;

namespace SnakeNet
{
    public class SnakeGame : Game
    {
        private const int GenerateFoodCount = 3;
        
        private readonly Random _foodRandomiser = new Random();
        private readonly IList<Food> _foods;
        
        private readonly Snake _snake;
        private readonly FpsCounter _fpsCounter;

        private int _score = 0;
        
        public SnakeGame()
            : base(new ConsoleRenderer(60, 30))
        {
            _snake = new Snake(5, 60, 30);
            _foods = new List<Food>();

            _fpsCounter = new FpsCounter();

            SetTargetFramesPerSecond(5); // Important for the game to work
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

            // Create new food on demand
            if (_foods.Count == 0)
            {
                foreach (var _ in Enumerable.Range(0, GenerateFoodCount))
                {
                    var randomX = _foodRandomiser.Next(GameRenderer.Width);
                    var randomY = _foodRandomiser.Next(GameRenderer.Height);

                    _foods.Add(new Food(randomX, randomY));
                }
            }

            for (var i = 0; i < _foods.Count; i++)
            {
                var food = _foods[i];
                if (_snake.Head.X == food.X && _snake.Head.Y == food.Y)
                {
                    _score++;
                    _foods.RemoveAt(i);
                    _snake.GrowSnake();
                    
                    i--;
                }
            }

            _fpsCounter.Update(elapsed);
            _snake.Update(elapsed);
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);

            _fpsCounter.Draw(GameRenderer);
            _snake.Draw(GameRenderer);

            // Draw food
            foreach (var food in _foods)
                food.Draw(GameRenderer);

            var scoreText = string.Format("Score: {0:000}", _score);
            var scoreX = GameRenderer.Width - scoreText.Length;
            var scoreY = 0;
            GameRenderer.DrawText(scoreText, scoreX, scoreY);
        }
    }
}
