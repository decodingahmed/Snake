using System;
using System.Collections.Generic;
using System.Text;
using SnakeNet.Framework.Rendering;
using SnakeNet.Framework.Screens;

namespace SnakeNet.Screens
{
    public abstract class ScreenBase : IScreen
    {
        public bool IsVisible { get; private set; }

        public ScreenType ScreenType { get; }

        public ScreenBase(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        public abstract void Update(TimeSpan elapsed);

        public abstract void Draw(IRenderer renderer);

        public void Hide()
        {
            IsVisible = false;
        }

        public void Show()
        {
            IsVisible = true;
        }
    }
}
