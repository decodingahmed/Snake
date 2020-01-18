using System;
using System.Collections.Generic;
using System.Text;
using SnakeNet.Components;
using Xunit;

namespace SnakeNetTests.Components
{
    internal class Collidable : ICollidable
    {
        public int X { get; }

        public int Y { get; }
    }


    [Trait("UnitTests", nameof(CollisionSystem))]
    public class CollisionSystemTests
    {
        private readonly CollisionSystem _collisionSystem;

        public CollisionSystemTests()
        {
            _collisionSystem.OnCollisionDetected += CollisionSystem_OnCollisionDetected;
        }

        ~CollisionSystemTests()
        {
            _collisionSystem.OnCollisionDetected -= CollisionSystem_OnCollisionDetected;
        }

        private void CollisionSystem_OnCollisionDetected(CollisionSystem system, ICollidable first, ICollidable second)
        {
            throw new NotImplementedException();
        }

    }
}
