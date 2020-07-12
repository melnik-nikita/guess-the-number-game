namespace GuessNumberGame.GuessObservers
{
    public interface IGuessSubject
    {
        void RegisterObserver(IGuessObserver guessObserver);

        void RemoveObserver(IGuessObserver guessObserver);

        void NotifyObservers(int guess);
    }
}
