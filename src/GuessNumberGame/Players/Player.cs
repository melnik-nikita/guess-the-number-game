using GuessNumberGame.Guesses;

namespace GuessNumberGame.Players
{
    public class Player
    {
        private IGuessBehaviour _guessBehaviour;

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public int Attempts { get; private set; }
        public int RoundCooldown { get; set; }

        public void SetGuess(IGuessBehaviour guessBehaviour)
        {
            _guessBehaviour = guessBehaviour;
        }

        public int Guess(int min, int max)
        {
            Attempts++;

            return _guessBehaviour.MakeGuess(min, max);
        }
    }
}
