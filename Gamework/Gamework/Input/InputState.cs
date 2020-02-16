﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gamework.Input
{
    public class InputState
    {
        public Key KeyPressed { get; internal set; }
        public ModifierKey ModifierPressed { get; internal set; }
    }
}
