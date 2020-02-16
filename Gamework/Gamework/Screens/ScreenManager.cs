using System;
using System.Collections.Generic;
using System.Linq;
using Gamework.Input;
using Gamework.Rendering;

namespace Gamework.Screens
{
    public interface IScreenManager
    {
        IInputManager InputManager { get; }

        void AddScreen(IScreen screen);
        void RemoveScreen(IScreen screen);
        void Update(TimeSpan elapsed);
        void Draw(IRenderer renderer);
    }


    public class ScreenManager : IScreenManager
    {
        private readonly IList<IScreen> _screens = new List<IScreen>();

        public IInputManager InputManager { get; }


        public ScreenManager(IInputManager inputManager)
        {
            InputManager = inputManager;
        }

        
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
