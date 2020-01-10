using System;

namespace SnakeNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new SnakeGame();
            game.Run();

            Console.WriteLine("Thanks for playing. Goodbye.");
        }
    }
}
