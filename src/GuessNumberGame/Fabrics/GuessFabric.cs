using System;
using GuessNumberGame.Guesses;
using GuessNumberGame.GuessObservers;
using GuessNumberGame.Players;
using GuessNumberGame.Utils;

namespace GuessNumberGame.Fabrics
{
    public class GuessFabric : IGuessFabric
    {
        public IGuessBehaviour GetGuess(PlayerType playerType, IGuessSubject guessSubject)
        {
            IGuessBehaviour guessBehaviour;
            IRandomGenerator randomGenerator = new RandomNumberGenerator();

            switch (playerType)
            {
                case PlayerType.Random:
                    guessBehaviour = new RandomGuess();

                    break;
                case PlayerType.Memory:
                    guessBehaviour = new MemoryGuess(randomGenerator);

                    break;
                case PlayerType.Thorough:
                    guessBehaviour = new ThroughGuess();

                    break;
                case PlayerType.Cheater:
                    guessBehaviour = new CheatingRandomGuess(randomGenerator, guessSubject);

                    break;
                case PlayerType.ThoroughCheater:
                    guessBehaviour = new CheatingThoroughGuess(guessSubject);

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(playerType), playerType, null);
            }

            return guessBehaviour;
        }
    }
}
