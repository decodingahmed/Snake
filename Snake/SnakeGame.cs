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
        private const string GameOverText = "G A M E   O V E R";

        private readonly Random _foodRandomiser = new Random();
        private readonly IList<Food> _foods;

        private readonly Snake _snake;
        private readonly FpsCounter _fpsCounter;
        private readonly ICollisionSystem _collisionSystem;

        // Score related variables
        private int _score = 0;
        private int _scoreX = 0;
        private int _scoreY = 0;
        private string _scoreText = string.Empty;

        // Game over variables
        private int _gameOverTextX = 0;// (GameRenderer.Width / 2) - (gameOverText.Length / 2);
        private int _gameOverTextY = 0;// (GameRenderer.Height / 2) - 1;

        // Game state
        private bool _isGameOver;

        public SnakeGame()
            : base(new ConsoleRenderer(60, 30))
        {
            _snake = new Snake(5, 60, 30);
            _foods = new List<Food>();

            _fpsCounter = new FpsCounter();
            _collisionSystem = new CollisionSystem();
            _collisionSystem.OnCollisionDetected += CollisionSystem_OnCollisionDetected;

            SetTargetFramesPerSecond(5); // Important for the game to work

            foreach (var bit in _snake.GetBits())
                _collisionSystem.Add(bit);

            _scoreText = $"Score: 000";
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

            _fpsCounter.Update(elapsed);

            if (!_isGameOver)
            {
                // Create new food on demand
                if (_foods.Count == 0)
                {
                    foreach (var _ in Enumerable.Range(0, GenerateFoodCount))
                    {
                        var randomX = _foodRandomiser.Next(GameRenderer.Width);
                        var randomY = _foodRandomiser.Next(GameRenderer.Height);

                        var food = new Food(randomX, randomY);
                        _foods.Add(food);

                        _collisionSystem.Add(food);
                    }
                }

                _snake.Update(elapsed);
                _collisionSystem.Update(elapsed);
            }
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);

            if (_isGameOver)
            {
                GameRenderer.DrawText(GameOverText, _gameOverTextX, _gameOverTextY);
            }
            else
            {
                _fpsCounter.Draw(GameRenderer);
                _snake.Draw(GameRenderer);

                // Draw food
                foreach (var food in _foods)
                    food.Draw(GameRenderer);
            }

            GameRenderer.DrawText(_scoreText, _scoreX, _scoreY);
        }


        private void IncrementScore()
        {
            _score++;

            _scoreText = $"Score: {_score:000}";
            _scoreX = GameRenderer.Width - _scoreText.Length;
        }


        private void CollisionSystem_OnCollisionDetected(CollisionSystem system, ICollidable first, ICollidable second)
        {
            if (first is SnakeBit && second is Food food)
            {
                IncrementScore();

                _foods.Remove(food);
                _snake.GrowSnake();
                _collisionSystem.Remove(food);
            }
            else if (first is SnakeBit bit1 && second is SnakeBit bit2)
            {
                _isGameOver = true;

                var halfWidth = GameRenderer.Width / 2;
                var halfHeight = GameRenderer.Height / 2;
                
                _gameOverTextX = halfWidth - (GameOverText.Length / 2);
                _gameOverTextY = halfHeight - 1;

                _scoreX = halfWidth - (_scoreText.Length / 2);
                _scoreY = halfHeight;
            }
        }
    }
}
