using System;
using GuessNumberGame.Fabrics;
using GuessNumberGame.GuessObservers;
using GuessNumberGame.Utils;

namespace GuessNumberGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var subject = new GuessSubject();
            var guessFabric = new GuessFabric();
            var roundCalculator = new RoundCalculator();

            var game = new Game(subject, guessFabric, roundCalculator);

            game.Initialize();
            game.Play();

            Console.ReadLine();
        }
    }
}
