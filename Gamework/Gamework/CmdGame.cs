﻿using System;
using System.Collections.Generic;
using Gamework.Components;
using Gamework.Input;
using Gamework.Rendering;

namespace Gamework
{
    public interface IGame
    {
        IRenderer GameRenderer { get; }
        IInputManager InputManager { get; }
        void Update(TimeSpan elapsed);
        void Draw(TimeSpan elapsed);
        void Exit();
    }

    public abstract class CmdGame : IGame
    {
        private readonly TimeSpan _targetFrameTime;
        private bool _wasExitRequested;

        public IRenderer GameRenderer { get; }

        public IInputManager InputManager { get; }

        public IList<IDrawableComponent> DrawableComponents { get; }

        public CmdGame(IRenderer renderer, IInputManager inputManager)
        {
            GameRenderer = renderer;
            InputManager = inputManager;
            DrawableComponents = new List<IDrawableComponent>();

            // Comfortable fps without hazy rendering
            _targetFrameTime = TimeSpan.FromSeconds(1d / 20);
        }
        
        public virtual void Update(TimeSpan elapsed)
        {
            foreach (var component in DrawableComponents)
                component.Update(elapsed);
        }

        public virtual void Draw(TimeSpan elapsed)
        {
            GameRenderer.Clear();

            foreach (var component in DrawableComponents)
                component.Draw(GameRenderer, elapsed);
        }
        

        public void Run()
        {
            var lastTime = DateTime.UtcNow;

            while (true)
            {
                var currentTime = DateTime.UtcNow;
                var elapsedTime = currentTime - lastTime;

                if (elapsedTime < _targetFrameTime)
                    continue;

                InputManager.Update(elapsedTime);

                Update(elapsedTime);
                Draw(elapsedTime);

                lastTime = currentTime;
            }
        }

        public void Exit()
        {
            _wasExitRequested = true;
        }
    }
}