namespace GuessNumberGame.Utils
{
    public interface IRoundCalculator
    {
        int GetNumberOfRoundsToSkip(int weight, int guess);
    }
}
