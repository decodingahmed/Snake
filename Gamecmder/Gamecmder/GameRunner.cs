using System;

namespace Gamecmder
{
    public static class GameRunner
    {
        // Comfortable fps without hazy rendering
        private static readonly TimeSpan TargetFrameTime = TimeSpan.FromSeconds(1d / 20);

        public static void Run(IGame game)
        {
            var lastTime = DateTime.UtcNow;

            while (!game.IsExiting)
            {
                var currentTime = DateTime.UtcNow;
                var elapsedTime = currentTime - lastTime;

                if (elapsedTime < TargetFrameTime)
                    continue;

                game.Update(elapsedTime);
                game.Draw(elapsedTime);

                lastTime = currentTime;
            }
        }
    }
}
