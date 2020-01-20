using System;
using System.Collections.Generic;

namespace SnakeNet.Components
{
    public interface ICollisionSystem
    {
        event CollisionEventHandler OnCollisionDetected;

        void Add(ICollidable gameObject);
        void Remove(ICollidable gameObject);
        void Update(TimeSpan elapsed);
        void Clear();
    }
    
    public class CollisionSystem : ICollisionSystem
    {
        private readonly IList<ICollidable> _collidables = new List<ICollidable>();

        public event CollisionEventHandler OnCollisionDetected;
        
        public void Add(ICollidable gameObject) => _collidables.Add(gameObject);

        public void Remove(ICollidable gameObject) => _collidables.Remove(gameObject);

        public void Update(TimeSpan elapsed)
        {
            for (var i = 0; i < _collidables.Count; i++)
            {
                var collidable = _collidables[i];
                for (var j = 0; j < _collidables.Count; j++)
                {
                    var otherCollidable = _collidables[j];

                    if (IsCollisionDetected(collidable, otherCollidable))
                        OnCollisionDetected?.Invoke(this, collidable, otherCollidable);
                }
            }
        }

        public void Clear()
        {
            _collidables.Clear();
        }

        private bool IsCollisionDetected(ICollidable first, ICollidable second)
        {
            if (first == second)
                return false;

            return first.X == second.X && first.Y == second.Y;
        }
    }
}
