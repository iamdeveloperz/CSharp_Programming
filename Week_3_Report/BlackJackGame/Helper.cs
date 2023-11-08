using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    public enum E_SUIT 
    { 
        Hearts, 
        Diamnods, 
        Clubs, 
        Spades 
    }

    public enum E_RANK
    {
        TWO = 2,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE
    }

    public static class Helper
    {
        #region Variables

        public static Random random = new Random();

        public const int g_TotalScoreMax = 21;
        public const int g_DealerScoreMax = 17;

        #endregion

        #region Helper Methods
        public static int RandomMinMax(int min, int max)
        {
            return random.Next(min, max);
        }

        public static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        public static void Swap<T>(this List<T> list, int from, int to)
        {
            T temp = list[from];
            list[from] = list[to];
            list[to] = temp;
        }
        #endregion
    }
}
