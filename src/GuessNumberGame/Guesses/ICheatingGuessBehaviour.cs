using GuessNumberGame.GuessObservers;

namespace GuessNumberGame.Guesses
{
    public interface ICheatingGuessBehaviour : IGuessBehaviour, IGuessObserver
    {
    }
}
