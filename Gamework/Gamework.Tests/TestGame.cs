using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Gamework.Input;
using Gamework.Rendering;

namespace Gamework.Tests
{
    public class TestGame : CmdGame
    {
        public int UpdateCallCount { get; set; }
        public int DrawCallCount { get; set; }


        public Task RunThenExit()
        {
            return Task.WhenAny(
                Task.Run(() => Run()),
                Task.Delay(200)
            );
        }


        public TestGame(IRenderer renderer, IInputManager inputManager)
            : base(renderer, inputManager)
        {
        }

        public override void Update(TimeSpan elapsed)
        {
            base.Update(elapsed);

            UpdateCallCount++;
        }

        public override void Draw(TimeSpan elapsed)
        {
            base.Draw(elapsed);

            DrawCallCount++;
        }
    }
}
