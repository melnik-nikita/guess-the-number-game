using System.Collections.Generic;
using GuessNumberGame.Utils;

namespace GuessNumberGame.Guesses
{
    public class MemoryGuess : IGuessBehaviour
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly SortedSet<int> _guessedNumbers = new SortedSet<int>();

        public MemoryGuess(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        public int MakeGuess(int min, int max)
        {
            var guess = _randomGenerator.Generate(min, max, _guessedNumbers);

            _guessedNumbers.Add(guess);

            return guess;
        }
    }
}
