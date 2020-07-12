namespace GuessNumberGame
{
    public class GameSettings
    {
        public const int MinWeight = 40;
        public const int MaxWeight = 140;
        public const int MinPlayers = 2;
        public const int MaxPlayers = 8;

        public GameSettings(int weight, int totalPlayers, int rounds = 100)
        {
            Weight = weight;
            TotalPlayers = totalPlayers;
            Rounds = rounds;
        }

        public int Weight { get; }

        public int Rounds { get; }

        public int TotalPlayers { get; }
    }
}
