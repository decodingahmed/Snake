using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Components;
using SnakeNet.Framework;
using SnakeNet.Framework.Rendering;
using SnakeNet.Framework.Screens;
using SnakeNet.GameObjects;
using SnakeNet.Screens;

namespace SnakeNet
{
    public class SnakeGame : Game
    {
        private const int GenerateFoodCount = 3;
        private readonly FpsCounter _fpsCounter;
        private readonly IScreenManager _screenManager;
        
        public SnakeGame()
            : base(new ConsoleRenderer(60, 30))
        {
            _fpsCounter = new FpsCounter();
            _screenManager = new ScreenManager();

            SetTargetFramesPerSecond(5); // Important for the game to work

            _screenManager.Push(new GameScreen(_screenManager, GameRenderer.Width, GameRenderer.Height));
        }

        public override void HandleInput(TimeSpan elapsed)
        {
            //if (Console.KeyAvailable)
            //{
            //    var key = Console.ReadKey().Key;

            //    if (_isGameOver)
            //    {
            //        if (key == ConsoleKey.Enter)
            //        {
            //            _isGameOver = false;

            //            Reset();
            //        }
            //    }
            //    else
            //    {
            //        if (key == ConsoleKey.UpArrow)
            //            _snake.Direction = MoveDirection.Up;
            //        else if (key == ConsoleKey.DownArrow)
            //            _snake.Direction = MoveDirection.Down;
            //        else if (key == ConsoleKey.LeftArrow)
            //            _snake.Direction = MoveDirection.Left;
            //        else if (key == ConsoleKey.RightArrow)
            //            _snake.Direction = MoveDirection.Right;
            //    }
            //}
        }

        public override void Update(TimeSpan elapsed)
        {
            base.Update(elapsed);

            _fpsCounter.Update(elapsed);

            _screenManager.Update(elapsed);

            //if (!_isGameOver)
            //{
            //    // Create new food on demand
            //    if (_foods.Count == 0)
            //    {
            //        foreach (var _ in Enumerable.Range(0, GenerateFoodCount))
            //        {
            //            var randomX = _foodRandomiser.Next(GameRenderer.Width);
            //            var randomY = _foodRandomiser.Next(GameRenderer.Height);

            //            var food = new Food(randomX, randomY);
            //            _foods.Add(food);

            //            _collisionSystem.Add(food);
            //        }
            //    }

            //    _snake.Update(elapsed);
            //    _collisionSystem.Update(elapsed);
            //}
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);

            _fpsCounter.Draw(GameRenderer);
            _screenManager.Draw(GameRenderer);

            //if (_isGameOver)
            //{
            //    GameRenderer.DrawText(GameOverText, _gameOverTextX, _gameOverTextY);
            //    GameRenderer.DrawText(GameOverResetText, _gameOverResetTextX, _gameOverResetTextY);
            //}
            //else
            //{
            //    _fpsCounter.Draw(GameRenderer);
            //    _snake.Draw(GameRenderer);

            //    // Draw food
            //    foreach (var food in _foods)
            //        food.Draw(GameRenderer);
            //}

            //GameRenderer.DrawText(_scoreText, _scoreX, _scoreY);

            //GameRenderer.DrawText($"isGameOver: {_isGameOver}", 0, GameRenderer.Height - 1);
        }
    }
}
