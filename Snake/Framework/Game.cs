﻿using System;

namespace SnakeNet.Framework
{
    public abstract class Game
    {
        protected readonly IRenderer _renderer;

        private TimeSpan _targetFrameTime;
        private bool _wasExitRequested;

        public Game(IRenderer renderer)
        {
            _renderer = renderer;
            SetTargetFramesPerSecond(60);
        }

        public virtual void HandleInput(TimeSpan elapsed) { }
        public virtual void Update(TimeSpan elapsed) { }
        public virtual void Draw(TimeSpan elapsed)
        {
            _renderer.Clear();
        }

        public void SetTargetFramesPerSecond(int fps)
            => _targetFrameTime = TimeSpan.FromSeconds(1d / fps);

        public void Run()
        {
            var lastTime = DateTime.UtcNow;

            while (true)
            {
                var currentTime = DateTime.UtcNow;
                var elapsedTime = currentTime - lastTime;

                HandleInput(elapsedTime);

                if (elapsedTime < _targetFrameTime)
                    continue;

                Update(elapsedTime);
                Draw(elapsedTime);

                lastTime = currentTime;
            }

            //var lag = TimeSpan.FromSeconds(0);

            //while (true)
            //{
            //    var currentTime = DateTime.UtcNow;
            //    var elapsedTime = currentTime - lastTime;
            //    lag += elapsedTime;

            //    HandleInput(elapsedTime);

            //    while (lag >= _targetFrameTime)
            //    {
            //        Update(elapsedTime);
            //        lag -= _targetFrameTime;
            //    }

            //    Draw(elapsedTime);

            //    if (_wasExitRequested)
            //        break;

            //    lastTime = currentTime;
            //}
        }

        public void Exit()
        {
            _wasExitRequested = true;
        }
    }
}