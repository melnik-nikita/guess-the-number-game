using System;
using GuessNumberGame.Utils;

namespace GuessNumberGame.Guesses
{
    public class RandomGuess : IGuessBehaviour
    {
        private readonly Random _random = new Random();

        public int MakeGuess(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
