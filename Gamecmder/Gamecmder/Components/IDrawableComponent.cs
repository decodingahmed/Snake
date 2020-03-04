using System;
using System.Collections.Generic;
using System.Text;
using Gamecmder.Rendering;

namespace Gamecmder.Components
{
    public interface IDrawableComponent : IGameComponent
    {
        void Draw(IRenderer renderer, TimeSpan elapsedTime);
    }
}
