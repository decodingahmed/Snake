using System;
using System.Collections.Generic;
using System.Text;
using SnakeNet.Framework;

namespace SnakeNet.Components
{
    public class FpsCounter
    {
        private readonly TimeSpan _resetDuration;
        private TimeSpan _currentElapsed;
        private int _counter;

        public FpsCounter()
        {
            _resetDuration = TimeSpan.FromSeconds(1);
            _counter = 0;
        }

        public void Update(TimeSpan elapsed)
        {
            //_currentElapsed += elapsed;
            _counter++;
        }

        public void Draw(IRenderer renderer)
        {
            renderer.DrawText($"FPS: {_counter}", 0, 0);
        }
    }
}
