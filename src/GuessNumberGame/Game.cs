using System;
using System.Collections.Generic;
using System.Linq;
using GuessNumberGame.Fabrics;
using GuessNumberGame.GuessObservers;
using GuessNumberGame.Players;
using GuessNumberGame.Utils;

namespace GuessNumberGame
{
    public class Game
    {
        private readonly IGuessFabric _guessFabric;
        private readonly IGuessSubject _guessSubject;
        private readonly IRoundCalculator _roundCalculator;
        private GameSettings _gameSettings;
        private IList<Player> _players = new List<Player>();

        public Game(IGuessSubject guessSubject, IGuessFabric guessFabric, IRoundCalculator roundCalculator)
        {
            _guessSubject = guessSubject;
            _guessFabric = guessFabric;
            _roundCalculator = roundCalculator;
        }

        public int ClosestGuess { get; private set; }
        public Player ClosestPlayer { get; private set; }

        public void Initialize()
        {
            var totalPlayers = GetParticipantsNumber();
            var basketWeight = GetBasketWeight();

            _gameSettings = new GameSettings(basketWeight, totalPlayers);

            InitializePlayers();
            ShufflePlayers();
        }

        public void Play()
        {
            Console.WriteLine("#######################################");
            Console.WriteLine($"# Basket weight is: {_gameSettings.Weight}");
            Console.WriteLine("#######################################");

            for (var round = 0; round < _gameSettings.Rounds; round++)
            {
                foreach (var player in _players)
                {
                    if (player.RoundCooldown != 0)
                    {
                        player.RoundCooldown--;

                        continue;
                    }

                    var guessedNumber = player.Guess(GameSettings.MinWeight, GameSettings.MaxWeight);

                    _guessSubject.NotifyObservers(guessedNumber);

                    if (guessedNumber != _gameSettings.Weight)
                    {
                        player.RoundCooldown = _roundCalculator.GetNumberOfRoundsToSkip(_gameSettings.Weight, guessedNumber);

                        UpdateClosestGuess(player, guessedNumber);
                    }
                    else
                    {
                        PrintWinner(player, guessedNumber);

                        return;
                    }
                }
            }

            Console.WriteLine("No one guessed the number.");

            PrintWinner(ClosestPlayer, ClosestGuess);
        }

        #region Private Methods

        private void UpdateClosestGuess(Player player, int guessedNumber)
        {
            var closest = Math.Abs(_gameSettings.Weight - ClosestGuess);
            var newGuess = Math.Abs(_gameSettings.Weight - guessedNumber);

            if (closest > newGuess)
            {
                ClosestGuess = guessedNumber;
                ClosestPlayer = player;
            }
        }

        private void PrintWinner(Player player, int guess)
        {
            Console.WriteLine($"Player '{player.Name}' has won!");
            Console.WriteLine($"Attempts: {player.Attempts}");
            Console.WriteLine($"Guessed number is: {guess}");
        }

        private void InitializePlayers()
        {
            Console.WriteLine("Please enter each player Name and Type.");
            Console.WriteLine("Possible player types:");
            foreach (var playerType in Enum.GetValues(typeof(PlayerType)).Cast<PlayerType>())
            {
                Console.WriteLine($"{(int)playerType} - {playerType}");
            }

            for (var i = 0; i < _gameSettings.TotalPlayers; i++)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine($"Player{i + 1}");
                InitializePlayer();
            }
        }

        private void ShufflePlayers()
        {
            var random = new Random();

            _players = _players.OrderBy(_ => random.Next()).ToList();
        }

        private void InitializePlayer()
        {
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Type:");
            var playerTypeString = Console.ReadLine();

            PlayerType playerType;

            while (!EnumUtils.TryGetEnum(playerTypeString, out playerType))
            {
                Console.WriteLine("Invalid player type, please try again:");
                playerTypeString = Console.ReadLine();
            }

            var player = new Player(name);

            player.SetGuess(_guessFabric.GetGuess(playerType, _guessSubject));

            _players.Add(player);
        }

        private int GetBasketWeight()
        {
            var random = new Random();

            return random.Next(GameSettings.MinWeight, GameSettings.MaxWeight);
        }

        private int GetParticipantsNumber()
        {
            int totalPlayers;

            Console.WriteLine($"Please enter the number of players({GameSettings.MinPlayers}-{GameSettings.MaxPlayers}):");

            do
            {
                var playersInput = Console.ReadLine();

                if (!int.TryParse(playersInput, out totalPlayers))
                {
                    Console.WriteLine($"The number of players should be between {GameSettings.MinPlayers} and {GameSettings.MinPlayers}");
                }
            } while (totalPlayers < GameSettings.MinPlayers || totalPlayers > GameSettings.MaxPlayers);

            return totalPlayers;
        }

        #endregion
    }
}
