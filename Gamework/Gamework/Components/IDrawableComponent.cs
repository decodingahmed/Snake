using System;
using System.Collections.Generic;
using System.Text;
using Gamework.Rendering;

namespace Gamework.Components
{
    public interface IDrawableComponent : IGameComponent
    {
        void Draw(IRenderer renderer, TimeSpan elapsedTime);
    }
}
