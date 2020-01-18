using SnakeNet.GameObjects;

namespace SnakeNet.Components
{
    public delegate void CollisionEventHandler(
        CollisionSystem system,
        ICollidable first,
        ICollidable second);
}
