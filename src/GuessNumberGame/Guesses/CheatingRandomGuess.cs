using System.Collections.Generic;
using GuessNumberGame.GuessObservers;
using GuessNumberGame.Utils;

namespace GuessNumberGame.Guesses
{
    public class CheatingRandomGuess : ICheatingGuessBehaviour
    {
        private readonly SortedSet<int> _guessedNumbers = new SortedSet<int>();
        private readonly IRandomGenerator _randomGenerator;
        private readonly IGuessSubject _guessSubject;

        public CheatingRandomGuess(IRandomGenerator randomGenerator,IGuessSubject guessSubject)
        {
            _randomGenerator = randomGenerator;
            _guessSubject = guessSubject;
            _guessSubject.RegisterObserver(this);
        }

        public int MakeGuess(int min, int max)
        {
            var guess = _randomGenerator.Generate(min, max, _guessedNumbers);

            return guess;
        }

        public void NumberGuessed(int guess)
        {
            _guessedNumbers.Add(guess);
        }
    }
}
