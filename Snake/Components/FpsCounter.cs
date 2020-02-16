using System;
using Gamework;
using Gamework.Rendering;

namespace SnakeNet.Components
{
    public class FpsCounter
    {
        private static readonly TimeSpan OneSecond = TimeSpan.FromSeconds(1);

        private TimeSpan _currentElapsed;
        private int _framesPerSecond;
        private int _frameCounter;

        public FpsCounter()
        {
            _frameCounter = 0;
        }

        public void Update(TimeSpan elapsed)
        {
            _currentElapsed += elapsed;
            _frameCounter++;
            if (_currentElapsed >= OneSecond)
            {
                _framesPerSecond = _frameCounter;

                _currentElapsed = TimeSpan.Zero;
                _frameCounter = 0;
            }
        }

        public void Draw(IRenderer renderer)
        {
            renderer.DrawText($"FPS: {_framesPerSecond}", 0, 0);
        }
    }
}
