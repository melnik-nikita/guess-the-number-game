using GuessNumberGame.Guesses;
using GuessNumberGame.GuessObservers;
using GuessNumberGame.Players;

namespace GuessNumberGame.Fabrics
{
    public interface IGuessFabric
    {
        IGuessBehaviour GetGuess(PlayerType playerType, IGuessSubject guessSubject);
    }
}
