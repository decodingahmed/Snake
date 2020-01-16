using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeNet.GameObjects
{
    public class SnakeBit
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public bool IsHead { get; set; } = false;
        public MoveDirection Direction { get; set; } = MoveDirection.None;
    }
}
