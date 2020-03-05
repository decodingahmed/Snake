using System;
using System.Threading.Tasks;
using FluentAssertions;
using Gamecmder.Input;
using Gamecmder.Rendering;
using Moq;
using Xunit;

namespace Gamecmder.Tests
{
    [Trait("UnitTests", nameof(CmdGame))]
    public class CmdGameTests
    {
        [Fact]
        public void Throws_ArgumentNullException_WhenInitialisedWithNullRenderer()
        {
            Action action = () =>
            {
                // CmdGame being called from constructor of TestGame
                new TestGame(null, null);
            };

            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("renderer");
        }


        [Fact]
        public void Throws_ArgumentNullException_WhenInitialisedWithNullInputManager()
        {
            Action action = () =>
            {
                var mockRenderer = new Mock<IRenderer>();

                // CmdGame being called from constructor of TestGame
                new TestGame(mockRenderer.Object, null);
            };

            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("inputManager");
        }


        [Fact]
        public void InitialisesEmptyDrawableComponents_WhenInitialisedCorrectly()
        {
            var game = GetTestGame();

            game.DrawableComponents.Should().NotBeNull();
            game.DrawableComponents.Should().BeEmpty();
        }


        [Fact]
        public void DoesNotCallUpdateOrDraw_WhenExitIsRequested()
        {
            var game = GetTestGame();

            game.Exit();
            game.Run();

            game.DrawCallCount.Should().Be(0);
            game.UpdateCallCount.Should().Be(0);
        }


        [Fact]
        public async Task CallsUpdateOrDraw_WhenGameIsRun()
        {
            var game = GetTestGame();

            await game.RunThenExit();

            game.DrawCallCount.Should().BeGreaterThan(0);
            game.UpdateCallCount.Should().BeGreaterThan(0);
        }


        [Fact]
        public async Task UpdatesNormalComponents_WhenGameIsRun()
        {
            var inputManagerMock = GetMockInputManager();
            var game = GetTestGame(mockInputManager: inputManagerMock);
            
            await game.RunThenExit();

            inputManagerMock.Verify(
                m => m.Update(It.IsAny<TimeSpan>()),
                Times.AtLeastOnce
            );
        }


        private static Mock<IRenderer> GetMockRenderer()
        {
            return new Mock<IRenderer>();
        }


        private static Mock<IInputManager> GetMockInputManager()
        {
            return new Mock<IInputManager>();
        }


        private static TestGame GetTestGame(
            Mock<IRenderer> mockRenderer = null,
            Mock<IInputManager> mockInputManager = null)
        {
            mockRenderer = mockRenderer ?? GetMockRenderer();
            mockInputManager = mockInputManager ?? GetMockInputManager();

            var game = new TestGame(mockRenderer.Object, mockInputManager.Object);
            return game;
        }
    }
}
