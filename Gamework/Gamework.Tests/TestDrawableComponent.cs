using System;
using System.Collections.Generic;
using System.Text;
using Gamework.Components;
using Gamework.Rendering;

namespace Gamework.Tests
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
