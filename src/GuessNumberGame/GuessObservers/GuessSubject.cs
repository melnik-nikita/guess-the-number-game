using System.Collections.Generic;

namespace GuessNumberGame.GuessObservers
{
    public class GuessSubject : IGuessSubject
    {
        private readonly IList<IGuessObserver> _guessObservers;

        public GuessSubject()
        {
            _guessObservers = new List<IGuessObserver>();
        }

        public void RegisterObserver(IGuessObserver guessObserver)
        {
            _guessObservers.Add(guessObserver);
        }

        public void RemoveObserver(IGuessObserver guessObserver)
        {
            _guessObservers.Remove(guessObserver);
        }

        public void NotifyObservers(int guess)
        {
            foreach (var observer in _guessObservers)
            {
                observer.NumberGuessed(guess);
            }
        }
    }
}
