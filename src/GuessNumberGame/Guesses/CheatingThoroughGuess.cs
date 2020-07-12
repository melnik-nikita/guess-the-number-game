using System.Collections.Generic;
using GuessNumberGame.GuessObservers;

namespace GuessNumberGame.Guesses
{
    public class CheatingThoroughGuess : ICheatingGuessBehaviour
    {
        private readonly SortedSet<int> _guessedNumbers = new SortedSet<int>();
        private readonly IGuessSubject _guessSubject;
        private int _lastGuess = GameSettings.MinWeight;

        public CheatingThoroughGuess(IGuessSubject guessSubject)
        {
            _guessSubject = guessSubject;
            _guessSubject.RegisterObserver(this);
        }

        public int MakeGuess(int min, int max)
        {
            do
            {
                _lastGuess++;
            } while (_guessedNumbers.Contains(_lastGuess));

            return _lastGuess;
        }

        public void NumberGuessed(int guess)
        {
            _guessedNumbers.Add(guess);
        }
    }
}
