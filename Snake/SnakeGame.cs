using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Components;
using Gamework;
using Gamework.Input;
using Gamework.Rendering;
using Gamework.Screens;
using SnakeNet.GameObjects;
using SnakeNet.Screens;

namespace SnakeNet
{
    public class SnakeGame : CmdGame
    {
        private const int GenerateFoodCount = 3;
        private readonly IScreenManager _screenManager;
        
        public SnakeGame()
            : base(new ConsoleRenderer(60, 30), new CmdInputManager())
        {
            _screenManager = new ScreenManager(InputManager);

            var screen = new GameScreen(_screenManager, GameRenderer.Width, GameRenderer.Height);
            _screenManager.AddScreen(screen);

            screen.Show();

            DrawableComponents.Add(new FpsCounter());
        }

        public override void Update(TimeSpan elapsed)
        {
            base.Update(elapsed);

            _screenManager.Update(elapsed);
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);

            _screenManager.Draw(GameRenderer);
        }
    }
}
