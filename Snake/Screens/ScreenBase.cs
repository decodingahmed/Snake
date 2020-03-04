using System;
using Gamecmder.Rendering;
using Gamecmder.Screens;

namespace SnakeNet.Screens
{
    public abstract class ScreenBase : IScreen
    {
        public ScreenType Type { get; }

        public bool IsVisible { get; private set; } = false;

        public bool IsInitialised { get; private set; } = false;
        

        public ScreenBase(ScreenType type)
        {
            Type = type;
        }

        public virtual void Initialise()
        {
            IsInitialised = true;
        }

        public abstract void Update(TimeSpan elapsed);

        public abstract void Draw(IRenderer renderer);

        public void Hide()
        {
            IsVisible = false;
        }

        public void Show()
        {
            if (!IsInitialised)
                Initialise();

            IsVisible = true;
        }
    }
}
