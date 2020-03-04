using System;
using Gamecmder.Input;
using Gamecmder.Rendering;
using Gamecmder.Screens;

namespace SnakeNet.Screens
{
    public class GameOverScreen : ScreenBase
    {
        private const string GameOverText = "G A M E   O V E R";
        private const string GameOverResetText = "Press ENTER to restart";

        private readonly IScreenManager _screenManager;

        // Score related variables
        private readonly int _score = 0;
        private readonly int _scoreX = 0;
        private readonly int _scoreY = 0;
        private readonly string _scoreText = string.Empty;

        // Game over variables
        private readonly int _gameOverTextX = 0;
        private readonly int _gameOverTextY = 0;
        private readonly int _gameOverResetTextX = 0;
        private readonly int _gameOverResetTextY = 0;

        private readonly int _rendererWidth;
        private readonly int _rendererHeight;


        public GameOverScreen(IScreenManager screenManager, int rendererWidth, int rendererHeight, int score)
            : base(ScreenType.Screen)
        {
            _screenManager = screenManager;

            var halfWidth = rendererWidth / 2;
            var halfHeight = rendererHeight / 2;

            _gameOverTextX = halfWidth - (GameOverText.Length / 2);
            _gameOverTextY = halfHeight - 1;

            _score = score;
            _scoreX = halfWidth - (_scoreText.Length / 2);
            _scoreY = _gameOverTextY + 2;

            _gameOverResetTextX = halfWidth - (GameOverResetText.Length / 2);
            _gameOverResetTextY = _scoreY + 4;

            _rendererWidth = rendererWidth;
            _rendererHeight = rendererHeight;
        }

        public override void Update(TimeSpan elapsed)
        {
            if (_screenManager.InputManager.State.KeyPressed == Key.Enter)
            {
                var screen = new GameScreen(_screenManager, _rendererWidth, _rendererHeight);
                _screenManager.AddScreen(screen);
                _screenManager.RemoveScreen(this);

                screen.Show();
            }
        }

        public override void Draw(IRenderer renderer)
        {
            renderer.DrawText(GameOverText, _gameOverTextX, _gameOverTextY);
            renderer.DrawText(GameOverResetText, _gameOverResetTextX, _gameOverResetTextY);
        }
    }
}
