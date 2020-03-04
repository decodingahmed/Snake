using System;
using System.Collections.Generic;
using System.Text;
using Gamecmder.Components;
using Gamecmder.Rendering;

namespace Gamecmder.Tests
{
    class TestDrawableComponent : IDrawableComponent
    {
        public void Draw(IRenderer renderer, TimeSpan elapsedTime)
        {
        }

        public void Update(TimeSpan elapsedTime)
        {
        }
    }
}
