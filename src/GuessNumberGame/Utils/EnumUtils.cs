using System;
using static System.Enum;

namespace GuessNumberGame.Utils
{
    public class EnumUtils
    {
        public static bool TryGetEnum<T>(string enumString, out T enumValue) where T : struct, Enum
        {
            return TryParse(enumString, true, out enumValue) && IsDefined(typeof(T), enumValue);
        }
    }
}
