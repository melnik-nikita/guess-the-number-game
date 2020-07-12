using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessNumberGame.Utils
{
    public class RandomNumberGenerator: IRandomGenerator
    {
        private static readonly Random _random = new Random();

        public int Generate(int min, int max, IEnumerable<int> exclusions = null)
        {
            exclusions ??= new int[] { };

            var range = Enumerable
                .Range(min + 1, max - min)
                .Where(i => !exclusions.Contains(i));

            var index = _random.Next(min + 1, max - exclusions.Count());

            var guess = range.ElementAt(index - min - 1);

            return guess;
        }
    }
}
