using System;
using Gamecmder;

namespace SnakeNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new SnakeGame();

            GameRunner.Run(game);

            Console.WriteLine("Thanks for playing. Goodbye.");
        }
    }
}
