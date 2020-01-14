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
        [InlineData(MoveDirection.Left, MoveDirection.Up, Images.SnakeBodyUpRight)]
        [InlineData(MoveDirection.Left, MoveDirection.Down, Images.SnakeBodyDownRight)]
        [InlineData(MoveDirection.Right, MoveDirection.Up, Images.SnakeBodyUpLeft)]
        [InlineData(MoveDirection.Right, MoveDirection.Down, Images.SnakeBodyDownLeft)]
        [InlineData(MoveDirection.Up, MoveDirection.Left, Images.SnakeBodyDownLeft)]
        [InlineData(MoveDirection.Up, MoveDirection.Right, Images.SnakeBodyDownRight)]
        [InlineData(MoveDirection.Down, MoveDirection.Left, Images.SnakeBodyUpLeft)]
        [InlineData(MoveDirection.Down, MoveDirection.Right, Images.SnakeBodyUpRight)]
        [InlineData(MoveDirection.Up, MoveDirection.None, Images.SnakeBodyUp)]
        [InlineData(MoveDirection.Down, MoveDirection.None, Images.SnakeBodyDown)]
        [InlineData(MoveDirection.Left, MoveDirection.None, Images.SnakeBodyLeft)]
        [InlineData(MoveDirection.Right, MoveDirection.None, Images.SnakeBodyRight)]
        public void CalculatesImageCorrectly(MoveDirection previous, MoveDirection next, string expectedImage)
        {
            var image = ImageHelper.GetImage(previous, next);

            image.Should().Be(expectedImage);
        }
    }
}
