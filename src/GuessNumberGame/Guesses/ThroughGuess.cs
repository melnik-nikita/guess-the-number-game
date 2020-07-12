namespace GuessNumberGame.Guesses
{
    public class ThroughGuess : IGuessBehaviour
    {
        private int _lastGuess = GameSettings.MinWeight;

        public int MakeGuess(int min, int max)
        {
            return ++_lastGuess;
        }
    }
}
