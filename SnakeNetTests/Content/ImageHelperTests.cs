using FluentAssertions;
using SnakeNet;
using SnakeNet.Content;
using Xunit;

namespace SnakeNetTests.Content
{
    [Trait("UnitTests", nameof(ImageHelper))]
    public class ImageHelperTests
    {
        /* 
         * |╔|═|╗|
         * |║| |║|
         * |╚|═|╝|
         */

        [Theory]
        [InlineData(MoveDirection.Right, MoveDirection.Right, Images.SnakeBodyRight)]
        [InlineData(MoveDirection.Left, MoveDirection.Left, Images.SnakeBodyLeft)]
        [InlineData(MoveDirection.Up, MoveDirection.Up, Images.SnakeBodyUp)]
        [InlineData(MoveDirection.Down, MoveDirection.Down, Images.SnakeBodyDown)]
        [InlineData(MoveDirection.Left, MoveDirection.Up, Images.SnakeBodyDownLeft)]
        [InlineData(MoveDirection.Left, MoveDirection.Down, Images.SnakeBodyUpLeft)]
        [InlineData(MoveDirection.Right, MoveDirection.Up, Images.SnakeBodyDownRight)]
        [InlineData(MoveDirection.Right, MoveDirection.Down, Images.SnakeBodyUpRight)]
        [InlineData(MoveDirection.Up, MoveDirection.Left, Images.SnakeBodyUpRight)]
        [InlineData(MoveDirection.Up, MoveDirection.Right, Images.SnakeBodyUpLeft)]
        [InlineData(MoveDirection.Down, MoveDirection.Left, Images.SnakeBodyDownRight)]
        [InlineData(MoveDirection.Down, MoveDirection.Right, Images.SnakeBodyDownLeft)]
        [InlineData(MoveDirection.Up, MoveDirection.None, "E")]
        [InlineData(MoveDirection.Down, MoveDirection.None, "E")]
        [InlineData(MoveDirection.Left, MoveDirection.None, "E")]
        [InlineData(MoveDirection.Right, MoveDirection.None, "E")]
        public void CalculatesImageCorrectly(MoveDirection previous, MoveDirection current, string expectedImage)
        {
            var image = ImageHelper.GetImage(previous, current);

            image.Should().Be(expectedImage);
        }
    }
}
