using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Framework.Rendering;

namespace SnakeNet.Framework.Screens
{
    public interface IScreenManager
    {
        void Update(TimeSpan elapsed);
        void Draw(IRenderer renderer);
        void Push(IScreen screen);
        IScreen Pop();
    }


    public class ScreenManager : IScreenManager
    {
        private readonly Stack<IScreen> _screens = null;


        public ScreenManager()
        {
            _screens = new Stack<IScreen>();
        }

        public void Update(TimeSpan elapsed)
        {
            // Only update top screen in the stack
            _screens.Peek().Update(elapsed);
        }

        public void Draw(IRenderer renderer)
        {
            foreach (var screen in _screens.Reverse())
            {
                if (screen.IsVisible)
                    screen.Draw(renderer);
            }
        }


        public void Push(IScreen screen)
        {
            _screens.Push(screen);
            screen.Show();
        }

        public IScreen Pop()
        {
            if (_screens.TryPop(out var screen))
                return screen;

            return null;
        }
    }
}
