using System;
using System.Collections.Generic;
using System.Linq;
using SnakeNet.Framework.Rendering;

namespace SnakeNet.Framework.Screens
{
    public interface IScreenManager
    {
        void AddScreen(IScreen screen);
        void RemoveScreen(IScreen screen);
        void Update(TimeSpan elapsed);
        void Draw(IRenderer renderer);
    }


    public class ScreenManager : IScreenManager
    {
        private readonly IList<IScreen> _screens = new List<IScreen>();
        
        public void Update(TimeSpan elapsed)
        {
            // Creating a separate list because other screens might change
            // the main screens list within the Update calls below
            var screens = _screens.ToList();

            foreach (var screen in screens)
                screen.Update(elapsed);
        }

        public void Draw(IRenderer renderer)
        {
            var screens = _screens
                .Reverse()
                .Where(s => s.IsVisible);

            foreach (var screen in screens)
                screen.Draw(renderer);
        }


        public void AddScreen(IScreen screen)
        {
            _screens.Add(screen);

            screen.Initialise();
        }

        public void RemoveScreen(IScreen screen)
        {
            _screens.Remove(screen);
        }
    }
}
