namespace SnakeNet.Components
{
    /// <summary>
    /// Represents a physical object that can take part in collision calculations
    /// </summary>
    public interface ICollidable
    {
        int X { get; }
        int Y { get; }
    }
}
