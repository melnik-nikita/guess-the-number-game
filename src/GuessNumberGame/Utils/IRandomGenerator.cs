using System.Collections.Generic;

namespace GuessNumberGame.Utils
{
    public interface IRandomGenerator
    {
        int Generate(int min, int max, IEnumerable<int> exclusions = null);
    }
}
