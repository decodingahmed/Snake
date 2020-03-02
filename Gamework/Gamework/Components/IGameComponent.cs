using System;
using System.Collections.Generic;
using System.Text;

namespace Gamework.Components
{
    public interface IGameComponent
    {
        void Update(TimeSpan elapsedTime);
    }
}
