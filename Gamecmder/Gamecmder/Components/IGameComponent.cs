using System;
using System.Collections.Generic;
using System.Text;

namespace Gamecmder.Components
{
    public interface IGameComponent
    {
        void Update(TimeSpan elapsedTime);
    }
}
