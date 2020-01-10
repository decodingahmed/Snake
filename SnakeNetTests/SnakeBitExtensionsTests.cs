using System;
using FluentAssertions;
using SnakeNet;
using SnakeNet.Extensions;
using SnakeNet.GameObjects;
using Xunit;

namespace SnakeNetTests
{
    [Trait("UnitTest", nameof(SnakeBitExtensions))]
    public class SnakeBitExtensionsTests
    {
        [Fact]
        public void Throw_ArgumentException_WhenNextPositionIsSameAsCurrent()
        {
            Action action = () =>
            {
                var current = new SnakeBit { X = 7, Y = 10 };
                var next = new SnakeBit { X = 7, Y = 10 };

                current.GetRelativeDirection(next);
            };

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Throw_NotSupportedException_WhenNextIsDiagonallyPositioned()
        {
            Action action = () =>
            {
                var current = new SnakeBit { X = 7, Y = 10 };
                var next = new SnakeBit { X = 8, Y = 11 };

                current.GetRelativeDirection(next);
            };

            action.Should().Throw<NotSupportedException>();
        }
        
        [Theory]
        [InlineData(4, 2, 4, 1, MoveDirection.Down)]
        [InlineData(6, 5, 6, 6, MoveDirection.Up)]
        [InlineData(7, 0, 6, 0, MoveDirection.Right)]
        [InlineData(8, 3, 9, 3, MoveDirection.Left)]
        public void Test1(int firstX, int firstY, int secondX, int secondY, MoveDirection expectedDirection)
        {
            var currentBit = new SnakeBit { X = firstX, Y = firstY };
            var nextBit = new SnakeBit { X = secondX, Y = secondY };

            var direction = currentBit.GetRelativeDirection(nextBit);

            direction.Should().Be(expectedDirection);
        }
    }
}
