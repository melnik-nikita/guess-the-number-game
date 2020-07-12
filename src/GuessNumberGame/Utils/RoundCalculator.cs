using System;

namespace GuessNumberGame.Utils
{
    public class RoundCalculator : IRoundCalculator
    {
        public int GetNumberOfRoundsToSkip(int weight, int guess)
        {
            var roundsToSkip = (Math.Abs(weight - guess) / 10) - 1;

            if (roundsToSkip < 0)
            {
                roundsToSkip = 0;
            }

            return roundsToSkip;
        }
    }
}
