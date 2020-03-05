using System;
using System.Collections.Generic;
using Gamecmder.Components;
using Gamecmder.Input;
using Gamecmder.Rendering;

namespace Gamecmder
{
    /// <summary>
    /// Provides an interface for a game
    /// </summary>
    public interface IGame
    {
        bool IsExiting { get; }
        IRenderer GameRenderer { get; }
        IInputManager InputManager { get; }
        void Update(TimeSpan elapsed);
        void Draw(TimeSpan elapsed);
        void Exit();
    }

    public abstract class CmdGame : IGame
    {
        private readonly TimeSpan _targetFrameTime;

        public bool IsExiting { get; private set; }

        public IRenderer GameRenderer { get; }

        public IInputManager InputManager { get; }

        // TODO: List of game components

        public IList<IDrawableComponent> DrawableComponents { get; }

        public CmdGame(IRenderer renderer, IInputManager inputManager)
        {
            GameRenderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
            InputManager = inputManager ?? throw new ArgumentNullException(nameof(inputManager));

            DrawableComponents = new List<IDrawableComponent>();
        }
        
        public virtual void Update(TimeSpan elapsed)
        {
            InputManager.Update(elapsed);

            foreach (var component in DrawableComponents)
                component.Update(elapsed);
        }

        public virtual void Draw(TimeSpan elapsed)
        {
            GameRenderer.Clear();

            foreach (var component in DrawableComponents)
                component.Draw(GameRenderer, elapsed);
        }

        public void Exit()
        {
            IsExiting = true;
        }
    }
}
