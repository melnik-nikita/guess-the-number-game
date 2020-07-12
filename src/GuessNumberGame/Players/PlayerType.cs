namespace GuessNumberGame.Players
{
    public enum PlayerType
    {
        /// <summary>
        ///     Guesses a random number
        /// </summary>
        Random,

        /// <summary>
        ///     Guesses a random number, but doesn't try the same number more than once
        /// </summary>
        Memory,

        /// <summary>
        ///     Guesses all numbers by order
        /// </summary>
        Thorough,

        /// <summary>
        ///     Guesses a random number, but doesn't try any of the numbers
        ///     other players tried
        /// </summary>
        Cheater,

        /// <summary>
        ///     Guesses all numbers by order, but doesn't try any of the numbers
        ///     other players tried
        /// </summary>
        ThoroughCheater
    }
}
