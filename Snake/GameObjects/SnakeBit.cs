using SnakeNet.Components;

namespace SnakeNet.GameObjects
{
    public class SnakeBit : ICollidable
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public bool IsHead { get; set; } = false;
        public MoveDirection Direction { get; set; } = MoveDirection.None;
    }
}
