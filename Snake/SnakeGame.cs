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
        public SnakeGame()
            : base(new ConsoleRenderer(60, 30), new CmdInputManager())
        {
            var screenManager = new ScreenManager(InputManager);

            var screen = new GameScreen(screenManager, GameRenderer.Width, GameRenderer.Height);
            screenManager.AddScreen(screen);

            screen.Show();

            DrawableComponents.Add(new FpsCounter());
            DrawableComponents.Add(screenManager);
        }

        public override void Update(TimeSpan elapsed)
        {
            base.Update(elapsed);
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);
        }
    }
}
