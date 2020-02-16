using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Components;
using SnakeNet.Framework;
using SnakeNet.Framework.Input;
using SnakeNet.Framework.Rendering;
using SnakeNet.Framework.Screens;
using SnakeNet.GameObjects;
using SnakeNet.Screens;

namespace SnakeNet
{
    public class SnakeGame : CmdGame
    {
        private const int GenerateFoodCount = 3;
        private readonly FpsCounter _fpsCounter;
        private readonly IScreenManager _screenManager;
        
        public SnakeGame()
            : base(new ConsoleRenderer(60, 30), new CmdInputManager())
        {
            _fpsCounter = new FpsCounter();
            _screenManager = new ScreenManager(InputManager);

            SetTargetFramesPerSecond(5); // Important for the game to work

            var screen = new GameScreen(_screenManager, GameRenderer.Width, GameRenderer.Height);
            _screenManager.AddScreen(screen);

            screen.Show();
        }

        public override void Update(TimeSpan elapsed)
        {
            base.Update(elapsed);

            _fpsCounter.Update(elapsed);
            _screenManager.Update(elapsed);
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);

            _fpsCounter.Draw(GameRenderer);
            _screenManager.Draw(GameRenderer);
        }
    }
}
